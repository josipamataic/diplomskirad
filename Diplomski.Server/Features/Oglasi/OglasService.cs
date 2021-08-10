using Diplomski.Server.Data;
using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Oglasi.Models;
using Diplomski.Server.Features.Prijave;
using Diplomski.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Oglasi
{
    public class OglasService : IOglasService
    {
        private readonly DiplomskiDbContext data;
        private readonly IPrijavaService prijave;

        public OglasService(DiplomskiDbContext data, IPrijavaService prijave)
        {
            this.data = data;
            this.prijave = prijave;
        }

        public async Task<int> Create(string naziv, int industrijaid, string opis, string userId)
        {
            var oglas = new Oglas
            {
                Naziv = naziv,
                IndustrijaId = industrijaid,               
                Opis = opis,
                PoslodavacId = userId
            };

            this.data.Add(oglas);

            await this.data.SaveChangesAsync();

            return oglas.Id;
        }

        public async Task<Result> CreatePitanja(int oglasId, List<string> pitanja)
        {
            var pitanjeList = new List<Pitanje>();
            foreach(var pitanje in pitanja)
            {
                var pitanjeModel = new Pitanje
                {
                    OglasId = oglasId,
                    Tekst = pitanje
                };
                pitanjeList.Add(pitanjeModel);
            }
            this.data.AddRange(pitanjeList);
            await this.data.SaveChangesAsync();
            return true;
        }

        public async Task<int> CreateObavijest(string userId, int oglasId, string naslov, string tekst)
        {
            var obavijest = new Obavijest
            {
                IdPoslodavac = userId,
                Naslov = naslov,
                Tekst = tekst,
                IdOglas = oglasId
            };
            this.data.Add(obavijest);
            await this.data.SaveChangesAsync();
            return obavijest.Id;
        }

        public async Task<Result> CreateKandidatObavijest(int obavijestId, List<string> userId)
        {
            var kandidatObavijestList = new List<KandidatObavijest>();

            foreach(var kandidatId in userId)
            {
                var kandidatObavijest = new KandidatObavijest
                {
                    KandidatId = kandidatId,
                    ObavijestId = obavijestId
                };

                kandidatObavijestList.Add(kandidatObavijest);
            }
            this.data.AddRange(kandidatObavijestList);
            await this.data.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<ObavijestDetailsModel>> GetObavijesti(string userId)
        {
            var obavijestiIds = this.data.KandidatObavijest.Where(o => o.KandidatId == userId).Select(o => o.ObavijestId).ToList();


            var obavijesti = this.data.Obavijest.Where(o => obavijestiIds.Contains(o.Id)).Select(o => new ObavijestDetailsModel
            {
                Naslov = o.Naslov,
                NazivOglas = o.Oglas.Naziv,
                Tekst = o.Tekst,
                NazivPoslodavca = o.Poslodavac.PoslodavacProfil.NazivFirme,
                OglasId = o.IdOglas,
                PoslodavacId = o.IdPoslodavac,
                Created = o.CreatedOn
            }).ToList().OrderByDescending(l => l.Created);

            if (obavijestiIds != null)
            {
                //var obavijestId = this.data.KandidatObavijest.Where(o => o.Id == obavijest && !o.Otvoreno).Select(o => o.Id);
                await this.OtvoriObavijest(obavijestiIds);

            }

            return obavijesti;

        }

        public async Task<int> GetBrojNovihObavijesti(string userId)
        {
            var noveObavijesti = this.data.KandidatObavijest.Where(o => o.KandidatId == userId && !o.Otvoreno).Count();
            return noveObavijesti;
        }

        public async Task<Result> OtvoriObavijest(List<int> idObavijest)
        {

            var obavijesti =  this.data.KandidatObavijest.Where(k => idObavijest.Contains(k.ObavijestId) && !k.Otvoreno).ToList();

            foreach (var obavijest in obavijesti)
            {
                obavijest.Otvoreno = true;
            }            

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeletePitanja(List<int> pitanja)
        {
            var obrisiPitanja = this.data.Pitanje.Where(o => pitanja.Contains(o.Id)).ToList();
            this.data.Pitanje.RemoveRange(obrisiPitanja);

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<Result> Delete(int id, string userId)
        {
            var oglas = await this.GetByIdAndByUserId(id, userId);

            if(oglas == null)
            {
                return "Ovaj korisnik ne može izbrisati ovaj oglas.";
            }

            //ukloni sve obavijesti prilikom brisanja
            if (!oglas.Arhiviran)
            {
                await DeleteKandidatObavijest(id);
            }
            

            //obrisi sve prijave
            var result = await this.prijave.DeleteFromOglas(oglas.Id);           

            //obriši sva povezana pitanja

            var pitanja = this.data.Pitanje.Where(c => c.OglasId == id).ToArray();

            this.data.Pitanje.RemoveRange(pitanja);

            /*foreach(var pitanje in pitanja)
            {
                this.data.Pitanje.Remove(pitanje);
            }*/
            
            this.data.Oglas.Remove(oglas);

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<Result> Arhiviraj(int oglasId, string userId)
        {
            var oglas = await this.GetByIdAndByUserId(oglasId, userId);

            if (oglas == null)
            {
                return "Ovaj korisnik ne može arhivirati ovaj oglas.";
            }

            //ukloni sve obavijesti prilikom arhiviranja
            await DeleteKandidatObavijest(oglasId);

            var prijaveId = this.data.Prijava.Where(p => p.IdOglas == oglasId).Select(p => p.Id).ToArray();
            

            foreach(var prijavaId in prijaveId)
            {
                await this.prijave.DeleteOdgovoriFromPrijava(prijavaId);
            }

            var prijaveZaBrisanje = this.data.Prijava.Where(p => p.IdOglas == oglasId && p.Kandidat.PrivatniProfil).ToArray();

            this.data.Prijava.RemoveRange(prijaveZaBrisanje);

            oglas.Arhiviran = true;

            await this.data.SaveChangesAsync();

            return true;
        }

        private async Task<Result> DeleteKandidatObavijest(int oglasId)
        {
            var obavijestiIds = this.data.Obavijest.Where(p => p.IdOglas == oglasId).Select(p => p.Id).ToList();

            if (obavijestiIds.Count > 0)
            {

                var kandidatObavijesti = this.data.KandidatObavijest.Where(k => obavijestiIds.Contains(k.ObavijestId)).ToList();
                this.data.KandidatObavijest.RemoveRange(kandidatObavijesti);

                var obavijesti = this.data.Obavijest.Where(o => obavijestiIds.Contains(o.Id)).ToList();
                this.data.Obavijest.RemoveRange(obavijesti);

                await this.data.SaveChangesAsync();
               
            }
            return true;
        }


        public async Task<OglasDetailsServiceModel> Details(int id)
            => await this.data
                .Oglas
                .Where(c => c.Id == id)
                .Select(c => new OglasDetailsServiceModel
                {
                    Id = c.Id,
                    PoslodavacId = c.PoslodavacId,
                    Naziv = c.Naziv,
                    IndustrijaId = c.IndustrijaId,
                    Industrija = c.IndustrijaId == null? "" : c.Industrija.Naziv,                  
                    Opis = c.Opis,
                    UserName = c.Poslodavac.UserName,
                    Firma = c.Poslodavac.PoslodavacProfil.NazivFirme,
                    Datum = c.CreatedOn,
                    Arhiviran = c.Arhiviran
                })
                .FirstOrDefaultAsync();

        public async Task<List<PitanjaDetailsModel>> GetPitanjaByOglasId(int oglasId)
        {
            return await this.data.Pitanje
                .Where(p => p.OglasId == oglasId)
                .Select(p => new PitanjaDetailsModel
                {
                    Id = p.Id,
                    Tekst = p.Tekst
                }).ToListAsync();
        }



        public async Task<IEnumerable<OglasListingServiceModel>> OglasByUser(string userId)
            => await this.data
            .Oglas
            .Where(c => c.PoslodavacId == userId)
            .OrderBy(c => c.Arhiviran).ThenByDescending(c => c.CreatedOn)
            .Select(c => new OglasListingServiceModel
            {
                Id = c.Id,
                Naziv = c.Naziv,
                Datum = c.CreatedOn,
                Arhiviran = c.Arhiviran
                     
            })
            .ToListAsync();

        public async Task<IEnumerable<ListAllOglasModel>> GetOglasi()
        {
            var oglasi = await this.data.Oglas.Where(c=>!c.Arhiviran).OrderByDescending(c=>c.CreatedOn)
                .Select(c=> new ListAllOglasModel
                {
                    Id = c.Id,
                    PoslodavacId = c.PoslodavacId,
                    Firma = c.Poslodavac.PoslodavacProfil.NazivFirme,
                    IndustrijaId = c.IndustrijaId,
                    Industrija = c.Industrija.Naziv,
                    Naziv = c.Naziv,
                    Opis = c.Opis,
                    Lokacija = c.Poslodavac.Zemlja ,
                    Datum = c.CreatedOn.Date

                })
                .ToListAsync();

            return oglasi;
        }

        public async Task<IEnumerable<ListAllOglasModel>> GetOglasiByPoslodavac(string userId)
        {
            var oglasi = await this.data.Oglas.Where(c => !c.Arhiviran && c.PoslodavacId == userId).OrderByDescending(c => c.CreatedOn)
                .Select(c => new ListAllOglasModel
                {
                    Id = c.Id,
                    Firma = c.Poslodavac.PoslodavacProfil.NazivFirme,
                    Industrija = c.Industrija.Naziv,
                    Naziv = c.Naziv,
                    Opis = c.Opis,
                    Lokacija = c.Poslodavac.Zemlja,
                    Datum = c.CreatedOn.Date

                })
                .ToListAsync();

            return oglasi;
        }



        public async Task<Result> Update(int id, string naziv, int industrijaid, string opis, string userId)
        {
            var oglas = await this.GetByIdAndByUserId(id, userId);

            if (oglas == null)
            {
                return "Ovaj korisnik ne može uređivati ovaj oglas.";
            }

            oglas.Naziv = naziv;
            oglas.IndustrijaId= industrijaid;           
            oglas.Opis = opis;

            await this.data.SaveChangesAsync();

            return true;            
        }

        public async Task<List<KandidatDetailsModel>> GetKandidatiByOglasId(int oglasId, string userId)
        {
            var oglas = await this.GetByIdAndByUserId(oglasId, userId);

            if (oglas == null)
            {
                return null;
            }
            else
            {
                var kandidati = this.data.Prijava.Where(p => p.IdOglas == oglasId).Select(p => new KandidatDetailsModel
                {
                    Id = p.Kandidat.Id,
                    Ime = p.Kandidat.KandidatProfil.Ime,
                    Prezime = p.Kandidat.KandidatProfil.Prezime,
                    DatumRodenja = p.Kandidat.KandidatProfil.DatumRodenja,
                    Industrija = p.Kandidat.Industrija.Naziv,
                    Obrazovanje = p.Kandidat.KandidatProfil.Obrazovanje,
                    Zemlja = p.Kandidat.Zemlja,
                    Email = p.Kandidat.Email,
                    BrojMobitela = p.Kandidat.PhoneNumber,
                    DatumPrijave = p.CreatedOn,
                    Odgovori = p.Odgovori.Select(o => new KandidatOdgovor
                    {
                        PitanjeId = o.IdPItanja,
                        TekstPitanje = o.Pitanje.Tekst,
                        OdgovorId = o.Id,
                        TekstOdgovor = o.Tekst
                    }).ToList()
                }).ToList();

                return kandidati;
            }
            
        }

        public async Task<PoslodavacDetailsModel> GetPoslodavac(string poslodavacId)
        {

            var poslodavac = this.data.Users.Where(u => u.Id == poslodavacId).Select(u => new PoslodavacDetailsModel { 
                Id = u.Id,
                Email = u.Email,
                Industrija = u.Industrija.Naziv,
                IndustrijaId = u.IndustrijaId,
                Kontakt = u.PoslodavacProfil.Kontakt,
                NazivFirme = u.PoslodavacProfil.NazivFirme,
                Opis = u.PoslodavacProfil.Opis,
                Zemlja = u.Zemlja 

            }).FirstOrDefault();

            return poslodavac;


        }


        //filtritaj i di je industrijaid od oglasa = industrija id
        public async Task<List<KandidatDetailsModel>> GetKandidatiByPoslodavacId(string poslodavacId, int oglasId)
        {
            var industrijaId = this.data.Oglas.Where(o => o.Id == oglasId).Select(o =>o.IndustrijaId).FirstOrDefault();

            var obavijestVecPoslana = this.data.Obavijest.Where(o => o.IdOglas == oglasId).Select(o => o.Id).ToList();

            var kandidatiVecObavijesteni = this.data.KandidatObavijest.Where(k => obavijestVecPoslana.Contains(k.ObavijestId)).Select(k => k.KandidatId).ToList();
                    

            var oglasi = this.data.Oglas.Where(o => o.PoslodavacId == poslodavacId && o.IndustrijaId == industrijaId && o.Id != oglasId).Select(o => o.Id).ToList();
          
            var kandidati = this.data.Prijava.Where(p => oglasi.Contains(p.IdOglas) && !p.Kandidat.PrivatniProfil && !kandidatiVecObavijesteni.Contains(p.IdKandidat)).Select(p => new KandidatDetailsModel
            {
                Id = p.Kandidat.Id,
                Ime = p.Kandidat.KandidatProfil.Ime,
                Prezime = p.Kandidat.KandidatProfil.Prezime,
                DatumRodenja = p.Kandidat.KandidatProfil.DatumRodenja,
                Industrija = p.Kandidat.Industrija.Naziv,
                Obrazovanje = p.Kandidat.KandidatProfil.Obrazovanje,
                Zemlja = p.Kandidat.Zemlja,
                Email = p.Kandidat.Email,
                BrojMobitela = p.Kandidat.PhoneNumber
            }).ToList();

            return kandidati;
        }

        private async Task<Oglas> GetByIdAndByUserId(int id, string userId)
            => await this.data.Oglas
               .Where(c => c.Id == id && c.PoslodavacId == userId)
               .FirstOrDefaultAsync();

       
    }
}

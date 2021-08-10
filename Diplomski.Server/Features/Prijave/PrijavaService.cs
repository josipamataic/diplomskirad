using Diplomski.Server.Data;
using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Prijave.Models;
using Diplomski.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Prijave
{
    public class PrijavaService : IPrijavaService
    {
        private readonly DiplomskiDbContext data;

        public PrijavaService(DiplomskiDbContext data)
        {
            this.data = data;
        }

        public async Task<int> Create(int oglasid, string userId)
        {
            var kandidat = this.data.Users.Where(u => u.Id == userId).FirstOrDefault();
            
            if(kandidat.KandidatProfil.Ime == null || kandidat.KandidatProfil.Prezime == null || kandidat.KandidatProfil.Obrazovanje == null
                )
            {
                return 0;
            }

            var prijava = new Prijava
            {
                IdKandidat = userId,
                IdOglas = oglasid
            };

            this.data.Add(prijava);
            await this.data.SaveChangesAsync();
            return prijava.Id;
        }

        public async Task<bool> CreateOdgovori(string userId, int oglasId, int prijavaId, IEnumerable<PitanjeOdgovorModel> model)
        {
            foreach(var pitanjeOdgovor in model)
            {
                var odgovor = new Odgovor
                {
                    IdOglasa = oglasId,
                    IdPrijava = prijavaId,
                    IdKandidata = userId,
                    IdPItanja = pitanjeOdgovor.PitanjeId,
                    Tekst = pitanjeOdgovor.OdgovorTekst
                };

                this.data.Add(odgovor);
            }

            await this.data.SaveChangesAsync();
            return true;
        }

        public async Task<Result> Delete(int id, string userId)
        {
            var prijava = await this.GetByIdAndByUserId(id, userId);

            if(prijava == null)
            {
                return "Ovaj korisnik ne može obrisati ovu prijavu";
            }

            //obriši povezane odgovore
            var odgovori = this.data.Odgovor.Where(c => c.IdPrijava == id).ToArray();

            foreach (var odgovor in odgovori)
            {
                this.data.Odgovor.Remove(odgovor);
            }

            this.data.Prijava.Remove(prijava);

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteOdgovoriFromPrijava(int prijavaId)
        {
            var odgovori = this.data.Odgovor.Where(o => o.IdPrijava == prijavaId).ToArray();

            foreach (var odgovor in odgovori)
            {
                this.data.Odgovor.Remove(odgovor);
            }          

            await this.data.SaveChangesAsync();

            return true;


        }

        public async Task<Result> DeleteFromOglas(int oglasId)
        {
            var prijaveIds = this.data.Prijava.Where(c => c.IdOglas == oglasId)
                .Select(p => p.Id)
                .ToList();

            if (prijaveIds.Count > 0)
            {
                var odgovori = this.data.Odgovor.Where(o => prijaveIds.Contains(o.IdPrijava)).ToList();
                this.data.Odgovor.RemoveRange(odgovori);

                var prijave = this.data.Prijava.Where(o => prijaveIds.Contains(o.Id)).ToList();
                this.data.Prijava.RemoveRange(prijave);

                await this.data.SaveChangesAsync();
            }

            return true;
        }

        public async Task<Prijava> GetByIdAndByUserId(int id, string userId)
            => await this.data.Prijava
            .Where(c => c.Id == id && c.IdKandidat == userId)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<PrijaveByUserModel>> GetPrijaveByUser(string userId)
        {
            var prijave = this.data.Prijava.Where(c => c.IdKandidat == userId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new PrijaveByUserModel
                {
                    Id = c.Id,
                    OglasId = c.IdOglas,
                    NazivOglas = c.Oglas.Naziv,
                    Opis = c.Oglas.Opis,
                    Industrija = c.Oglas.Industrija.Naziv,
                    DatumPrijave = c.CreatedOn,
                    Firma = c.Oglas.Poslodavac.PoslodavacProfil.NazivFirme
                }).ToListAsync();

            var listaprijava = await prijave;

            foreach(var prijava in listaprijava)
            {
                prijava.PitanjeOdgovor = await GetPitanjeOdgovorByUserPrijava(prijava.OglasId, userId);
            }

            return await prijave;
        }

        public async Task<List<PitanjeOdgovorPrijavaModel>> GetPitanjeOdgovorByUserPrijava(int oglasId, string userId)
        {

            var pitanja = data.Pitanje.Where(p => p.OglasId == oglasId);
                
                //data.Prijava.Where(p => p.Id == prijavaId && p.IdKandidat == userId).Select(p => p.Oglas.Pitanja);

            List<PitanjeOdgovorPrijavaModel> pitodgovor = new List<PitanjeOdgovorPrijavaModel>();

            foreach(Pitanje pitanje in pitanja)
            {
               // Odgovor odgovor = (Odgovor)data.Odgovor.Where(p => p.IdPItanja == pitanje.Id && p.IdKandidata == userId);
                var pitanjeOdgovor = new PitanjeOdgovorPrijavaModel
                {
                    TekstPitanje = pitanje.Tekst,
                    TekstOdgovor = data.Odgovor.Where(p => p.IdPItanja == pitanje.Id && p.IdKandidata == userId).FirstOrDefault().Tekst
                };

                pitodgovor.Add(pitanjeOdgovor);
            }

            return pitodgovor;
           
        }

        public async Task<bool> PrijavaNaOglas(int oglasId, string userId)
        {
            var prijave = this.data.Prijava.Where(c => c.IdKandidat == userId && c.IdOglas == oglasId).ToList();
            if(prijave.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using Diplomski.Server.Data;
using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Prijave;
using Diplomski.Server.Features.Profili.Models;
using Diplomski.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Profili
{
    public class KandidatProfilService : IKandidatProfilService
    {
        private readonly DiplomskiDbContext data;
        private readonly IPrijavaService prijave;
        private readonly UserManager<User> userManager;

        public KandidatProfilService(DiplomskiDbContext data, IPrijavaService prijave, UserManager<User> userManager)
        {
            this.data = data;
            this.prijave = prijave;
            this.userManager = userManager;
        }


        public async Task<KandidatProfilServiceModel> MyProfil(string userId)
        {
            var profil = await this.data
                  .Users
                  .Where(u => u.Id == userId)
                  .Select(u => new KandidatProfilServiceModel
                  {
                      Ime = u.KandidatProfil.Ime,
                      Prezime = u.KandidatProfil.Prezime,
                      DatumRodenja = u.KandidatProfil.DatumRodenja,
                      Email = u.Email,
                      BrojMobitela = u.PhoneNumber,
                      IndustrijaId = u.IndustrijaId,
                      Industrija = u.Industrija.Naziv,
                      Obrazovanje = u.KandidatProfil.Obrazovanje,
                      Zemlja = u.Zemlja,
                      PrivatniProfil = u.PrivatniProfil
                  })
                  .FirstOrDefaultAsync();

            return profil;
        }

        public async Task<Result> Update(
            string userId,
            string userName,
            string ime,
            string prezime
            , string email, string phoneNumber,
            DateTime datumRodenja,
            int industrijaid,
            string obrazovanje,
            string zemlja,
            bool privatniProfil)
        {
            var user = await this.data.Users.FindAsync(userId);

            if (user == null)
            {
                return "Ovaj kandidat ne postoji";
            }

            var result = await this.ChangeKandidatEmail(user, userId, email);
            if (result.Failure)
            {
                return result;
            }

            result = await this.ChangeKandidatUserName(user, userId, email);
            if (result.Failure)
            {
                return result;
            }

            this.ChangeKandidatProfile(user, ime, prezime, email, phoneNumber, datumRodenja, industrijaid, obrazovanje, zemlja, privatniProfil);
           

            await this.data.SaveChangesAsync();

            return true;
        }

        private async Task<Result> ChangeKandidatEmail(User user, string userId, string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                var emailExists = await this.data.Users.AnyAsync(u => u.Id != userId && u.Email == email);

                if (emailExists)
                {
                    return "Već postoji kandidat s ovom email adresom";
                }

                user.Email = email;

            }
            return true;
        }

        private async Task<Result> ChangeKandidatUserName(User user, string userId, string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName) && user.UserName != userName)
            {
                var userNameExists = await this.data.Users.AnyAsync(u => u.Id != userId && u.UserName == userName);

                if (userNameExists)
                {
                    return "Već postoji kandidat s ovim korisničkim imenom";
                }

                user.UserName = userName;
            }
            return true;
        }

        private void ChangeKandidatProfile(
            User user,
            string ime,
            string prezime,
            string email,
            string phoneNumber,
            DateTime datumRodenja,
            int industrijaid,
            string obrazovanje,
            string zemlja,
            bool privatniProfil)
        {
            if(user.IndustrijaId!= industrijaid)
            {
                user.IndustrijaId= industrijaid;
            }
          
            if (user.Zemlja != zemlja)
            {
                user.Zemlja = zemlja;
            }
            if(user.PrivatniProfil != privatniProfil)
            {
                user.PrivatniProfil = privatniProfil;
            }
            if(user.PhoneNumber != phoneNumber)
            {
                user.PhoneNumber = phoneNumber;
            }
            if(user.KandidatProfil == null)
            {
                var kandidat = new KandidatProfil
                {
                    Ime = ime,
                    Prezime = prezime,
                    DatumRodenja = datumRodenja,
                    Obrazovanje = obrazovanje
                };
                user.KandidatProfil = kandidat;
                return;
            }

            if (user.KandidatProfil.Ime != ime)
            {
                user.KandidatProfil.Ime = ime;
            }
            if (user.KandidatProfil.Prezime != prezime)
            {
                user.KandidatProfil.Prezime = prezime;
            }
            if (user.KandidatProfil.DatumRodenja != datumRodenja)
            {
                user.KandidatProfil.DatumRodenja = datumRodenja;
            }
            if (user.KandidatProfil.Obrazovanje != obrazovanje)
            {
                user.KandidatProfil.Obrazovanje = obrazovanje;
            }
            


        }
        public async Task<Result> DeleteUser(string userId)
        {
            var obrisiPrijave = this.data.Prijava.Where(o => o.IdKandidat == userId).ToList();

            foreach (var prijava in obrisiPrijave)
            {
                await this.prijave.Delete(prijava.Id, userId);
            }

            await DeleteObavijesti(userId);


            var user = this.data.Users.Where(u => u.Id == userId).FirstOrDefault();

            var logins = await userManager.GetLoginsAsync(user);
            var rolesForUser = await userManager.GetRolesAsync(user);

            foreach (var login in logins)
            {
                await userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
            }

            foreach (var item in rolesForUser)
            {
                await userManager.RemoveFromRoleAsync(user, item);
            }

            var result = await userManager.DeleteAsync(user);

            return true;

        }

        private async Task<Result> DeleteObavijesti(string userId)
        {
            var obavijesti = this.data.KandidatObavijest.Where(k => k.KandidatId == userId).ToList();

            this.data.KandidatObavijest.RemoveRange(obavijesti);
            await this.data.SaveChangesAsync();
            return true;
        }

        public async Task<Result> Delete(string userId)
        {
            //obriši sve prijave i odgovore

            var obrisiPrijave = this.data.Prijava.Where(o => o.IdKandidat == userId).ToList();

            foreach(var prijava in obrisiPrijave)
            {
                await this.prijave.Delete(prijava.Id, userId);
            }

            //postavi sve na profilu u null       
            var user = await this.data.Users.FindAsync(userId);

            this.DeleteKandidatProfile(user);

            await this.data.SaveChangesAsync();

            return true;

        }


        private void DeleteKandidatProfile(User user)
        {
            if (user.KandidatProfil.Ime != null)
            {
                user.KandidatProfil.Ime = null;
            }
            if (user.KandidatProfil.Prezime != null)
            {
                user.KandidatProfil.Prezime = null;
            }
            if (user.KandidatProfil.DatumRodenja != null)
            {
                user.KandidatProfil.DatumRodenja = null;
            }
            if (user.KandidatProfil.Obrazovanje != null)
            {
                user.KandidatProfil.Obrazovanje = null;
            }
            if(user.Industrija != null)
            {
                user.Industrija = null;
            }
            if (user.IndustrijaId != null)
            {
                user.IndustrijaId = null;
            }
            if(user.Zemlja != null)
            {
                user.Zemlja = null;
            }
            if(user.Email != null)
            {
                user.Email = null;
            }
            if(user.PhoneNumber != null)
            {
                user.PhoneNumber = null;
            }

           /* user.KandidatProfil.Ime = null;
            user.KandidatProfil.Prezime = null;
            user.KandidatProfil.Obrazovanje = null;
            user.KandidatProfil.DatumRodenja = null;
            user.Industrija = null;
            user.IndustrijaId = null;
            user.Zemlja = null;
            user.Email = null;
            user.PhoneNumber = null;*/
        }


        public async Task<List<IndustrijaListingModel>> GetIndustrije()
        {
            var industrije = await data.Industrija.OrderBy(c=>c.Naziv).Select(c => new IndustrijaListingModel
            {
                Id = c.Id,
                Naziv = c.Naziv

            }).ToListAsync();

            return industrije;
        }

        public async Task<IEnumerable<KandidatProfilServiceModel>> GetKandidati()
        {
            var kandidati = await this.data.Users.Where(u => u.KandidatProfil != null && !u.PrivatniProfil).Select(u => new KandidatProfilServiceModel
            {
                Ime = u.KandidatProfil.Ime,
                Prezime = u.KandidatProfil.Prezime,
                Industrija = u.Industrija.Naziv,
                DatumRodenja = u.KandidatProfil.DatumRodenja,
                Obrazovanje = u.KandidatProfil.Obrazovanje,
                Zemlja = u.Zemlja,
                Email = u.Email,
                BrojMobitela = u.PhoneNumber

            }).ToListAsync();

            return kandidati;
        }
    }
}

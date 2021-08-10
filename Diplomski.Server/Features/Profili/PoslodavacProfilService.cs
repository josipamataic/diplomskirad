using Diplomski.Server.Data;
using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Profili.Models;
using Diplomski.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Server.Features.Profili
{
    public class PoslodavacProfilService : IPoslodavacProfilService
    {
        private readonly DiplomskiDbContext data;

        public PoslodavacProfilService(DiplomskiDbContext data)
        {
            this.data = data;
        }

        public async Task<PoslodavacProfilServiceModel> MyProfil(string userId)
            => await this.data
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new PoslodavacProfilServiceModel
                {
                    NazivFirme = u.PoslodavacProfil.NazivFirme,
                    Kontakt = u.PoslodavacProfil.Kontakt,
                    Email = u.Email,
                    IndustrijaId = u.IndustrijaId,
                    Industrija = u.Industrija.Naziv,
                    Opis = u.PoslodavacProfil.Opis,
                    Zemlja = u.Zemlja,
                    PrivatniProfil = u.PrivatniProfil
                })
                .FirstOrDefaultAsync();

        public async Task<Result> Update(string userId,
            string userName,
            string email,
            int industrijaid,
            string nazivFirme,
            string kontakt,
            string opis,
            string zemlja,
            bool privatniProfil)
        {
            var user = await this.data.Users.FindAsync(userId);

            if (user == null)
            {
                return "Ovaj poslodavac ne postoji.";
            }

            var result = await this.ChangePoslodavacEmail(user, userId, email);
            if (result.Failure)
            {
                return result;
            }

            result = await this.ChangePoslodavacUserName(user, userId, email);
            if (result.Failure)
            {
                return result;
            }

            this.ChangePoslodavacProfile(user, nazivFirme, kontakt, industrijaid, opis, zemlja, privatniProfil);


            await this.data.SaveChangesAsync();

            return true;


        }

        private async Task<Result> ChangePoslodavacEmail(User user, string userId, string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                var emailExists = await this.data.Users.AnyAsync(u => u.Id != userId && u.Email == email);

                if (emailExists)
                {
                    return "Već postoji poslodavac s ovom email adresom";
                }

                user.Email = email;

            }
            return true;
        }

        private async Task<Result> ChangePoslodavacUserName(User user, string userId, string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName) && user.UserName != userName)
            {
                var userNameExists = await this.data.Users.AnyAsync(u => u.Id != userId && u.UserName == userName);

                if (userNameExists)
                {
                    return "Već postoji poslodavac s ovim imenom";
                }

                user.UserName = userName;
            }
            return true;
        }

        private void ChangePoslodavacProfile(
            User user,
            string nazivFirme,
            string kontakt,
            int industrijaid,
            string opis,
            string zemlja,
            bool privatniProfil)
        {

            if (user.IndustrijaId != industrijaid)
            {
                user.IndustrijaId = industrijaid;
            }

            if (user.Zemlja != zemlja)
            {
                user.Zemlja = zemlja;
            }
            if (user.PrivatniProfil != privatniProfil)
            {
                user.PrivatniProfil = privatniProfil;
            }

            if (user.PoslodavacProfil == null)
            {
                var poslodavac = new PoslodavacProfil
                {
                    NazivFirme = nazivFirme,
                    Kontakt = kontakt,
                    Opis = opis
                    
                };
                user.PoslodavacProfil = poslodavac;
                return;
            }

            if (user.PoslodavacProfil.NazivFirme != nazivFirme)
            {
                user.PoslodavacProfil.NazivFirme = nazivFirme;
            }
            if (user.PoslodavacProfil.Kontakt != kontakt)
            {
                user.PoslodavacProfil.Kontakt = kontakt;
            }
            if (user.PoslodavacProfil.Opis != opis)
            {
                user.PoslodavacProfil.Opis = opis;
            }           
            

        }

        public async Task<IEnumerable<ListPoslodavacProfil>> GetPoslodavci()
        {
            var poslodavci = await this.data.Users.Where(u => u.PoslodavacProfil.NazivFirme != null).OrderByDescending(u=>u.CreatedOn).Select(u => new ListPoslodavacProfil
            {
                Id = u.Id,
                NazivFirme = u.PoslodavacProfil.NazivFirme,
                Opis = u.PoslodavacProfil.Opis,
                Zemlja = u.Zemlja,
                Kontakt = u.PoslodavacProfil.Kontakt,                
                Industrija = u.Industrija.Naziv,
                Email = u.Email,
                IndustrijaId = u.IndustrijaId

            }).ToListAsync();

            return poslodavci;
        }
    }
}

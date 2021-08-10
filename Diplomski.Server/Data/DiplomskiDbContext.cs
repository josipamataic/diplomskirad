using Diplomski.Server.Data.Models;
using Diplomski.Server.Data.Models.Base;
using Diplomski.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Diplomski.Server.Data
{
    public class DiplomskiDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService currentUser;

        public DiplomskiDbContext(DbContextOptions<DiplomskiDbContext> options, ICurrentUserService currentUser)
            : base(options)
            => this.currentUser = currentUser;

        public DbSet<Oglas> Oglas { get; set; }
        public DbSet<Odgovor> Odgovor { get; set; }
        public DbSet<Prijava> Prijava { get; set; }
        public DbSet<Pitanje> Pitanje { get; set; }
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<KandidatObavijest> KandidatObavijest { get; set; }
        public DbSet<Industrija> Industrija { get; set; }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            this.ApplyAuditInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Oglas>(entity =>
                {
                    entity//.HasQueryFilter(o => !o.IsDeleted)
                        .HasOne(o => o.Poslodavac)
                        .WithMany(p => p.Oglasi)
                        .HasForeignKey(o => o.PoslodavacId)
                        .OnDelete(DeleteBehavior.NoAction);

                    entity.HasOne(o => o.Industrija)
                        .WithMany(p => p.Oglasi)
                        .HasForeignKey(o => o.IndustrijaId)
                        .OnDelete(DeleteBehavior.NoAction);
                        
                });


            builder
                .Entity<User>(entity =>
                {
                    entity.HasOne(o=>o.Industrija)
                    .WithMany(p=>p.Korisnici)
                    .HasForeignKey(o=>o.IndustrijaId)
                    .OnDelete(DeleteBehavior.NoAction);

                    entity.OwnsOne(u => u.KandidatProfil)
                       .WithOwner();

                    entity.OwnsOne(u => u.PoslodavacProfil)
                    .WithOwner();
                });

           

            builder
                .Entity<Odgovor>(entity =>
                {
                    entity
                        .HasOne(o => o.Kandidat)
                        .WithMany(k => k.Odgovori)
                        .HasForeignKey(o => o.IdKandidata)
                        .OnDelete(DeleteBehavior.NoAction);

                    entity.HasOne(o => o.Pitanje)
                        .WithMany(k => k.Odgovori)
                        .HasForeignKey(o => o.IdPItanja)
                        .OnDelete(DeleteBehavior.NoAction);

                    entity.HasOne(o => o.Oglas)
                        .WithMany(k => k.Odgovori)
                        .HasForeignKey(o => o.IdOglasa)
                        .OnDelete(DeleteBehavior.NoAction);

                    entity.HasOne(o => o.Prijava)
                        .WithMany(k => k.Odgovori)
                        .HasForeignKey(o => o.IdPrijava)
                        .OnDelete(DeleteBehavior.NoAction);
                });



            builder
                .Entity<Prijava>(entity =>
                {
                    entity
                        .HasOne(o => o.Kandidat)
                        .WithMany(k => k.Prijave)
                        .HasForeignKey(o => o.IdKandidat)
                        .OnDelete(DeleteBehavior.NoAction);

                    entity.HasOne(o => o.Oglas)
                        .WithMany(k => k.Prijave)
                        .HasForeignKey(o => o.IdOglas)
                        .OnDelete(DeleteBehavior.NoAction);
                });

            builder.Entity<Pitanje>()
               // .HasQueryFilter(o => !o.IsDeleted)
                .HasOne(o => o.Oglas)
                .WithMany(k => k.Pitanja)
                .HasForeignKey(o => o.OglasId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Obavijest>(entity =>
            {
                entity//.HasQueryFilter(o => !o.IsDeleted)
                    .HasOne(o => o.Poslodavac)
                    .WithMany(k => k.Obavijesti)
                    .HasForeignKey(o => o.IdPoslodavac)
                    .OnDelete(DeleteBehavior.NoAction);


                entity.HasOne(o => o.Oglas)
                    .WithMany(k => k.Obavijesti)
                    .HasForeignKey(o => o.IdOglas)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<KandidatObavijest>(entity =>
            {
                entity//.HasQueryFilter(o => !o.IsDeleted)
                    .HasOne(o => o.Kandidat)
                    .WithMany(k => k.KandidatObavijesti)
                    .HasForeignKey(o => o.KandidatId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(o => o.Obavijest)
                    .WithMany(k => k.KandidatObavijesti)
                    .HasForeignKey(o => o.ObavijestId)
                    .OnDelete(DeleteBehavior.NoAction);
            });         
                
              

            base.OnModelCreating(builder);
        }

        private void ApplyAuditInformation()
        =>
           this.ChangeTracker
                .Entries()                
                .ToList()
                .ForEach(entry =>
                {
                    var userName = this.currentUser.GetUserName();

                    if (entry.Entity is IDeletableEntity deletableEntity)
                    {
                        if(entry.State == EntityState.Deleted)
                        {
                            deletableEntity.DeletedOn = DateTime.UtcNow;
                            deletableEntity.DeletedBy = userName;
                            deletableEntity.IsDeleted = true;

                            entry.State = EntityState.Modified;

                            return;
                        }
                    }
                    if (entry.Entity is IEntity entity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.UtcNow;
                            entity.CreatedBy = userName;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entity.ModifiedOn = DateTime.UtcNow;
                            entity.ModifiedBy = userName;
                        }
                    }

                });
        
                
           

        
    }
}

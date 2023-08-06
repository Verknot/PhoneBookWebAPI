using Microsoft.EntityFrameworkCore;
using PhoneBookWebAPI.Domain.Entity;
using PhoneBookWebAPI.Domain.Links;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PhoneBookWebAPI.DAL
{
    public class AppDataContext : DbContext
    {

        public DbSet<User> Users { get; set; }


        public AppDataContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestPhoneUsers;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.Property(e => e.PhoneNumber).HasMaxLength(15);

                builder.OwnsOne(e => e.Name, navBuilder =>
                {
                    navBuilder.Property(e => e.First);
                    navBuilder.Property(e => e.Last);
                });

                builder.OwnsOne(e => e.Birthday);

            });





            /*modelBuilder.Entity<Picture>(builder =>
            {
                var enumToStringConverter = new EnumToStringConverter<PictureType>();
                builder.Property(e => e.Type).HasConversion(enumToStringConverter).IsRequired();

                var uriToStringConverter = new UriToStringConverter();
                builder.Property(e => e.Url).HasConversion(uriToStringConverter);
            });*/

            modelBuilder.Entity<UserPicture>(builder =>
            {
                builder.HasKey(e => new { e.UserId, e.PictureId });

                builder.HasOne(e => e.User)
                    .WithMany(e => e.Pictures)
                    .HasForeignKey(e => e.UserId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(e => e.Picture)
                    .WithOne()
                    .HasForeignKey<UserPicture>(e => e.PictureId)
                    .HasPrincipalKey<Picture>(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            }
          );



        }

    }

}

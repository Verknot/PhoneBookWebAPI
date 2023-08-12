using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PhoneBookWebAPI.Domain.Entity;
using PhoneBookWebAPI.Domain.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;
namespace PhoneBookWebAPI.DAL
{
    public class AppDataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Person> Persons { get; set; }


        public AppDataContext(DbContextOptions<AppDataContext> options)
           : base(options)
        {
         //   Database.EnsureDeleted();
            Database.EnsureCreated();
        }




    /*    public AppDataContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }*/

    /*    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestPhoneUsers;Trusted_Connection=True;");
            optionsBuilder.LogTo(System.Console.WriteLine);
        }*/




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

                builder.OwnsOne(e => e.Pictures);

            });

            modelBuilder.Entity<Person>(builder =>
            {
                builder.HasData(new Person
                {
                    Id = 1,
                    Login = "Admin" ,
                    Password = "12345678" ,
                    Role =  Role.Admin,
                });
            });
       
            /*modelBuilder.Entity<Picture>(builder =>
            {
                var enumToStringConverter = new EnumToStringConverter<PictureType>();
                builder.Property(e => e.Type).HasConversion(enumToStringConverter).IsRequired();

                var uriToStringConverter = new UriToStringConverter();
                builder.Property(e => e.Url).HasConversion(uriToStringConverter);
            });*/
            /*
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
          );*/



        }

    }

}

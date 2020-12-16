using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API_Project.Models
{
    public partial class DA2_DBContext: DbContext
    {
        public DA2_DBContext() { }
        
        public DA2_DBContext(DbContextOptions<DA2_DBContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("PgConnection"));
            }
        }

        public virtual DbSet<DBUser> DBUser { get; set; }
        public virtual DbSet<DBAccount> DBAccount { get; set; }
        public virtual DbSet<DBMainMenuModel> DBMainMenu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("tds_fdw")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");


            modelBuilder.Entity<DBUser>(entity =>
            {
                entity.HasKey(e => e.IdUser).HasName("DB_User_pkey");
                entity.ToTable("User");
                entity.Property(e => e.IdUser).HasColumnName("IdUser").ValueGeneratedNever();

                entity.Property(e => e.Fullname).HasColumnName("Fullname");
                entity.Property(e => e.Gender).HasColumnName("Gender")
                    .ForNpgsqlHasComment("0 - Nữ, 1 - Nam");
                entity.Property(e => e.Birthdate).HasColumnName("Birthdate");
                entity.Property(e => e.Address).HasColumnName("Address");
                entity.Property(e => e.Nationality).HasColumnName("Nationality");
                entity.Property(e => e.IsDelete).HasColumnName("IsDelete")
                    .ForNpgsqlHasComment("false - Bình thường, true - Bị xóa");

            });

            modelBuilder.Entity<DBAccount>(entity =>
            {
                entity.HasKey(e => e.IdAccount).HasName("DB_Account_pkey");
                entity.ToTable("Account");
                entity.Property(e => e.IdAccount).HasColumnName("IdAccount").ValueGeneratedNever();

                entity.Property(e => e.IdUser).HasColumnName("IdUser");
                entity.Property(e => e.Username).HasColumnName("Username");
                entity.Property(e => e.Password).HasColumnName("Password");

            });

            modelBuilder.Entity<DBMainMenuModel>(entity =>
            {
                entity.HasKey(e => e.Id_Main)
                    .HasName("Rules_MainMenu_pkey");

                entity.ToTable("Rules_MainMenu");

                entity.Property(e => e.Id_Main)
                    .HasColumnName("Id_Main")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title).HasColumnName("Title")
                    .HasMaxLength(100);
                entity.Property(e => e.Summary).HasColumnName("Summary")
                    .HasMaxLength(200);
                entity.Property(e => e.Id_Module).HasColumnName("Id_Module");
                entity.Property(e => e.Link).HasColumnName("Link")
                    .HasMaxLength(100);
                entity.Property(e => e.Position).HasColumnName("Position");
                entity.Property(e => e.Icon).HasColumnName("Icon")
                    .HasMaxLength(50);
                entity.Property(e => e.GroupName).HasColumnName("GroupName")
                    .HasMaxLength(50);
                entity.Property(e => e.Target).HasColumnName("Target")
                    .HasMaxLength(50);
                entity.Property(e => e.AllowPermit).HasColumnName("AllowPermit");
                entity.Property(e => e.IsDisabled).HasColumnName("IsDisabled");
                entity.Property(e => e.AllowCode).HasColumnName("AllowCode")
                    .HasMaxLength(50);

            });
        }
    }
}

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
        public virtual DbSet<DBItems> DBItems { get; set; }
        public virtual DbSet<DBTypeItems> DBTypeItems { get; set; }
        public virtual DbSet<DBReview> DBReview { get; set; }
        public virtual DbSet<DBClicker> DBClicker { get; set; }
        public virtual DbSet<DBRating> DBRating { get; set; }
        public virtual DbSet<DBTransaction> DBTransaction { get; set; }
        public virtual DbSet<DBTransactionDetail> DBTransactionDetail { get; set; }

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

            modelBuilder.Entity<DBItems>(entity =>
            {
                entity.HasKey(e => e.IdItem)
                    .HasName("DB_Items_pkey");

                entity.ToTable("Items");

                entity.Property(e => e.IdItem)
                    .HasColumnName("IdItem")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdType).HasColumnName("IdType");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Money).HasColumnName("Money");
                entity.Property(e => e.Sales).HasColumnName("Sales");
                entity.Property(e => e.RateAvg).HasColumnName("RateAvg");
                entity.Property(e => e.LinkImage).HasColumnName("LinkImage");
            });

            modelBuilder.Entity<DBTypeItems>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("DB_Type_pkey");

                entity.ToTable("Type_Items");

                entity.Property(e => e.IdType)
                    .HasColumnName("IdType")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.IdMainMenu).HasColumnName("IdMainMenu");
            });

            modelBuilder.Entity<DBReview>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("DB_Review_pkey");

                entity.ToTable("Review");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAccount).HasColumnName("IdAccount");
                entity.Property(e => e.IdTransactionDetail).HasColumnName("IdTransactionDetail");
                entity.Property(e => e.IdItem).HasColumnName("IdItem");
                entity.Property(e => e.Text).HasColumnName("Text");
                entity.Property(e => e.Time).HasColumnName("Time");
            });

            modelBuilder.Entity<DBRating>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("DB_Rating_pkey");

                entity.ToTable("Rating");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAccount).HasColumnName("IdAccount");
                entity.Property(e => e.IdTransactionDetail).HasColumnName("IdTransactionDetail");
                entity.Property(e => e.IdItem).HasColumnName("IdItem");
                entity.Property(e => e.Rate).HasColumnName("Rate");
                entity.Property(e => e.Time).HasColumnName("Time");
            });

            modelBuilder.Entity<DBClicker>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("DB_Clicker_pkey");

                entity.ToTable("Clicker");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAccount).HasColumnName("IdAccount");
                entity.Property(e => e.IdTransactionDetail).HasColumnName("IdTransactionDetail");
                entity.Property(e => e.IdItem).HasColumnName("IdItem");
                entity.Property(e => e.Click).HasColumnName("Click");
                entity.Property(e => e.Time).HasColumnName("Time");
            });

            modelBuilder.Entity<DBTransaction>(entity =>
            {
                entity.HasKey(e => e.IdTransaction)
                    .HasName("DB_Transaction_pkey");

                entity.ToTable("Transaction");

                entity.Property(e => e.IdTransaction)
                    .HasColumnName("IdTransaction")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAccount).HasColumnName("IdAccount");
            });

            modelBuilder.Entity<DBTransactionDetail>(entity =>
            {
                entity.HasKey(e => e.IdTransactionDetail)
                    .HasName("DB_TransactionDetail_pkey");

                entity.ToTable("TransactionDetail");

                entity.Property(e => e.IdTransactionDetail)
                    .HasColumnName("IdTransactionDetail")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTransaction).HasColumnName("IdTransaction");
                entity.Property(e => e.IdItem).HasColumnName("IdItem");
                entity.Property(e => e.Money).HasColumnName("Money");
                entity.Property(e => e.Quantity).HasColumnName("Quantity");
            });

        }
    }
}

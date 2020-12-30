using Common.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DAL
{
    public class BookfairModel : DbContext
    {
        // Your context has been configured to use a 'BookfairModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.BookfairModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookfairModel' 
        // connection string in the application configuration file.
        public BookfairModel()
            : base("name=BookfairModel")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("User")
                .HasKey<Guid>(u => u.Id)
                .Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>()
                //.ToTable("User")
                .Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<User>()
                //.ToTable("User")
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                //.ToTable("User")
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<User>()
                //.ToTable("User")
                .Property(u => u.Birthday)
                .IsRequired();
            modelBuilder.Entity<User>()
                //.ToTable("User")
                .Property(u => u.IsMale)
                .IsRequired();
            modelBuilder.Entity<User>()
                //.ToTable("User")
                .Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(15);
            modelBuilder.Entity<User>()
                //.ToTable("User")
                .Property(u => u.Password)
                .HasMaxLength(64)
                .IsRequired();
            modelBuilder.Entity<User>()
                //.ToTable("User")
                .Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(10);
            modelBuilder.Entity<User>()
                //.ToTable("User")
                .Property(u => u.Avatar)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<User>()
                //.ToTable("User")
                .Property(u => u.HasReadTermsConditions)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .ToTable("Book")                
                .HasKey(b => b.ISBN)
                .Property(b => b.ISBN)
                .HasMaxLength(13);
            modelBuilder.Entity<Book>()
                //.ToTable("Book")
                .Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<BookCopy>()
                .ToTable("BookCopy")
                .HasKey(bc => bc.Id)
                .Property(bc => bc.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<BookCopy>()
                //.ToTable("BookCopy")
                .Property(bc => bc.Price)
                .IsRequired();
            modelBuilder.Entity<BookCopy>()
                //.ToTable("BookCopy")
                .Property(bc => bc.State)
                .IsRequired();
            modelBuilder.Entity<BookCopy>()
                //.ToTable("BookCopy")
                .Property(bc => bc.Status)
                .IsRequired();
            modelBuilder.Entity<BookCopy>()
                //.ToTable("BookCopy")
                .HasRequired(bc => bc.Book)
                .WithMany(b => b.BookCopies)
                .HasForeignKey(bc => bc.ISBN);
            modelBuilder.Entity<BookCopy>()
                //.ToTable("BookCopy")
                .HasRequired(bc => bc.User)
                .WithMany(u => u.BookCopies)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<BookImage>()
                .ToTable("BookImage")
                .HasKey(bi => bi.Id)
                .Property(bi => bi.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<BookImage>()
                //.ToTable("BookImage")
                .HasRequired(bi => bi.BookCopy)
                .WithMany(bc => bc.BookImages)
                .HasForeignKey(bi => bi.BookCopyId);
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCopy> BookCopies { get; set; }
        public virtual DbSet<BookImage> BookImages { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsMale { get; set; }
        public DateTime Birthday { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public bool HasReadTermsConditions { get; set; }

        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public int EditionYear { get; set; }
        public string ISBN { get; set; }
        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }

    public class BookCopy
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        //public string Cover { get; set; }
        public BookState State { get; set; }
        public BookStatus Status { get; set; }
        public string ISBN { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<BookImage> BookImages { get; set; }
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }

    }

    public class BookImage
    {
        public Guid Id { get; set; }
        public BookCopy BookCopy { get; set; }
        public Guid BookCopyId { get; set; }
        public bool IsCover { get; set; }
    }
}
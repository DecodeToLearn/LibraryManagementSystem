using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<BookTranslator> BookTranslators { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Register> Registers { get; set; }

        // Fluent API Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Many-to-Many Relationship: Author - Book
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);


            // Many-to-Many Relationship: Translator - Book
            modelBuilder.Entity<BookTranslator>()
                .HasKey(bt => new { bt.BookId, bt.TranslatorId });

            modelBuilder.Entity<BookTranslator>()
                .HasOne(bt => bt.Book)
                .WithMany(b => b.BookTranslators)
                .HasForeignKey(bt => bt.BookId);

            modelBuilder.Entity<BookTranslator>()
                .HasOne(bt => bt.Translator)
                .WithMany(t => t.BookTranslators)
                .HasForeignKey(bt => bt.TranslatorId);

            // One-to-Many Relationship: Category - Book
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many Relationship: Publisher - Book
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
            // Configure one-to-one relationship
            /*modelBuilder.Entity<Register>()
                .HasOne(r => r.User)
                .WithOne(u => u.Register)
                .HasForeignKey<Register>(r => r.Id);*/

            // One-to-Many Relationship: Book - Image
            modelBuilder.Entity<Image>()
                .HasOne(i => i.Book)
                .WithMany(b => b.Images)
                .HasForeignKey(i => i.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many Relationship: User - Note
            modelBuilder.Entity<Note>()
                .HasOne(n => n.Register)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.RegisterId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many Relationship: Loan - Note
            modelBuilder.Entity<Note>()
                .HasOne(n => n.Loan)
                .WithMany(l => l.Notes)
                .HasForeignKey(n => n.LoanId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-One Relationships
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Description)
                .WithOne(d => d.Book)
                .HasForeignKey<Description>(d => d.BookId);


            modelBuilder.Entity<Author>()
                .HasOne(a => a.Description)
                .WithOne(d => d.Author)
                .HasForeignKey<Description>(d => d.AuthorId);


            modelBuilder.Entity<Publisher>()
                .HasOne(p => p.Description)
                .WithOne(d => d.Publisher)
                .HasForeignKey<Description>(d => d.PublisherId);


            modelBuilder.Entity<Translator>()
                .HasOne(t => t.Description)
                .WithOne(d => d.Translator)
                .HasForeignKey<Description>(d => d.TranslatorId);


            modelBuilder.Entity<Category>()
                .HasOne(c => c.Description)
                .WithOne(d => d.Category)
                .HasForeignKey<Description>(d => d.CategoryId);

            // One-to-Many Relationship: User - Loan
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Register)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.RegisterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
            .HasOne(l => l.Book)
            .WithMany(u => u.Loans)
            .HasForeignKey(l => l.BookId)
            .OnDelete(DeleteBehavior.Restrict);

            // Book Configuration
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.ISBN)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Edition)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.YearOfPublication)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)");
            // Authors Configuration
            modelBuilder.Entity<Author>()
                .Property(a => a.FirstName)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .Property(a => a.LastName)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .Property(a => a.ImageUrl)
                .IsRequired();

            // Categories Configuration
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.ImageUrl)
                .IsRequired();

            // Publisher Configuration
            modelBuilder.Entity<Publisher>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Publisher>()
                .Property(p => p.YearOfStart)
                .IsRequired();

            modelBuilder.Entity<Publisher>()
                .Property(p => p.Phone)
                .IsRequired();

            modelBuilder.Entity<Publisher>()
                .Property(p => p.Website)
                .IsRequired();

            modelBuilder.Entity<Publisher>()
                .Property(p => p.Address)
                .IsRequired();

            modelBuilder.Entity<Publisher>()
                .Property(p => p.ImageUrl)
                .IsRequired();

            // Translators Configuration
            modelBuilder.Entity<Translator>()
                .Property(t => t.FirstName)
                .IsRequired();

            modelBuilder.Entity<Translator>()
                .Property(t => t.LastName)
                .IsRequired();

            modelBuilder.Entity<Translator>()
                .Property(t => t.ImageUrl)
                .IsRequired();


            modelBuilder.Seed();
        }
    }
}
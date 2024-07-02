using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public static class LibraryContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Aziz", LastName = "Nesin", ImageUrl = "https://shorturl.at/dSvvN" },
                new Author { Id = 2, FirstName = "Ahmet", LastName = "Hamdi Tanpınar", ImageUrl = "https://shorturl.at/FWee3" }
            );

            // Seed Translators
            modelBuilder.Entity<Translator>().HasData(
                new Translator { Id = 1, FirstName = "Aydin", LastName = "Serdarniya", ImageUrl = "https://t.ly/2AbYC" },
                new Translator { Id = 2, FirstName = "Emir", LastName = "Pir", ImageUrl = "https://t.ly/Civ_m" }
            );

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Roman", ImageUrl = "https://shorturl.at/oMPhd" },
                new Category { Id = 2, Name = "Şiir", ImageUrl = "https://shorturl.at/Wmahk" }
            );

            // Seed Publishers
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Nesin YayınEvi", YearOfStart = Convert.ToDateTime("08-10-2006"), ImageUrl = "https://shorturl.at/WZKor", Website = "https://www.nesinyayinevi.com/", Phone = "0212 291 49 89", Address = "Eskişehir Mh. Dolapdere Cd. Şahin Sk. No:84/B-C" },
                new Publisher { Id = 2, Name = "İkaros Yayınları", YearOfStart = Convert.ToDateTime("02-05-1985"), ImageUrl = "https://shorturl.at/I5o91", Website = "https://www.ketebe.com/", Phone = "+90 (212) 467 65 17", Address = "Maltepe mah. Fetih cad. No:6 Topkapı Zeytinburnu / İstanbul" }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Havadan Sudan", ISBN = "4532288-555-5588", Edition = "ilk", YearOfPublication = Convert.ToDateTime("08-10-2023"), Price = 123, Stock = 5, CategoryId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "Huzur", ISBN = "4532288-555-5588", Edition = "ilk", YearOfPublication = Convert.ToDateTime("12-05-2018"), Price = 220, Stock = 14, CategoryId = 2, PublisherId = 2 }
            );

            // Seed BookAuthor
            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { BookId = 1, AuthorId = 1 },
                new BookAuthor { BookId = 2, AuthorId = 2 }
            );

            // Seed BookTranslator
            modelBuilder.Entity<BookTranslator>().HasData(
                new BookTranslator { BookId = 1, TranslatorId = 1 },
                new BookTranslator { BookId = 2, TranslatorId = 2 }
            );

            // Seed Images
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, Url = "http://example.com/havadan_sudan.jpg", BookId = 1 },
                new Image { Id = 2, Url = "http://example.com/huzur.jpg", BookId = 2 }
            );

            // Seed Loans with valid BookId
            modelBuilder.Entity<Loan>().HasData(
                new Loan { Id = 1, RegisterId = 1, BookId = 1, Returned = false, LoanDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(14) },
                new Loan { Id = 2, RegisterId = 2, BookId = 2, Returned = false, LoanDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(14) }
            );

            // Seed Register
            modelBuilder.Entity<Register>().HasData(
                new Register { Id = 1, UserName = "testuser", Password = "Password123!", Email = "testuser@example.com", PhoneNumber = "1234567890", Address = "123 Main St", Website = "http://example.com", Gender = "Male", RegistrationNumber = "REG123456", },
                new Register { Id = 2, UserName = "testuser2", Password = "Password123!", Email = "testuser@example.com", PhoneNumber = "1234567890", Address = "123 Main St", Website = "http://example.com", Gender = "Male", RegistrationNumber = "REG123456", }
            );

            // Seed Notes
            modelBuilder.Entity<Note>().HasData(
                new Note { Id = 1, Content = "Havadan Sudan kitabı için not", CreatedDate = DateTime.Now, RegisterId = 1, LoanId = 1 },
                new Note { Id = 2, Content = "Huzur Sudan kitabı için not", CreatedDate = DateTime.Now, RegisterId = 2, LoanId = 2 }
            );

            // Seed Descriptions
            modelBuilder.Entity<Description>().HasData(
                new Description { Id = 1, Content = "Havadan Sudan kitabı için açıklama", BookId = 1 },
                new Description { Id = 2, Content = "Huzur Sudan kitabı için açıklama", BookId = 2 },
                new Description { Id = 3, Content = "Aziz Nesin için açıklama", AuthorId = 1 },
                new Description { Id = 4, Content = "Ahmet Hamdi Tanpınar için açıklama", AuthorId = 2 }
            );
        }

    }
}

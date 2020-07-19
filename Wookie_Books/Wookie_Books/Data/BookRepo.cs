using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Wookie_Books.Models;

namespace Wookie_Books.Data
{
    public class BookRepo : IBookRepo
    {
        private List<Book> _books;
        public BookRepo()
        {
            _books = new List<Book>()
                {
                    new Book {Id = 1, Title = "abc", Author="abc", CoverImage="https://www.mswordcoverpages.com/wp-content/uploads/2018/10/Book-cover-page-1-CRC.png", Description="abc", Price=99.90F },
                    new Book {Id = 2, Title = "xyz", Author="xyz", CoverImage="https://www.mswordcoverpages.com/wp-content/uploads/2018/10/Book-cover-page-2-CRC.png", Description="xyz", Price=99.90F }
                };
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        public Book AddBook(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
            return book;
        }

        public Book UpdateBook(Book book)
        {
            Book _book = _books.FirstOrDefault(b => b.Id == book.Id);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.Author = book.Author;
                _book.CoverImage = book.CoverImage;
                _book.Price = book.Price;
            }
            return _book;
        }

        public Book DeleteBook(int id)
        {
            Book book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
            return book;
        }
    }
}

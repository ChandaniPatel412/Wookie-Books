using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wookie_Books.Models;

namespace Wookie_Books.Data
{
    public interface IBookRepo
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        Book DeleteBook(int id);
    }
}

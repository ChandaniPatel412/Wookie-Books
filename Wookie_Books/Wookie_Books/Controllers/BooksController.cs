using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wookie_Books.Data;
using Wookie_Books.Models;

namespace Wookie_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;

        public BooksController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = _bookRepo.GetBooks();
            if (books == null)
                return NotFound();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult <Book> Get(int id)
        {
            var book = _bookRepo.GetBook(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult Post(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            Book _book = _bookRepo.AddBook(book);
            if (_book == null)
                return Conflict();
            return Ok(_book);
        }

        [HttpPut]
        public ActionResult Put(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            Book _book = _bookRepo.UpdateBook(book);
            if (_book == null)
                return NotFound();
            return Ok(_book);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Book _book = _bookRepo.DeleteBook(id);
            if (_book == null)
                return NotFound();
            return Ok(_book);
        }
    }
}

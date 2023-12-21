using BookStoreApi.Data;
using BookStoreApi.DTOs;
using BookStoreApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context=context;   
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            List<Book> books = new List<Book>();
            List<BookGetDto>bookdtos=new List<BookGetDto>();
            foreach(var item in bookdtos)
            {
                BookGetDto dto = new BookGetDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                };
                bookdtos.Add(dto);
            }
            return Ok(bookdtos);
        }
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            

           var book=_context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            BookGetDto dto = new BookGetDto()
            {
                Id = book.Id,
                Name = book.Name,
                Price = book.Price,
            };
            return Ok(book);
        }
        [HttpPost]
        //public IActionResult Create(Book book)
        //{
        //    book.CreatedDate = DateTime.UtcNow.AddHours(4);
        //    book.UpdateDate = DateTime.UtcNow.AddHours(4);
        //    book.IsDeleted = false;
        //    _context.Books.Add(book);
        //    _context.SaveChanges();
        //    return StatusCode(201,new {message="object yaradildi" });
        //}
        public IActionResult Create(BookCreateDto dto)
        {
            Book book = new Book()
            {
                Name = dto.Name,
                Price = dto.Price,
            };
            book.CreatedDate = DateTime.UtcNow.AddHours(4);
            book.UpdateDate = DateTime.UtcNow.AddHours(4);
            book.IsDeleted = false;
            _context.Books.Add(book);
            _context.SaveChanges();
            return StatusCode(201, new { message = "object yaradildi" });
        }
        [HttpPut("{id}")]

        public IActionResult Update(int id,BookUpdateDto dto)
        {
            
            Book book = new Book()
            {
                Name = dto.Name,
                Price = dto.Price,

            };
            
            var books = _context.Books.FirstOrDefault(x => x.Id == id);

            
            book.UpdateDate = DateTime.UtcNow.AddHours(4);
            book.IsDeleted = false;
            _context.SaveChanges();
            return NoContent();

        }
        [HttpDelete("delete{id}")]
        public IActionResult Delete(int id)
        {
            var books = _context.Books.FirstOrDefault(x => x.Id == id);
            _context.Remove(id);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

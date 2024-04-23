using REST.Dtos;
using Microsoft.AspNetCore.Mvc;
using Practice.Dtos;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<BookDto> _books = new List<BookDto>();

        private static bool _booksAdded = false;

        public BooksController()
        {
            if (!_booksAdded)
            {
                _books.Add(new BookDto
                {
                    Id = Guid.NewGuid(),
                    Title = "Jungle Book",
                    Author = "Rudyard Kipling",
                    Genre = "Fiction",
                    Price = 200.99m,
                    Pages = 300,
                    ReleaseDate = new DateTime(2022, 1, 1)
                });

                _books.Add(new BookDto
                {
                    Id = Guid.NewGuid(),
                    Title = "Lord of the Rings",
                    Author = "J.R.R. Tolkien",
                    Genre = "Fiction",
                    Price = 900.00m,
                    Pages = 300,
                    ReleaseDate = new DateTime(2022, 1, 1)
                });

                _books.Add(new BookDto
                {
                    Id = Guid.NewGuid(),
                    Title = "Harry Potter",
                    Author = "J.K. Rowling",
                    Genre = "fantasy ",
                    Price = 1500.99m,
                    Pages = 300,
                    ReleaseDate = new DateTime(2022, 1, 1)
                });

                _booksAdded = true;
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> Get()
        {
            return Ok(_books);
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> GetById(Guid id)
        {
            var book = _books.Find(b => b.Id == id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<BookDto> Post(CreateBookDto createBookDto)
        {
            var newBook = new BookDto
            {
                Id = Guid.NewGuid(),
                Title = createBookDto.Title,
                Author = createBookDto.Author,
                Genre = createBookDto.Genre,
                Price = createBookDto.Price,
                Pages = createBookDto.Pages,
                ReleaseDate = createBookDto.ReleaseDate
            };

            _books.Add(newBook);
            return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, UpdateBookDto updateBookDto)
        {
            var existingBook = _books.Find(b => b.Id == id);
            if (existingBook == null)
                return NotFound();

            existingBook.Title = updateBookDto.Title;
            existingBook.Author = updateBookDto.Author;
            existingBook.Genre = updateBookDto.Genre;
            existingBook.Price = updateBookDto.Price;
            existingBook.Pages = updateBookDto.Pages;
            existingBook.ReleaseDate = updateBookDto.ReleaseDate;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var existingBook = _books.Find(b => b.Id == id);
            if (existingBook == null)
                return NotFound();

            _books.Remove(existingBook);

            return NoContent();
        }
    }
}

using DemoRest.Abstraction.Books.Models;
using DemoRest.Abstraction.Books.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            var result = await _bookService.GetBook();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await _bookService.GetBook(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book value)
        {
            var result = await _bookService.AddBook(value);
            if (result.Count < 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Book value)
        {
            var result = await _bookService.UpdateBook(value);
            if (result.Count < 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteBook(id);
            if (result.Count < 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}

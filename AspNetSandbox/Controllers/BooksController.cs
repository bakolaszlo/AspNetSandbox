﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetSandbox
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private static List<Book> books;
        static BooksController()
        {
            books = new List<Book>();
            books.Add(
            new Book
            {
                Id = 1,
                Title = "Az isteni formula",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos"
            });

            books.Add(new Book
            {
                Id = books[0].Id + 1,
                Title = "Az isteni formula2",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos"
            });
        }
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }


        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return books.Single(book => book.Id == id);
        }

        
        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            value.Id = books.Count + 1;
            books.Add(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            books.Remove(Get(id));
        }


    }
}
// <copyright file="DbBooksRepository.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using AspNetSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Services
{
    public class DbBooksRepository : IBookRepository
    {
        private readonly ApplicationDbContext context; 

        public DbBooksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddBook(Book newBook)
        {
            context.Add(newBook);
            context.SaveChanges();
        }

        public List<Book> Get()
        {
            return context.Book.ToList();
        }

        public Book Get(int id)
        {
            var book = context.Book
                .FirstOrDefault(m => m.Id == id);
            return book;
        }

        public void RemoveBookById(int id)
        {
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
        }

        public void UpdateBookById(int id, Book newBook)
        {
            context.Update(newBook);
            context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class BooksServiceTests
    {
        [Fact]
        public void BookIdTests()
        {
        // Assume

        var bookService = new BooksService();

            // Act

            bookService.Post(new Book
            {
                Title = "Az isteni formula3",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos"
            });

            bookService.Delete(2);

            bookService.Post(new Book
            {
                Title = "Az isteni formula4",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos"
            });
            // Assert
            Assert.Equal("Az isteni formula4",bookService.Get(3).Title);

        }
    }
}

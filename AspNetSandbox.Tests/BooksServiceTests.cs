using Xunit;

namespace AspNetSandbox.Tests
{
    public class BooksServiceTests
    {
        [Fact]
        public void BookIdAndRemoveTests()
        {
            // Assume
            var bookService = new BooksService();

            // Act
            bookService.AddBook(new Book
            {
                Title = "Az isteni formula3",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos"
            });

            bookService.RemoveBookById(2);

            bookService.AddBook(new Book
            {
                Title = "Az isteni formula4",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos"
            });
            // Assert
            Assert.Equal("Az isteni formula4",bookService.Get(3).Title);
        }


        [Fact]
        public void BookUpdateTests()
        {
            // Assume
            var bookService = new BooksService();

            // Act
            int workingId = 2;

            Book book = new Book {
                Title = "New Book Title",
                Language = "English",
                Author = "Null"
            };

            bookService.UpdateBookById(workingId, book);

            // Assert
            Assert.Equal("New Book Title", bookService.Get(workingId).Title);
        }

    }
}

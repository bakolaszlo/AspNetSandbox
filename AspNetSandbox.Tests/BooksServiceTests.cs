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
                Author = "José Rodrigues dos Santos",
            });

            bookService.RemoveBookById(3);

            bookService.AddBook(new Book
            {
                Title = "Az isteni formula4",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos",
            });

            // Assert
            Assert.Equal("Az isteni formula4",bookService.Get(4).Title);
        }


        [Fact]
        public void BookUpdateTests()
        {
            // Assume
            var bookService = new BooksService();

            // Act
            Book book = new Book {
                Title = "New Book Title",
                Language = "English",
                Author = "No author",
            };

            Book bookWithoutAuthor = new Book
            {
                Title = "A book without author",
                Language = "Unknown",
            };

            bookService.UpdateBookById(2, book);
            bookService.UpdateBookById(1, bookWithoutAuthor);

            // Assert
            Assert.Equal("New Book Title", bookService.Get(2).Title);
            Assert.Null(bookService.Get(1).Author);
        }
    }
}

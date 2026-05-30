using Xunit;

namespace LibraryManagementSys.Tests {
    public class LibraryTests {
        [Fact]
        public void Test_AddBook() {
            Library lib = new Library();
            Book book = new Book("Test", "Author", "123");
            string result = lib.AddBook(book);
            Assert.Contains("added", result);
            Assert.Single(lib.Books);
        }

        [Fact]
        public void Test_RegisterBorrower() {
            Library lib = new Library();
            Borrower borrower = new Borrower("Rishabh", "C999");
            string result = lib.RegisterBorrower(borrower);
            Assert.Contains("registered", result);
            Assert.Single(lib.Borrowers);
        }

        [Fact]
        public void Test_BorrowBook() {
            Library lib = new Library();
            lib.AddBook(new Book("Book1", "Author", "111"));
            lib.RegisterBorrower(new Borrower("Rishu", "C001"));

            string result = lib.BorrowBook("111", "C001");
            Assert.Contains("borrowed", result);
            Assert.True(lib.Books[0].IsBorrowed);
            Assert.Single(lib.Borrowers[0].BorrowedBooks);
        }

        [Fact]
        public void Test_ReturnBook() {
            Library lib = new Library();
            lib.AddBook(new Book("Book1", "Author", "111"));
            lib.RegisterBorrower(new Borrower("Glory", "C001"));
            lib.BorrowBook("111", "C001");

            string result = lib.ReturnBook("111", "C001");
            Assert.Contains("returned", result);
            Assert.False(lib.Books[0].IsBorrowed);
            Assert.Empty(lib.Borrowers[0].BorrowedBooks);
        }

        [Fact]
        public void Test_ViewBooks() {
            Library lib = new Library();
            lib.AddBook(new Book("B1", "A1", "111"));
            string result = lib.ViewAllBooks();
            Assert.Contains("B1", result);
        }

        [Fact]
        public void Test_ViewBorrowers() {
            Library lib = new Library();
            lib.RegisterBorrower(new Borrower("Raj", "C001"));
            string result = lib.ViewAllBorrowers();
            Assert.Contains("Raj", result);
        }
    }
}
using System.Collections.Generic;

namespace LibraryManagementSys {
    public class Borrower {
        public string Name { get; set; }
        public string LibraryCardNumber { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Borrower(string name, string cardNumber) {
            Name = name;
            LibraryCardNumber = cardNumber;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book) => BorrowedBooks.Add(book);
        public void ReturnBook(Book book) => BorrowedBooks.Remove(book);
    }
}
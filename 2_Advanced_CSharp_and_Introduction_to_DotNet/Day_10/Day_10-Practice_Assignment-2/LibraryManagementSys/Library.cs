using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSys {
    public class Library {
        public List<Book> Books { get; set; }
        public List<Borrower> Borrowers { get; set; }

        public Library() {
            Books = new List<Book>();
            Borrowers = new List<Borrower>();
        }

        public string AddBook(Book book) {
            Books.Add(book);
            return $"Book '{book.Title}' added successfully.";
        }

        public string RegisterBorrower(Borrower borrower) {
            Borrowers.Add(borrower);
            return $"Borrower '{borrower.Name}' registered successfully.";
        }

        public string BorrowBook(string isbn, string cardNumber) {
            Book book = null;
            foreach (var b in Books) {
                if (b.ISBN == isbn) book = b;
            }

            Borrower borrower = null;
            foreach (var br in Borrowers) {
                if (br.LibraryCardNumber == cardNumber) borrower = br;
            }

            if (book == null) return "Book not found.";
            if (borrower == null) return "Borrower not found.";
            if (book.IsBorrowed) return "Book already borrowed.";

            book.Borrow();
            borrower.BorrowBook(book);
            return $"Book '{book.Title}' borrowed by {borrower.Name}.";
        }

        public string ReturnBook(string isbn, string cardNumber) {
            Book book = null;
            foreach (var b in Books) {
                if (b.ISBN == isbn) book = b;
            }

            Borrower borrower = null;
            foreach (var br in Borrowers) {
                if (br.LibraryCardNumber == cardNumber) borrower = br;
            }

            if (book == null) return "Book not found.";
            if (borrower == null) return "Borrower not found.";
            if (!book.IsBorrowed) return "Book was not borrowed.";

            book.Return();
            borrower.ReturnBook(book);
            return $"Book '{book.Title}' returned by {borrower.Name}.";
        }

        public string ViewAllBooks() {
            if (Books.Count == 0) return "No books in library.";
            string result = "=== All Books ===\n";
            foreach (var book in Books) {
                result += $"{book.Title} by {book.Author} (ISBN: {book.ISBN}) - ";
                if (book.IsBorrowed) result += "Borrowed\n";
                else result += "Available\n";
            }
            return result;
        }

        public string ViewAllBorrowers() {
            if (Borrowers.Count == 0) return "No borrowers registered.";
            string result = "=== All Borrowers ===\n";
            foreach (var borrower in Borrowers) {
                result += $"{borrower.Name} (Card: {borrower.LibraryCardNumber}) - Borrowed: ";
                if (borrower.BorrowedBooks.Count == 0) result += "None\n";
                else {
                    foreach (var b in borrower.BorrowedBooks) {
                        result += b.Title + " ";
                    }
                    result += "\n";
                }
            }
            return result;
        }
    }
}
using System;

namespace LibraryManagementSys {
    class Program {
        static void Main() {
            Library lib = new Library();

            lib.AddBook(new Book("Wings of Fire", "Rohan", "111"));
            lib.AddBook(new Book("The White Tiger", "Rahul", "222"));
            lib.RegisterBorrower(new Borrower("Ronky", "C001"));
            lib.RegisterBorrower(new Borrower("Prashasti", "C002"));

            while (true) {
                Console.WriteLine("\n1.Add Book 2.Register 3.Borrow 4.Return 5.View Books 6.View Borrowers 7.Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                if (choice == "1") {
                    Console.Write("Title,Author,ISBN: ");
                    string input = Console.ReadLine();
                    string[] parts = input.Split(',');
                    if (parts.Length == 3)
                        Console.WriteLine(lib.AddBook(new Book(parts[0], parts[1], parts[2])));
                }
                else if (choice == "2") {
                    Console.Write("Name,CardNumber: ");
                    string input = Console.ReadLine();
                    string[] parts = input.Split(',');
                    if (parts.Length == 2)
                        Console.WriteLine(lib.RegisterBorrower(new Borrower(parts[0], parts[1])));
                }
                else if (choice == "3") {
                    Console.Write("ISBN,CardNumber: ");
                    string input = Console.ReadLine();
                    string[] parts = input.Split(',');
                    if (parts.Length == 2)
                        Console.WriteLine(lib.BorrowBook(parts[0], parts[1]));
                }
                else if (choice == "4") {
                    Console.Write("ISBN,CardNumber: ");
                    string input = Console.ReadLine();
                    string[] parts = input.Split(',');
                    if (parts.Length == 2)
                        Console.WriteLine(lib.ReturnBook(parts[0], parts[1]));
                }
                else if (choice == "5")
                    Console.WriteLine(lib.ViewAllBooks());
                else if (choice == "6")
                    Console.WriteLine(lib.ViewAllBorrowers());
                else if (choice == "7")
                    break;
            }
        }
    }
}
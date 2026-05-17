namespace _4_Generics;

class Program {
    static void Main() {
        // Box with int
        Box<int> marks = new Box<int>();
        marks.Store(85);
        marks.DisplayType();
        Console.WriteLine($"Marks: {marks.Retrieve()}\n");

        // Box with string (Indian name)
        Box<string> name = new Box<string>();
        name.Store("Arjun");
        name.DisplayType();
        Console.WriteLine($"Name: {name.Retrieve()}\n");

        // Box with Student (Indian names)
        Box<Student> student1 = new Box<Student>();
        student1.Store(new Student("Priya"));
        student1.DisplayType();
        Console.WriteLine($"Student: {student1.Retrieve()}\n");

        Box<Student> student2 = new Box<Student>();
        student2.Store(new Student("Rohan"));
        student2.DisplayType();
        Console.WriteLine($"Student: {student2.Retrieve()}\n");

        // Box with another Indian name
        Box<string> city = new Box<string>();
        city.Store("Mumbai");
        city.DisplayType();
        Console.WriteLine($"City: {city.Retrieve()}\n");
    }
}
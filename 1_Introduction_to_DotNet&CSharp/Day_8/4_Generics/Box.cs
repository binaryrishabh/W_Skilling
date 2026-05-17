namespace _4_Generics;

public class Box<T> {
    private T _item;

    public void Store(T item) {
        _item = item;
    }

    public T Retrieve() {
        return _item;
    }

    public void DisplayType() {
        Console.WriteLine($"Storing type: {typeof(T).Name}");
    }
}
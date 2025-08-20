using System;
public abstract class DataStructures<T>
{
    // Displays the contents of the data structure in a readable format
    public abstract void Display();
    // Defines all necessary members for data structures, ensuring abstraction
}
public abstract class LinearData<T> : DataStructures<T>
{
    // Defines all necessary members for linear data structures, ensuring abstraction
}
public class SmartArray<T> : LinearData<T>
{
    private T[] Elements;

    // Property to get the size of the array
    public int Size { get; }

    // Constructor to create an array with a specified size
    public SmartArray(int size)
    {
        if (size <= 0) throw new ArgumentException("Size must be greater than zero.");
        Size = size;
        try
        {
            Elements = new T[size];
        }
        catch (OutOfMemoryException)
        {
            throw new InvalidOperationException("Not enough memory to allocate the array.");
        }
    }
    ~SmartArray()
    {
        Console.WriteLine("The SmartArray Destructor");
        Elements = null;
    }

    // Method to check if the index is within valid bounds
    private void InBounds(int index)
    {
        if (index < 0 || index >= Size)
            throw new IndexOutOfRangeException("Index is out of bounds.");
    }
    // Indexer to access elements in the array
    public T? this[int index]
    {
        get
        {
            InBounds(index);  // Validate index
            return Elements[index];
        }
        set
        {
            InBounds(index);  // Validate index
            Elements[index] = value;
        }
    }
    // Override Display method to show array contents
    public override void Display()
    {
        Console.Write("Array Elements: ");
        for (int i = 0; i < Size; i++)
        {
            Console.Write(Elements[i] != null ? Elements[i].ToString() : "Empty Element.");
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        try
        {
            // Create a SmartArray<int> with a size of 5
            SmartArray<int?> IntArray = new SmartArray<int?>(5);
            // Initialize the array with values
            for (int i = 0; i < IntArray.Size - 1; i++)
            {
                IntArray[i] = i * 10; // Assigning values
            }
            // Display the array contents
            IntArray.Display();
            // Attempt to access an out-of-bounds index
            Console.WriteLine(IntArray[10]); // This will throw an exception
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Argument Error: {ex.Message}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Index Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Operation Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Execution completed.");
        }

    }
}

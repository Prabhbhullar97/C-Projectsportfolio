
using System;

namespace PolymorphismAssignment
{
    // 1. Create an interface called IQuittable
    // An interface defines a contract that other classes must follow
    public interface IQuittable
    {
        // Define a void method called Quit() that takes no parameters
        void Quit();
    }

    // 2. Have your Employee class inherit the interface and implement the Quit() method
    // The ':' symbol is used here for interface implementation
   public class Employee : IQuittable
{
    public string? FirstName { get; set; } // The '?' removes the warning
    public string? LastName { get; set; }
    
    public void Quit()
    {
        Console.WriteLine($"{FirstName} {LastName} has officially quit the project.");
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            // 3. Use polymorphism to create an object of type IQuittable
            // Even though 'Employee' is the class, we can type it as 'IQuittable' 
            // because Employee implements that interface.
            IQuittable quitter = new Employee() 
            { 
                FirstName = "Student", 
                LastName = "User" 
            };

            // Call the Quit() method on the IQuittable object
            // This demonstrates polymorphism: calling a method defined in the interface
            quitter.Quit();

            // Prevents the console from closing immediately
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
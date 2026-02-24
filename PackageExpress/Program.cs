using System;

namespace PackageExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Required welcome line (must be exactly as specified)
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            // 2. Prompt the user for package weight
            Console.WriteLine("Please enter the package weight:");
            string weightInput = Console.ReadLine(); // read input as string

            // Try to parse the weight as an integer. If parsing fails, show an error and exit.
            // (Assignment didn't require this, but it makes the program robust.)
            if (!int.TryParse(weightInput, out int weight))
            {
                Console.WriteLine("Invalid input for weight. Program will exit.");
                return; // end program
            }

            // 3. If the weight is greater than 50, show the specified error message and end.
            if (weight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return; // end program
            }

            // 4. Prompt for package width
            Console.WriteLine("Please enter the package width:");
            string widthInput = Console.ReadLine();

            if (!int.TryParse(widthInput, out int width))
            {
                Console.WriteLine("Invalid input for width. Program will exit.");
                return;
            }

            // 5. Prompt for package height
            Console.WriteLine("Please enter the package height:");
            string heightInput = Console.ReadLine();

            if (!int.TryParse(heightInput, out int height))
            {
                Console.WriteLine("Invalid input for height. Program will exit.");
                return;
            }

            // 6. Prompt for package length
            Console.WriteLine("Please enter the package length:");
            string lengthInput = Console.ReadLine();

            if (!int.TryParse(lengthInput, out int length))
            {
                Console.WriteLine("Invalid input for length. Program will exit.");
                return;
            }

            // 7. Check if the total of width + height + length is greater than 50
            // If so, display the specified error message and end.
            int dimensionSum = width + height + length;
            if (dimensionSum > 50)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
                return; // end program
            }

            // 8. Multiply the three dimensions together (volume-like), multiply by weight, then divide by 100
            // Use double to preserve decimal if necessary.
            double productOfDimensions = (double)width * height * length;
            double quoteValue = (productOfDimensions * weight) / 100.0;

            // 9 & 10. Display the result as a dollar amount (two decimal places),
            // then print the "Thank you!" line.
            Console.WriteLine("Your estimated total for shipping this package is: ${0:F2}", quoteValue);
            Console.WriteLine("Thank you!");
        }
    }
}

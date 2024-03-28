using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TwitterTowers_Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            while (choice != 3)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Rectangle Tower");
                Console.WriteLine("2. Triangle Tower");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the height of the rectangle tower: ");
                        double heightRectangle = double.Parse(Console.ReadLine());
                        Console.Write("Enter the width of the rectangle tower: ");
                        double widthRectangle = double.Parse(Console.ReadLine());

                        //In case the difference is greater than 5 or it is a square, print an area
                        if (Math.Abs(heightRectangle - widthRectangle) > 5 || heightRectangle == widthRectangle)
                        {
                            Console.WriteLine($"Area of the rectangle tower: {heightRectangle * widthRectangle}");
                        }
                        //Otherwise we will print Perimeter
                        else
                        {
                            Console.WriteLine($"Perimeter of the rectangle tower: {(2 * heightRectangle) + (2 * widthRectangle)}");
                        }

                        break;
                    case 2:
                        Console.WriteLine("Choose an option:");
                        Console.WriteLine("1. Calculate the perimeter of the triangle tower");
                        Console.WriteLine("2. Print the triangle tower");
                        Console.Write("Enter your choice: ");
                        int triangleChoice = int.Parse(Console.ReadLine());

                        Console.Write("Enter the height of the triangle tower: ");
                        int heightTriangle = int.Parse(Console.ReadLine());
                        Console.Write("Enter the length of the triangle tower: ");
                        int lengthTriangle = int.Parse(Console.ReadLine());

                        if (triangleChoice == 1)
                        {
                            Console.WriteLine($"Perimeter of the triangle tower: {lengthTriangle + Math.Sqrt((Math.Pow(lengthTriangle / 2, 2) + Math.Pow(heightTriangle, 2))) * 2}");
                        }
                        else if (triangleChoice == 2)
                        {
                            //In case the width is odd and the width is not greater than twice the height
                            if (lengthTriangle % 2 != 0 && lengthTriangle < 2 * heightTriangle)
                            {

                                //Checking how many odd numbers we have besides the first and last row
                                int numOptions = 0;
                                for (int i = 3; i <= lengthTriangle - 2; i += 2)
                                {
                                    numOptions++;
                                }
                                if(numOptions != 0)
                                {
                                    //How many rows does each odd number need?
                                    int count = (heightTriangle - 2) / numOptions;
                                    //the remaining balance
                                    int balance = (heightTriangle - 2) % numOptions;

                                    //Printing the tower top
                                    Console.Write(new string(' ', lengthTriangle / 2));
                                    Console.WriteLine(new string('*', 1));

                                    //Printing in case of a remainder
                                    if (balance > 0)
                                    {
                                        for (int i = 0; i < balance; i++)
                                        {
                                            Console.Write(new string(' ', lengthTriangle / 2 - 1));
                                            Console.WriteLine(new string('*', 3));
                                        }

                                    }

                                    int star = 3;
                                    //Print the rest of the lines
                                    for (int i = numOptions; i >= 1; i--)
                                    {
                                        for (int j = 0; j < count; j++)
                                        {
                                            int numOfSpaces = (i);
                                            Console.Write(new string(' ', numOfSpaces));
                                            Console.WriteLine(new string('*', star));
                                        }
                                        star += 2;
                                    }
                                }

                                //In case the width is 3
                                else
                                {
                                    Console.Write(new string(' ', 1));
                                    Console.WriteLine(new string('*', 1));
                                    for (int i = 2; i < heightTriangle; i++)
                                    {
                                       Console.WriteLine(new string('*', 3));
                                    }
                                }

                                

                                Console.WriteLine(new string('*', lengthTriangle));

                            }
                            else
                            {
                                Console.WriteLine("Cannot print the triangle tower with the given height.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        break;
                }
            }
        }
    }
}
using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Boolean value to act as the on/off switch for the program/loop -- dependant on user input
            bool isRunning;

            do
            {
                // Variables
                string userName = UserInput.GetUserName();
                int num = Math.Abs(UserInput.GetUserNumber(userName));
                bool isEven = IsNumEven(num);

                // if int is odd and greater than 60  print "num and odd"
                if (!(isEven) && num > 60)
                {
                    Console.WriteLine($"{userName}'s Number is {num} and Odd");
                }
                // if int is even and between 2 to 25 print "even and less than 25"
                else if (isEven && (num > 1 && num <= 25))
                {
                    Console.WriteLine($"{userName}'s Number is Even and less than 25");
                }
                // if int is even and between 26 and 60 print "even"
                else if (isEven && (num >= 26 && num <= 60))
                {
                    Console.WriteLine($"{userName}'s Number is Even");
                }
                // if int is even and greater than 60  print "num and even"
                else if (isEven && num > 60)
                {
                    Console.WriteLine($"{userName}'s Number is {num} and Even");
                }
                // If int is odd print "odd"
                else if (!isEven)
                {
                    Console.WriteLine($"{userName}'s Number is Odd");
                }
                // Ask the user if they would like to play again
                isRunning = PlayAgain(userName);
                // If the user decided not to play again give the a warm goodbye!
                if (!isRunning)
                {
                    Console.WriteLine($"Thanks for playing {userName}! Goodbye!");
                }
            } while (isRunning);
        }
        // Use of a seperate class for the main user input of the program (userName and userNumber)
        // Number validation is also done here
        private static class UserInput
        {
            public static string GetUserName()
            {
                // Give the user instruction / ask for input
                Console.WriteLine("Hello there! What is your name?");
                string userName = Console.ReadLine();
                return userName;
            }
            // Ask user to input a number
            public static int GetUserNumber(string userName)
            {
                Console.Write($"Hello {userName}! Please enter a number between 1 and 100: ");
                string userNumber = Console.ReadLine().Trim();
                // Runs validation method and if true returns the user number
                if (IsValidNumberAndInRange(userNumber))
                {
                    return int.Parse(userNumber);
                }
                Console.WriteLine($"Sorry {userName} but you must input a number between 1 and 100...");
                // if input is not a valid number inform the user and ask for input again
                return GetUserNumber(userName);
            }
            // Seperate method to validate that the input is a number and that the range falls between 1 and 100
            public static bool IsValidNumberAndInRange(string userNumber)
            {
                return int.TryParse(userNumber, out int numOut) && (numOut >= 1 && numOut <= 100);
            }
        }
        // Method to determine wether input is odd or even
        private static bool IsNumEven(int num)
        {
            if (num % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Method to as if the user if they would like to run the program again
        public static bool PlayAgain(string userName)
        {
            Console.WriteLine("Continue? (y/n)");
            try
            {
                char runAgain = Convert.ToChar(Console.ReadLine().ToLower().Trim());
                if (runAgain == 'y')
                {
                    return true;
                }
                else if (runAgain == 'n')
                {
                    return false;
                }
                return PlayAgain(userName);
            }
            catch (Exception)
            {
                return PlayAgain(userName);
            }
        }
    }
}

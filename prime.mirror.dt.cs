using System;

namespace SimpleFactoryExample
{
    public interface INumberOperation
    {
        void Execute();
    }

    public class PrimeNumberOperation : INumberOperation
    {
        public void Execute()
        {
            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number < 1000)
                {
                    Console.WriteLine("Checking for primes below 1000...");
                    CheckPrimesBelow1000();
                }
                else
                {
                    Console.WriteLine("Checking for primes 1000 and above...");
                    CheckPrimesAbove1000(number);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        private void CheckPrimesBelow1000()
        {
            for (int i = 2; i < 1000; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private void CheckPrimesAbove1000(int number)
        {
            if (IsPrime(number))
            {
                Console.WriteLine($"{number} is a prime number.");
            }
            else
            {
                Console.WriteLine($"{number} is not a prime number.");
            }
        }

        private bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }

    public class PalindromeNumberOperation : INumberOperation
    {
        public void Execute()
        {
            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number < 1000)
                {
                    Console.WriteLine("Checking for palindromes below 1000...");
                    CheckPalindromesBelow1000();
                }
                else
                {
                    Console.WriteLine("Checking for palindromes 1000 and above...");
                    CheckPalindrome(number);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        private void CheckPalindromesBelow1000()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (IsPalindrome(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private void CheckPalindrome(int number)
        {
            if (IsPalindrome(number))
            {
                Console.WriteLine($"{number} is a palindrome.");
            }
            else
            {
                Console.WriteLine($"{number} is not a palindrome.");
            }
        }

        private bool IsPalindrome(int num)
        {
            string str = num.ToString();
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return str == new string(arr);
        }
    }

    public class DecisionTreeOperation : INumberOperation
    {
        public void Execute()
        {
            Console.WriteLine("Answer the following questions with 'yes' or 'no':");

            if (AskQuestion("Is it an animal?"))
            {
                if (AskQuestion("Is it a mammal?"))
                {
                    if (AskQuestion("Does it have stripes?"))
                    {
                        Console.WriteLine("It's a tiger!");
                    }
                    else
                    {
                        Console.WriteLine("It's a dog!");
                    }
                }
                else
                {
                    Console.WriteLine("It's a reptile!");
                }
            }
            else
            {
                Console.WriteLine("It's a rock!");
            }
        }

        private bool AskQuestion(string question)
        {
            Console.Write($"{question} ");
            string answer = Console.ReadLine()?.ToLower();
            return answer == "yes";
        }
    }

    public static class NumberOperationFactory
    {
        public static INumberOperation CreateOperation(int choice)
        {
            switch (choice)
            {
                case 1:
                    return new PrimeNumberOperation();
                case 2:
                    return new PalindromeNumberOperation();
                case 3:
                    return new DecisionTreeOperation();
                default:
                    throw new ArgumentException("Invalid choice.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Prime Number Operation");
            Console.WriteLine("2. Palindrome Number Operation");
            Console.WriteLine("3. Decision Tree Operation");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                try
                {
                    INumberOperation operation = NumberOperationFactory.CreateOperation(choice);
                    operation.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}

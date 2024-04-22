using System;

namespace cs2_app
{
    public class wrongGuessException : Exception
    {
        public wrongGuessException(string message) : base(message) 
        { 
        //Console.WriteLine(message);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int attempts;
            bool success;
            Random rnd = new Random();

            Console.WriteLine("[Number guesser]");
            int target = rnd.Next(101) + 1;
            attempts = 10;
            success = false;
            Console.WriteLine("Hello! We have generated a random number from 1 to 100! Try guessing it.");
            while (attempts > 0 && success == false)
            {
                try
                {
                    Console.WriteLine($"You have {attempts} attempt(s) left, guess carefully:");
                    int guess = int.Parse(Console.ReadLine());
                    if (guess > target)
                    {
                    throw new wrongGuessException($"You guessed wrong, it is lesser than {guess}");
                    } 
                    else if (guess < target)
                    {
                    throw new wrongGuessException($"You guessed wrong, it is greater than {guess}");
                    }
                    else
                    {
                        success = true;
                    }
                }
                catch (wrongGuessException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception) 
                { 
                    Console.WriteLine("That guess was invalid. We have looked it over, make a valid guess next time.");
                    attempts++;
                }
                attempts--;
            }

            if (success)
            {
                Console.WriteLine($"Bingo! Bullseye! Right on the money! You guessed it just right\n" +
                    $"You had {attempts} attempt(s) left, good job!\n");
            }
            else
            {
                Console.WriteLine($"It seems like it's your unlucky day today... the number was {target}\n" +
                    $"Better luck next time!");
            }
            Console.ReadLine();
        }
    }
}

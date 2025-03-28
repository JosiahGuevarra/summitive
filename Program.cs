using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace summitive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            int aiRand;
            double winnings, bet;
            string userPick,ai,again;
            bool done = false;
            
            Random generator = new Random();
            winnings = 50;

            Console.Beep(500, 1000);
            Console.WriteLine("Welcome to Josiah's cassino!!!");
            Console.WriteLine();
            Console.WriteLine("We will be playing Rock,Paper,Scissors!");

            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("You currently have $" + winnings);
                Console.WriteLine();
                Console.WriteLine("How much would you like to bet?");
                Console.WriteLine();
                double.TryParse(Console.ReadLine(), out bet);

                while (bet < 1 || bet > winnings)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Invalid bet, please try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    double.TryParse(Console.ReadLine(), out bet);
                    

                }
                Console.Clear();
                Console.WriteLine("Please select one of the following");
                Console.WriteLine();
                Console.WriteLine("1.Rock   2.Paper   3.Scissors");
                Console.WriteLine();
                userPick = Console.ReadLine().ToLower();

                while  (userPick != "rock" && userPick != "paper" && userPick != "scissors")
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Invaild input");
                    Console.WriteLine("Please make sure you pick rock paper or scissors");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    userPick = Console.ReadLine().ToLower();
                }
                aiRand = generator.Next(1, 4);
                if (aiRand == 1)
                    ai = "rock";
                else if (aiRand == 2)
                    ai = "paper";
                else  ai = "scissors";
                
                Console.WriteLine("The house picked " + ai);
                if (userPick == ai)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine("You tied, you keep your money");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else if
                    ((userPick == "rock" && ai == "scissors") ||
                    (userPick == "paper" && ai == "rock") ||
                    (userPick == "scissors" && ai == "paper"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You WON!");
                    winnings += bet;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lost");
                    Console.ForegroundColor = ConsoleColor.White;
                    winnings -= bet; 
                }



                if (winnings <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have no more money, you lose");
                    Console.WriteLine("Thanks for playing");
                    Console.ForegroundColor = ConsoleColor.White;
                    done = true;
                }
                else
                {
                    Console.WriteLine("Would you like to play again?");
                    Console.WriteLine("yes or no");
                    again = Console.ReadLine().ToLower();
                    if (again == "yes" || again == "y")
                    {
                        done = false;
                        Console.Clear();
                    }
                    else
                        
                    if (again == "no"|| again == "n") 
                    {
                        done = true;
                        Console.WriteLine("Thanks for playing");
                        Console.ReadLine();
                    }
                }


            }










        }
    }
}

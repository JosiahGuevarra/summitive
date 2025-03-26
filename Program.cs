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

            int rock, paper, scissors,ai;
            double winnings, bet;
            string userPick;
            bool done = false;
            rock = 1;
            paper = 2;
            scissors = 3;
            Random generator = new Random();
            winnings = 50;


            Console.WriteLine("Welcome to Josiah's cassino!!!");
            Console.WriteLine();
            Console.WriteLine("We will be playing Rock,Paper,Scissors!");

            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("you currently have $" + winnings);
                Console.WriteLine();
                Console.WriteLine("how much would you like to bet?");
                Console.WriteLine();
                double.TryParse(Console.ReadLine(), out bet);

                while (bet < 1 || bet > winnings)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Invalid bet, please try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    double.TryParse(Console.ReadLine(), out bet);
                    Console.Clear();

                }
                Console.Clear();
                Console.WriteLine("Please select one of the following");
                Console.WriteLine();
                Console.WriteLine("1.Rock   2.Paper   3.Scissors");
                Console.WriteLine();
                userPick = Console.ReadLine().ToLower();

                if (userPick != "rock" || userPick != "paper" || userPick != "scissors")
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Invaild input");
                    Console.WriteLine("please make sure you pick rock paper or scissors");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                }
                ai = generator.Next(1, 4);
                

            }
            

            
             

            
            

           
            
        }
    }
}

using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace summitive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            double winnings, bet;
            string rock, paper, scissors;



            winnings = 50;
            
            
           while (winnings == 0)
            {
                Console.WriteLine("you currently have $" + winnings);
                Console.WriteLine("how much would you like to bet?");
                Console.ReadLine();
                bet = Convert.ToDouble(Console.ReadLine());
                if (bet == 0 || bet < 0|| bet > winnings)
                {
                    Console.WriteLine("Bet invalid, please try again")
                }


            }
            

            
            

           
            
        }
    }
}

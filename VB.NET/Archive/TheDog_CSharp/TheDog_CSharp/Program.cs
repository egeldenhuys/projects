using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheDog_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string tmp;

            Console.WriteLine("Would you like to play a game?");
            Console.Write(">");

            tmp = Console.ReadLine();
            tmp = tmp.ToLower();

            if (tmp == "yes")
            {
                Console.WriteLine("You see a dog standing infront of you. What do you do?");
                Console.Write(">");

                tmp = Console.ReadLine();
                tmp = tmp.ToLower();

                switch (tmp)
                {
                    case "kill it":
                        Console.WriteLine("You kick the poor dog to death. Are you happy now?");
                        break;

                    case "run away":
                        Console.WriteLine("You turn around to run away but you hit your head on the toilet seat. You are dead.");
                        break;


                    default:
                        Console.WriteLine("You do not know how to do that, so instead you wet your pants.");
                        break;
                } // End switch

            } // End if

            Console.WriteLine(Environment.NewLine + "Press any key to exit...");

            Console.ReadKey(true);





        }
    }
}

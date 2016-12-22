using System;
using System.Threading;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            int balance = 100;

            do
            {
                //Choices, random and balance
                Random random = new Random();

                Console.Clear();
                Console.WriteLine("Your balance is {0}.", balance);
                Console.WriteLine("Please put in the amount you want to bet with.");
                int bet = Convert.ToInt32(Console.ReadLine());
                if (bet > balance)
                {
                    Console.WriteLine("You do not have enough balance to but this amount.");
                    Console.WriteLine("Please put in a bet you can affort.");
                    Console.WriteLine(" ");
                    continue;
                }
                else if (bet == 0)
                {
                    Console.WriteLine("You are playing this round for no money, would you like to continue?");
                    Console.WriteLine("Y/N");
                    var freeround = Console.ReadLine();
                    if (freeround == "N" && freeround == "n")
                    {
                        continue;
                    }
                    else if (freeround != "N" && freeround != "n" && freeround != "Y" && freeround != "y")
                    {
                        Console.WriteLine("Please put in Y or N.");
                        var secondfreeround = Console.ReadLine();
                        if (secondfreeround != "N" && secondfreeround != "n" && secondfreeround != "Y" && secondfreeround != "y")
                        {
                            Console.WriteLine("You did not fill in a correct answer again, we will be restarting the game now.");
                            Thread.Sleep(5000);
                            Console.Clear();
                            continue;
                        }
                    }
                }

                balance -= bet;

                // var balance = (balance - bet);

                Console.Clear();
                Console.WriteLine("You are playing with {0} credits and your balance is now {1}", bet, balance);
                Console.WriteLine(" ");
                Console.WriteLine("Please put in the number, press enter, and then the colour you think it is gonna be.");

                int choice = Convert.ToInt32(Console.ReadLine());
                string brchoice = Console.ReadLine();

                //Leave the program
                if (brchoice == "exit")
                {
                    return;
                }

                //Good answers

                if (choice >= 37)
                {
                    Console.WriteLine("Sorry, your number has to be between 0 and 36.");
                    Console.WriteLine("You can try it again.");
                    Console.WriteLine(" ");
                    continue;

                }
                if (brchoice != "black" && brchoice != "green" && brchoice != "red" && brchoice != null)
                {
                    Console.WriteLine("Sorry, you have to choose between black, red or green.");
                    Console.WriteLine("You can try it again.");
                    Console.WriteLine(" ");
                    continue;
                }

                Console.WriteLine(" ");
                string br = "kleur";

                //The roll and the colour decision begins here

                int roulette = random.Next(0, 37);

                if (roulette == 0)
                {
                    br = br.Replace("kleur", "green");
                }
                else if (roulette > 0 && roulette < 19)
                {
                    br = br.Replace("kleur", "red");
                }
                else
                {
                    br = br.Replace("kleur", "black");
                }

                Console.WriteLine("And the number is");
                Console.WriteLine(".....");
                Console.WriteLine(".....");
                Console.WriteLine("{0} {1}", roulette, br);


                //The winnings begin here

                if (roulette == choice)
                {
                    Console.WriteLine("You have won 36 times your money!");
                    var numberwon = bet * 36;
                    balance += numberwon;
                }

                if (br == brchoice)
                {
                    Console.WriteLine("You have won 2 times your money!");
                    var colorwon = bet * 2;
                    balance += colorwon;
                }

                else
                {
                    Console.WriteLine("Sorry, you did not guess the right number or color. Good luck on the next roll!");
                }

                Thread.Sleep(7000);
            } while (true);
        }

        public string Replace(string oldValue, string newValue)
        {
            return "";
        }
    }
}
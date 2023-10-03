using System.Collections;

namespace Individuellt_projekt___Internetbank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bankRunning = true;

            while (bankRunning)
            {
                for (int i = 1; i < 4; i++) 
                {
                    Console.Write("Enter pin: ");
                    int pin = int.Parse(Console.ReadLine());
                    int x = LogIn(pin);
                    if (i == 3)
                    {
                        bankRunning = false;
                    }
                    while (x == 0)
                    {
                        var balance = 0;
                        backToMenu:
                        Console.WriteLine("Welcome to BigBank");
                        Console.WriteLine("Press [1] to view balance");
                        Console.WriteLine("Press [2] to transfer funds");
                        Console.WriteLine("Press [3] to withdrawal funds");
                        Console.WriteLine("Press [4] to log out");
                        var menuOption = int.Parse(Console.ReadLine());
                        switch (menuOption)
                        {
                            case 1:
                                Console.WriteLine("Your current balance is " + balance);
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                try
                                {
                                    Console.WriteLine("Are you sure you want to log out? Press [y] to log out / Press [n] to return to menu");
                                    var exitOption = Console.ReadLine();
                                    if (exitOption.ToLower() == "y")
                                    {
                                        Console.WriteLine("Goodbye!");
                                        Console.Read();
                                        bankRunning = false;
                                    }
                                    else if (exitOption.ToLower() == "n")
                                    {
                                        goto backToMenu;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Console.Write("Press anykey to return");
                                    Console.Read();
                                }
                                break;
                        }

                    }
                    Console.WriteLine("Please try again, you have " + (3 - i) + " attempts left!");
                }
            }
        }
        static int LogIn(int pin)
        {
            if (pin == 1234)
            {
                int x = 0;
                return x;
            }
            else
            {
                int x = 1;
                return x;
            }
        }
    }
}
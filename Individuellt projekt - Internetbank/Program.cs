using System.Collections;
using System.Security.Principal;

namespace Individuellt_projekt___Internetbank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bankRunning = true;
            string[] userVektor = new string[] {"Torbjörn","Albin","Lovisa","Karin","Daniel"};
            double[] userPayrollAccount = new double[] {10000.50, 1000.50,100.50,10.50,1.50};
            double[] userSavingsAccount = new double[] { 20000.50, 2000.50, 200.50, 20.50};

            while (bankRunning)
            {
                for (int i = 1; i < 4; i++) 
                {
                    Console.Write("Enter pin: ");
                    int pin = int.Parse(Console.ReadLine());
                    int user = LogIn(pin);
                    if (i == 3)
                    {
                        bankRunning = false;
                    }
                    while (user == 0|| user == 1 || user == 2 || user == 3 || user == 4)
                    {
                        var balance = 0;
                        backToMenu:
                        Console.WriteLine("Welcome " + userVektor[user] + " to BigBank");
                        Console.WriteLine("Press [1] to view balance");
                        Console.WriteLine("Press [2] to transfer funds");
                        Console.WriteLine("Press [3] to withdrawal funds");
                        Console.WriteLine("Press [4] to log out");
                        var menuOption = int.Parse(Console.ReadLine());
                        switch (menuOption)
                        {
                            case 1:
                                Console.WriteLine("Your current balance is " + userPayrollAccount[user]);
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
                int user = 0;
                return user;
            }
            else if (pin == 1235)
            {
                int user = 1;
                return user;
            }
            else if (pin == 1236)
            {
                int user = 2;
                return user;
            }
            else if (pin == 1237)
            {
                int user = 3;
                return user;
            }
            else if (pin == 1238)
            {
                int user = 4;
                return user;
            }
            else
            {
                int user = 5;
                return user;
            }
        }
    }
}
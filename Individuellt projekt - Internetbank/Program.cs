using System.Collections;
using System.Security.Principal;

namespace Individuellt_projekt___Internetbank
{
    
    internal class Program
    {
        static double[][] usersAccounts = new double[][]
        {
        new double[] {10000.50, 1000.50,100.50,10.50,1.50},
        new double[] { 20000.50, 2000.50, 200.50, 20.50 },
        new double[] { 10000.50, 1000.50, 100.50 },
        new double[] { 10000.50, 1000.50 },
        new double[] { 10000.50 }
        };
        static string[] usersName = { "Torbjörn", "Albin", "Lovisa", "Karin", "Daniel" };
        static string[] Accounts = { "1. CheckingAccount: ", "2. SavingsAccount: ", "3. HolidayAccount: ", "4. EvrydayAccount: ", "5. RainyDayFunds: " };
        static void Main(string[] args)
        {
            bool bankRunning = true;
            
            while (bankRunning)
            {
                for (int i = 1; i < 4; i++) 
                {
                    Console.WriteLine("Welcome to HappyBank");
                    Console.WriteLine("Please enter cardnumber and pin to log in...");
                    Console.Write("Enter card number:");
                    int cardNumber = int.Parse(Console.ReadLine());
                    Console.Write("Enter pin: ");
                    int pin = int.Parse(Console.ReadLine());
                    int user = LogIn(pin,cardNumber);
                    if (i == 3)
                    {
                        bankRunning = false;
                    }


                    while (user == 0|| user == 1 || user == 2 || user == 3 || user == 4)
                    {
                        Console.Clear();
                        backToMenu:

                        Console.WriteLine($"Current user: {usersName[user]}");
                        Console.WriteLine("Press [1] to view balance");
                        Console.WriteLine("Press [2] to transfer funds");
                        Console.WriteLine("Press [3] to withdrawal funds");
                        Console.WriteLine("Press [4] to log out");
                        Console.Write("Select Option 1-4: ");
                        int menuOption = 0;
                        try 
                        {
                            menuOption = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Clear() ;
                            Console.WriteLine("Please enter a Option between 1-4");
                            Console.Write("Press enter to return to main menu...");
                            Console.ReadKey();
                        }
                        switch (menuOption)
                        {
                            case 1:

                                Console.Clear();
                                ViewBalance(user);
                                Console.Write("Press enter to return to main menu...");
                                Console.ReadKey();

                                break;
                            case 2:
                                try
                                {
                                    TransferFunds(user);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Console.ReadKey();
                                }
                                break;
                            case 3:
                                try
                                {
                                    Withdrawal(user);
                                }
                                catch (Exception ex)
                                { 
                                    Console.WriteLine(ex.Message); 
                                    Console.ReadKey();
                                }
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
                                }
                                break;
                        }

                    }
                    Console.WriteLine("Please try again, you have " + (3 - i) + " attempts left!");
                }
            }
        }
        static int LogIn(int pin, int cardNumber)
        {
            if (pin == 1234 && cardNumber == 12345)
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
        static void ViewBalance (int user)
        {
            Console.WriteLine("Balance");
            for (int i = 0; i < usersAccounts[user].Length; i++)
            {
                Console.WriteLine($"{Accounts[i]} {usersAccounts[user][i]:C}");
            }
        }
        static void TransferFunds(int user)
        {
            if (user != 4)
            {
                Console.Clear();
                Console.WriteLine("Transfer");
                Console.WriteLine("Please select from one of the following accounts...");
                for (int j = 0; j < usersAccounts[user].Length; j++)
                {
                    Console.WriteLine($"{Accounts[j]} {usersAccounts[user][j]:C}");
                }
                Console.Write("Please select an account to transfer funds from: ");
                int from = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Please select an account to transfer funds to: ");
                int to = int.Parse(Console.ReadLine()) - 1;
                Console.Write("how much do you want to transfer: ");
                double amount = int.Parse(Console.ReadLine());
                if (amount > usersAccounts[user][from])
                {
                    Console.WriteLine("Sorry you don't have sufficient funds to make the transfer");
                    Console.Write("Press enter to return to main menu...");
                    Console.ReadKey();
                }
                else
                {
                    usersAccounts[user][from] = usersAccounts[user][from] - amount;
                    usersAccounts[user][to] = usersAccounts[user][to] + amount;
                    Console.WriteLine("Transfer Completed");
                    Console.Write("Press enter to return to main menu...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Sorry you need more than one account to make transfers");
                Console.Write("Press enter to return to main menu...");
                Console.ReadKey();
            }

        }
        static void Withdrawal (int user)
        {
            Console.Clear();
            Console.WriteLine("Withdrawal funds from one of the following accounts");
            DisplayAccounts(user);
            Console.Write("Select account: ");
            int accountSelected = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Enter amout to withdrawal: ");
            int amountWithdrawal = int.Parse(Console.ReadLine());
            if (amountWithdrawal > usersAccounts[user][accountSelected])
            {
                Console.WriteLine($"Sorry you can only withdrawal {usersAccounts[user][accountSelected]:C} from Account: {Accounts[accountSelected]}");
                Console.ReadKey ();
                Console.Write("Do you want to withdrawal the maximum amount from this account? y/n : ");
                var optionMaxWithdrawal = Console.ReadLine();
                if (optionMaxWithdrawal.ToLower() == "y")
                {
                    usersAccounts[user][accountSelected] = usersAccounts[user][accountSelected] - usersAccounts[user][accountSelected];
                    Console.WriteLine("Withdrawal Completed...");
                    Console.WriteLine($"New Balance");
                    Console.WriteLine($"{usersAccounts[user][accountSelected]:C}");
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("Press enter to return to main menu...");
                    Console.ReadKey();
                }

            }
            else
            {
                usersAccounts[user][accountSelected] = usersAccounts[user][accountSelected] - amountWithdrawal;
                Console.WriteLine("Withdrawal Completed...");
                Console.WriteLine($"New Balance");
                Console.WriteLine($"{usersAccounts[user][accountSelected]:C}");
                Console.ReadKey ();
            }
        }
        static void DisplayAccounts(int user)
        {
            for (int i = 0; i < usersAccounts[user].Length; i++)
            {
                Console.WriteLine($"{Accounts[i]} {usersAccounts[user][i]:C}");
            }
        }

    }
}
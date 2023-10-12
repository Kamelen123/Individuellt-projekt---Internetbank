using System.Collections;
using System.Security.Principal;

namespace Individuellt_projekt___Internetbank
{

    internal class Program
    {
        static double[][] usersAccounts = new double[][]
        {
        new double[] {0,0,0,0,0},
        new double[] {0,0,0,0},
        new double[] {0,0,0},
        new double[] {0,0},
        new double[] {0,}
        };
        static string[] usersName = { "Torbjörn", "Albin", "Lovisa", "Karin", "Daniel" };
        static string[] Accounts = { "1. CheckingAccount: ", "2. SavingsAccount: ", "3. HolidayAccount: ", "4. EvrydayAccount: ", "5. RainyDayFunds: " };
        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < usersAccounts.Length; i++)
            {
                for(int j = 0; j < usersAccounts[i].Length; j++)
                {
                    double blance = random.NextDouble();
                    usersAccounts[i][j] = blance * 10000;
                }
            }
            bool bankRunning = true;

            while (bankRunning)
            {
                for (int count = 1; count < 4; count++) // använder mig av en integer count för att räkna antal försök som sedan nollställs när användaren loggar ut
                {
                    int cardNumber = 0;
                    int pin = 0;

                    try
                    {
                        Console.WriteLine("Welcome to HappyBank!");
                        Console.WriteLine("Please Enter Cardnumber and Pin to Log In...");
                        Console.Write("Enter Card Number:");
                        cardNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter Pin: ");
                        pin = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                        EnterReadKey();
                        Console.Clear();
                    }
                    
                    int user = LogIn(pin, cardNumber);
                    if (count == 3)
                    {
                        bankRunning = false;
                    }

                    Console.WriteLine("Please Try Again, You Have " + (3 - count) + " Attempts Left!");


                    while (user == 0 || user == 1 || user == 2 || user == 3 || user == 4)
                    {
                        Console.Clear();
                    backToMenu:

                        Console.WriteLine($"Current User: {usersName[user]}");
                        Console.WriteLine("Press [1] to View Balance");
                        Console.WriteLine("Press [2] to Transfer Funds");
                        Console.WriteLine("Press [3] to Withdrawal Funds");
                        Console.WriteLine("Press [4] to Log Out");
                        Console.Write("Select Option 1-4: ");
                        int menuOption = 0;
                        try
                        {
                            menuOption = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Please Enter a Option Between 1-4");
                            EnterReadKey();
                        }
                        switch (menuOption)
                        {
                            case 1:

                                Console.Clear();
                                ViewBalance(user);
                                EnterReadKey();

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
                                    Withdrawal(user,pin);
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
                                    Console.WriteLine("Are You Sure You Want to Log Out? Press [y] to Log Out / Press [n] to Return to Menu");
                                    var exitOption = Console.ReadLine();
                                    if (exitOption.ToLower() == "y")
                                    {
                                        Console.WriteLine($"Goodbye, {usersName[user]}!");
                                        Console.ReadKey();
                                        Console.Clear();
                                        count = 0;
                                        user = 5;
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
                }
            }
        }
        static int LogIn(int pin, int cardNumber)
        {
            //cardNumbers
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
        static void ViewBalance(int user)
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
                Console.WriteLine("Please Select From One Of The Following Accounts...");
                DisplayAccounts(user);
                Console.Write("Please Select an Account to Transfer Funds from: ");
                int from = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Please Select an Account to Transfer Funds to: ");
                int to = int.Parse(Console.ReadLine()) - 1;
                Console.Write("How Much Do You Want To Transfer: ");
                double amount = double.Parse(Console.ReadLine());
                if (amount > usersAccounts[user][from])
                {
                    Console.WriteLine("Sorry You Don't Have Sufficient Funds To Make The Transfer");
                    EnterReadKey();
                }
                else
                {
                    usersAccounts[user][from] = usersAccounts[user][from] - amount;
                    usersAccounts[user][to] = usersAccounts[user][to] + amount;
                    Console.WriteLine("Transfer Completed");
                    EnterReadKey();
                }
            }
            else
            {
                Console.WriteLine("Sorry You Need More Than One Account to Make Transfers");
                EnterReadKey();
            }

        }
        static void Withdrawal(int user, int pin)
        {
            Console.Clear();
            Console.WriteLine("Withdrawal Funds From One Of The Following Accounts");
            DisplayAccounts(user);
            Console.Write("Select Account: ");
            int accountSelected = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Enter Amout To Withdrawal: ");
            double amountWithdrawal = double.Parse(Console.ReadLine());
            if (amountWithdrawal > usersAccounts[user][accountSelected])
            {
                Console.WriteLine($"Sorry You Can Only Withdrawal {usersAccounts[user][accountSelected]:C} from Account: {Accounts[accountSelected]}");
                Console.Write("Do You Want To Withdrawal The Maximum Amount From This Account? y/n : ");
                var optionMaxWithdrawal = Console.ReadLine();
                if (optionMaxWithdrawal.ToLower() == "y")
                {
                    // if sats för att kontrolera lösenord
                    Console.WriteLine("Please Enter Pin To Confirm Withdrawal");
                    int pinConfirm = int.Parse(Console.ReadLine());
                    if (pinConfirm == pin)
                    {
                        usersAccounts[user][accountSelected] = usersAccounts[user][accountSelected] - usersAccounts[user][accountSelected];
                        Console.WriteLine("Withdrawal Completed...");
                        Console.WriteLine("New Balance");
                        Console.WriteLine($"{usersAccounts[user][accountSelected]:C}");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Pin! Please Try Again.");
                        EnterReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect Option.");
                    EnterReadKey();
                }

            }
            else
            {
                Console.WriteLine("Please Enter Pin to Confirm Withdrawal");
                int pinConfirm = int.Parse(Console.ReadLine());
                if (pinConfirm == pin)
                {
                    usersAccounts[user][accountSelected] = usersAccounts[user][accountSelected] - amountWithdrawal;
                    Console.WriteLine("Withdrawal Completed...");
                    Console.WriteLine("New Balance");
                    Console.WriteLine($"{Accounts[accountSelected]}{usersAccounts[user][accountSelected]:C}");
                    EnterReadKey();
                }
                else
                {
                    Console.WriteLine("Incorrect Pin! Please Try Again.");
                    EnterReadKey();
                }
            }
        }
        static void DisplayAccounts(int user)
        {
            for (int i = 0; i < usersAccounts[user].Length; i++)
            {
                Console.WriteLine($"{Accounts[i]} {usersAccounts[user][i]:C}");
            }
        }
        static void EnterReadKey()
        {
            Console.Write("Press Enter to Return to Main Menu...");
            Console.ReadKey();
        }

    }
}
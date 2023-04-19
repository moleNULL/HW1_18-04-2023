/*
                                                   Задача #1:

Представим банк, в котором алгоритм начисления процента по вкладу зависит от суммы вклада. На вход будет
    подаваться число (сумма вклада). При значении меньше 100, будет начислено 5 %, если значение находится 
        в диапазоне от ста до двухсот — 7 %, если больше — 10 %. 

Отработав, программа должна вывести общую сумму с начисленными процентами. Для решения этой задачи воспользуемся 
    выражением Convert.ToDouble(Console.ReadLine()), которое нам пригодится для получения вводимого с 
        клавиатуры числа.

 */


namespace Lesson1_18_04_2023
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double depositAmount = GetUserDepositAmount();

            var client = new BankAccount();
            client.Deposit(depositAmount);

            ColorConsole.WriteLine(
                $"\nYour total balance (interest included) is ${client.Balance}", ConsoleColor.Green);

            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }

        private static double GetUserDepositAmount()
        {
            while (true)
            {
                Console.Write("Enter your deposit amount: $");

                try
                {
                    double depositAmount = Convert.ToDouble(Console.ReadLine());

                    if (depositAmount <= 0)
                    {
                        ColorConsole.WriteLine(
                            "Invalid input. A valid deposit amount must be bigger than $0", ConsoleColor.Red);

                        continue;
                    }

                    return depositAmount;
                }
                catch (Exception)
                {
                    ColorConsole.WriteLine(
                        "Invalid input. Please enter a valid deposit amount", ConsoleColor.Red);
                    continue;
                }
            }
        }
    }

    internal class BankAccount
    {
        private double _balance;

        public BankAccount()
        {
            _balance = 0.0;
        }

        public double Balance => _balance;

        public void Deposit(double depositAmount)
        {
            double interestRate = GetInterestRate(depositAmount);
            double interest = depositAmount * interestRate;
            double totalBalance = depositAmount + interest;

            _balance += totalBalance;
        }

        private double GetInterestRate(double depositAmount)
        {
            if (depositAmount < 100)
                return 0.05;
            else if (depositAmount < 200)
                return 0.07;
            else
                return 0.1;
        }
    }

    internal static class ColorConsole
    {
        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            Console.Write(text);

            Console.ResetColor();
        }

        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(text);

            Console.ResetColor();
        }
    }
}
/*
                                                   Задача #2:

Немного усложним "Задачу #1". Пусть банк регулярно начисляет по всем вкладам не только положенные 
    по договору проценты, но еще и бонусы. И пусть, к примеру, банк решит выполнить доначисление по всем 
        клиентским вкладам в размере 15 единиц без учета суммы. 

Поменяем программу, отображенную выше, чтобы к итоговой сумме были добавлены еще и бонусы.

 */


namespace Task_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double depositAmount = GetUserDepositAmount();

            var client = new BankAccount();
            client.Deposit(depositAmount);

            ColorConsole.WriteLine(
                $"\nYour total balance (interest and bonus included) is ${client.Balance.ToString("F2")}", 
                    ConsoleColor.Green);

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
        private double _bonus;

        public BankAccount()
        {
            _balance = 0.0;
            _bonus = 15.0;
        }

        public double Balance => _balance;

        public void Deposit(double depositAmount)
        {
            double interestRate = GetInterestRate(depositAmount);
            double interest = depositAmount * interestRate;
            double totalBalance = depositAmount + interest + _bonus;

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
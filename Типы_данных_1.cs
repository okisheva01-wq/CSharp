using System;

class Program
{
    static string CalculateDeposit(double initial_deposit, int years, double interest_rate)
    {
        string result = "";
        double amount = initial_deposit;

        for (int year = 1; year <= years; year++)
        {
            amount = amount * (1 + interest_rate / 100);

            result += $"Год {year}: {amount:F2} руб.\n";
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(CalculateDeposit(1000, 3, 10));
    }
}
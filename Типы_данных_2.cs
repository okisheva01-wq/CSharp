using System;

class Program
{
    static void PrintDiamond(int N)
    {
        int mid = N / 2;

        for (int i = 0; i < N; i++)
        {
            int dist = Math.Abs(mid - i);

            for (int j = 0; j < N; j++)
            {
                if (j == dist || j == N - 1 - dist)
                    Console.Write("X");
                else
                    Console.Write(" ");
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        PrintDiamond(5);
    }
}
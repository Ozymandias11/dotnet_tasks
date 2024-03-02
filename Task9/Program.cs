using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); // Max 1 Task can acccess resources concurently
    static bool stopOutput = false;

    static async Task Main(string[] args)
    {
        Task outputTask = Task.Run(PrintNumbers);
        Task messageTask = Task.Run(PrintMessage);

        await Task.WhenAll(outputTask, messageTask); // Wait for both tasks
    }

    static async Task PrintNumbers()
    {
        while (true)
        {
            await semaphore.WaitAsync(); 

            if (stopOutput)
            {
                semaphore.Release();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1");
            Console.Write("0");
            
            await Task.Delay(100); 

            semaphore.Release();
        }
    }

    static async Task PrintMessage()
    {
        while (true)
        {
            await Task.Delay(5000); 

            stopOutput = true;
            await semaphore.WaitAsync();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNeo, you are the chosen one");
            await Task.Delay(5000); 

            stopOutput = false;
            semaphore.Release(); 
        }
    }
}
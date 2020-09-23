using System;
using System.Threading;
using System.Threading.Tasks;

namespace level1_helloworld
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //Say Hello World!
            Console.WriteLine("Hello World!");
            Console.WriteLine("================================");
            
            //When we run in a loop to keep the container online, we'll listen for a kill signal
            var tokenSource = new CancellationTokenSource();
            Console.WriteLine("Press Ctrl + C to cancel");
            Console.CancelKeyPress += (s, a) =>
            {
                tokenSource.Cancel();
                Console.WriteLine("Exiting");
            };  
            
            //run in a loop while listening for a kill signal, and write an incremented counter to the console output
            var counter = 0;
            while (!tokenSource.IsCancellationRequested)
            {
                Console.WriteLine($"Counter: {++counter}");
                await Task.Delay(1000, tokenSource.Token);
            }
            
        }        
    }
}
using System.Diagnostics;

var stopwatch = new Stopwatch();

stopwatch.Start();

await SayHello();

await SayGoodbye();

stopwatch.Stop();

Console.WriteLine($"Execution time is around {stopwatch.Elapsed.Seconds} seconds");

var hello = SayHello();
var goodbye = SayGoodbye();

var tasks = new List<Task>
{
    hello, goodbye
};

stopwatch.Reset();

stopwatch.Start();

await Task.WhenAll(tasks);

//Task.WaitAll(tasks.ToArray());

stopwatch.Stop();

Console.WriteLine($"Execution time is around {stopwatch.Elapsed.Seconds} seconds");


//Simple methods for demo
async Task SayHello()
{
    await Task.Delay(3000);
    Console.WriteLine("Hello readers of the article!");
}

async Task SayGoodbye()
{
    await Task.Delay(5000);
    Console.WriteLine("Goodbye readers of the article!");
}


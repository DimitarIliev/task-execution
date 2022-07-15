using System.Diagnostics;

var stopwatch = new Stopwatch();

stopwatch.Start();

await SayHello();

await SayGoodbye();

Console.WriteLine();
Console.WriteLine($"Execution time is around {stopwatch.Elapsed.Seconds} seconds");
Console.WriteLine();

stopwatch.Stop();

stopwatch.Reset();

stopwatch.Start();

var hello = SayHello();
var goodbye = SayGoodbye();

var tasks = new List<Task>
{
    hello, goodbye
};

await Task.WhenAll(tasks);

//Task.WaitAll(tasks.ToArray());

Console.WriteLine();
Console.WriteLine($"Execution time is around {stopwatch.Elapsed.Seconds} seconds");
Console.WriteLine();

stopwatch.Stop();

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


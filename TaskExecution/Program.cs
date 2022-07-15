using System.Diagnostics;

var stopwatch = new Stopwatch();

stopwatch.Start();

//Start washing machine for clothes
await WashClothes();

Console.WriteLine("Washing of clothes finished!");

//Make breakfast while clothes wash
await MakeBreakfast();

Console.WriteLine("Making breakfast finished!");

Console.WriteLine();
Console.WriteLine($"Both tasks completed in around {stopwatch.Elapsed.Seconds} seconds");
Console.WriteLine();

stopwatch.Stop();

stopwatch.Reset();

stopwatch.Start();

var washClothes = WashClothes();
var makeBreakfast = MakeBreakfast();

var tasks = new List<Task>
{
    makeBreakfast, washClothes
};

while (tasks.Count > 0)
{
    var finishedTask = await Task.WhenAny(tasks);

    if (finishedTask == washClothes)
    {
        Console.WriteLine("Washing of clothes finished!");
    }
    else if (finishedTask == makeBreakfast)
    {
        Console.WriteLine("Making breakfast finished!");
    }

    tasks.Remove(finishedTask);
}

await Task.WhenAll(tasks);

//Task.WaitAll(tasks.ToArray());

Console.WriteLine();
Console.WriteLine($"Both tasks completed in around {stopwatch.Elapsed.Seconds} seconds");
Console.WriteLine();

stopwatch.Stop();

//Simple methods for demo
async Task MakeBreakfast()
{
    Console.WriteLine("Making breakfast started!");
    await Task.Delay(3000);
}

async Task WashClothes()
{
    Console.WriteLine("Washing of clothes started!");
    await Task.Delay(7000);
}



ManualResetEvent reset = new ManualResetEvent(false);
int val = 0;

Task task1 = PrintAsync(10);
Task task2 = PrintAsync2(30);

Task.WaitAll(task1, task2);

async Task PrintAsync(int num)
{
    Console.WriteLine($"Print PrintAsync");
    val = val + num;  
    Console.WriteLine(val);
    await Task.Delay(1000);
    Console.WriteLine($"Try to set signal");
    reset.Set();
    Console.WriteLine($"Signal is set");
}

async Task PrintAsync2(int num)
{
    Console.WriteLine($"PrintAsync2: Print ");
    reset.WaitOne();
    Console.WriteLine($"PrintAsync2: Signal is activated");
    try
    {
        val = val + num;  
        Console.WriteLine(val);
        await Task.Delay(1000);
    }
    finally
    {
        reset.Reset();
    }
    Console.WriteLine($"Signal is reseted");
}





using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(string[] args)
    {
        var task = ConcatAsync();
        var result = await task;
        Console.WriteLine($"Result: {result}");
    }
    
    public static async Task<string> HelloAsync() 
    { 
        using (var helloFile = new StreamReader("Hello.txt"))
        {
            return await helloFile.ReadLineAsync();
        }
    }
    public static async Task<string> WorldAsync()
    {
        using (var worldFile = new StreamReader("World.txt"))
        {
            return await worldFile.ReadLineAsync();
        }
    }
    public static async Task<string> ConcatAsync()
    {
        try
        {
            var task1 = HelloAsync();
            var task2 = WorldAsync();

            await Task.WhenAll(task1, task2);

            var sumText = string.Concat(task1.Result, " ", task2.Result);

            return sumText;
        }
        catch (Exception e) 
        {
            Console.WriteLine($"Exception: {e.Message}");
            return "Error";
        }
    }
}
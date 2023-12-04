using System;
using System.IO;
using System.Threading.Tasks;

internal sealed class Program
{
    public static async Task Main(string[] args)
    {
        var task = ConcatAsync();
        var result = await task;
        Console.WriteLine($"Result: {result}");
    }

    public static async Task<string> ReadFileContentAsync(string path)
    {
        using (var fileContent = new StreamReader(path))
        {
            return await fileContent.ReadLineAsync();
        }
    }
    public static async Task<string> ConcatAsync()
    {
        try
        {
            var task1 = ReadFileContentAsync("Hello.txt");
            var task2 = ReadFileContentAsync("World.txt");

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
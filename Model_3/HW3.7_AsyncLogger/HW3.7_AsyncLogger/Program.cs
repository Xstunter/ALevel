using HW3._7_AsyncLogger;
using System.Threading.Tasks;

internal sealed class Program
{
    public static async Task Main(string[] args)
    {
        App app = new App();
        await app.Start();
    } 
}
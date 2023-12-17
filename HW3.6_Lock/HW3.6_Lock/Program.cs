using HW3._6_Lock;
using HW3._6_Lock.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class Program
{
    public static void Main(string[] args)
    {
        MessageBox messageBox = new MessageBox();
        messageBox.Message += messageBox.StartEvent;
        try
        {
            messageBox.OpenAsync();
            Console.ReadKey();
            messageBox.EventStart();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception:{ex.Message}");
        }
    }
}
using HW3._4_LINQ;
using System;

class Program
{
    public static void Main(string[] args)
    {
        CustomEvent customEvent = new CustomEvent();
        Result result = new Result();

        customEvent.calculateEvent += result.SumEvent;
        customEvent.calculateEvent += result.MultiplyEvent;
        customEvent.calculateEvent += result.DivisionEvent;

        TryCatch(customEvent.CalculateEvent, 10, 0);

        customEvent.calculateEvent -= result.DivisionEvent;
        customEvent.calculateEvent -= result.MultiplyEvent;
        customEvent.calculateEvent -= result.SumEvent;

        TryCatch(customEvent.CalculateEvent, 10, 5);
    }
    public static void TryCatch(Action<int, int> function, int x, int y)
    {
        try
        {
            function(x, y);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }
    }
}

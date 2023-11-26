using HW_3._3_Delegate.Classes;
using System;

class Program
{
    public static void Main(string[] args)
    {
        Class1 class1 = new Class1();
        Class2 class2 = new Class2();
        DelegateResult result = class2.Calc(class1.Multiply,10,5);
        ShowDelegate showResult = Show;
        showResult(result(3));
    }
    public static void Show(bool result)
    {
        Console.WriteLine($"Result:{result}");
    }
}
using System;

namespace HW3._4_LINQ
{
    public class Result
    {
        public void SumEvent(object o, Calculate calculate)
        {
            Console.WriteLine($"Result Sum: {calculate.Sum()}");
        }
        public void MultiplyEvent(object o, Calculate calculate)
        {
            Console.WriteLine($"Result Multiply: {calculate.Multiply()}");
        }
        public void DivisionEvent(object o, Calculate calculate)
        {
            Console.WriteLine($"Result Division: {calculate.Division()}");
        }
        public void SumAllMethods(object o, Calculate calculate)
        {
            Console.WriteLine($"Result SumAllMethods: {calculate._result}");
        }
    }
}

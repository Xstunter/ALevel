using System;

namespace HW_3._3_Delegate.Classes
{
    public delegate void ShowDelegate(bool value);

    public delegate double DelegateMultiply(double x, double y);

    public class Class1
    {
        public double Multiply(double x, double y) 
        {
            return x * y;
        }
    }
}

using System;

namespace HW_3._3_Delegate.Classes
{
    public delegate bool DelegateResult(double number);
    public class Class2
    {
        public event EventHandler<EventArgs> StartCalc;

        private double result;

        public void Start()
        {
            StartCalc?.Invoke(this, new EventArgs());
        }
        public DelegateResult Calc(DelegateMultiply valueDelegate, double x, double y)
        {
            result = valueDelegate(x, y);
            return Result;
        }
        public bool Result(double number)
        {
            return result % number == 0;
        }
    }
}

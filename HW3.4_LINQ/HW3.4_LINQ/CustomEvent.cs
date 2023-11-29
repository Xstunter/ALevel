
using System;

namespace HW3._4_LINQ
{
    public class CustomEvent
    {
        public event EventHandler<Calculate> calculateEvent;

        public void CalculateEvent(int x, int y)
        {
            if (calculateEvent != null)
            {
                Calculate calculate = new Calculate(x, y);
                calculateEvent(this, calculate);
            }
            else
                throw new ArgumentNullException(nameof(calculateEvent));
        }
        
    }
}

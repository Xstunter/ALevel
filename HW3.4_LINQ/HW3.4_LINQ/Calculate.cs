using System;

namespace HW3._4_LINQ
{
    public class Calculate : EventArgs
    {
        private int _x {  get; set; }
        private int _y { get; set; }

        public double _result = 0;
        public Calculate(int x, int y)
        {
            _x = x; 
            _y = y;
        }
        public double Sum() 
        {
            _result += _x + _y;
            return _x + _y; 
        }
        public double Multiply() 
        { 
            _result += _x * _y;
            return _x * _y; 
        }
        public double Division()
        {
            if (_y == 0)
                throw new DivideByZeroException();
            _result += _x / _y;
            return _x / _y;
        }
    }
}

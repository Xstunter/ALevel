namespace HW3._1_CustomGeneric.Generics
{
    public class CustomList<T>
    {
        private T[] _list = new T[4];
        private int _size = 0;   
        public void Add(T item) 
        {
            Capacity();
            _list[_size++] = item;
        }
        public int Count()
        {
            return _size;
        }
        public void Sort()
        {
            Array.Sort(_list,0,_size);
        }
        public void SetDefaultAt(int index, T defautValue)
        {
            if(index>=0 && index <=_size) 
            {
                _list[index] = defautValue;
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of rande");
            }
        }
        private void Capacity()
        {
            if(_size  == _list.Length) 
            {
                Array.Resize(ref _list, _list.Length + 4);
            }
        }
    }
}

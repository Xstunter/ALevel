using HW7_NewYearGift.Models.Abstracts;

namespace HW7_NewYearGift.Servicies.Abstracts
{
    public interface IGift
    {
        public void AddSweat(Sweat sweat);
        public List<Sweat> GetSweat(Func<Sweat,bool> func);
        public double GetPrice();
        public double GetWeight();
        public void Sort();
    }
}

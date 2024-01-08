using HW7_NewYearGift.Models.Abstracts;
using HW7_NewYearGift.Servicies.Abstracts;

namespace HW7_NewYearGift.Servicies
{
    internal class Gift : IGift
    {
        public List<Sweat> sweats;
        public Gift()
        {
            sweats = new List<Sweat>();
        }
        public void AddSweat(Sweat sweat)
        {
            sweats.Add(sweat);
        }

        public double GetPrice()
        {
            double price = 0;
            foreach (var sweat in sweats)
            {
                price += sweat.Price;
            }
            return price;
        }

        public double GetWeight()
        {
            double weight = 0;
            foreach (var sweat in sweats)
            {
                weight += sweat.Weight;
            }
            return weight;
        }

        public List<Sweat> GetSweat(Func<Sweat, bool> func)
        {
            return sweats.Where(func).ToList();
        }

        public void Sort()
        {
            sweats = sweats.OrderBy(sweat => sweat.Price).ToList();
            
        }

    }
}

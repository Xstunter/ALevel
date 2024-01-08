using System.Threading.Channels;
using HW7_NewYearGift.Models.Abstracts;

namespace HW7_NewYearGift.Models
{
    public class Candy : Sweat
    {
        public string Type { get; set; }
        public Candy(string name, double weight, double price, string type) 
              :base(name,weight,price)
        {
            Type = type;
        }

        public override void GetInfoAboutSweat()
        {
            base.GetInfoAboutSweat();
            Console.WriteLine($"Type: {Type}");
        }
    }
}

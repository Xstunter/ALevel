using HW7_NewYearGift.Models.Abstracts;

namespace HW7_NewYearGift.Models
{
    public class Fruct : Sweat
    {
        public string WhereIs {  get; set; }
        public Fruct(string name, double weight, double price, string whereIs)
               :base(name,weight,price)
        {
            WhereIs = whereIs;
        }

        public override void GetInfoAboutSweat()
        {
            base.GetInfoAboutSweat();
            Console.WriteLine($"WhereIs: {WhereIs}");
        }
    }
}

using HW7_NewYearGift.Models.Abstracts;

namespace HW7_NewYearGift.Models
{
    public class Gingerbread : Sweat
    {
        public string Form {  get; set; }

        public Gingerbread(string name, double weight, double price, string form)
               :base(name, weight, price)
        {
            Form = form;
        }

        public override void GetInfoAboutSweat()
        {
            base.GetInfoAboutSweat();
            Console.WriteLine($"Form: {Form}");
        }
    }
}

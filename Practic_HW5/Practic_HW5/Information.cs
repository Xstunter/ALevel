namespace Practic_HW5
{
    public class Information
    {
        public List<string> _employees = new List<string>();

        public List<string> _managers = new List<string>();
        public void InputInformation()
        {
            Salary salary = new Salary();

            bool @continue = true;

            do
            {
                Console.WriteLine("Choose E (Employee) or M (Managere):");
                string position = Console.ReadLine();

                switch (position)
                {
                    case "E":
                        _employees.Add(salary.Worker(position));
                        break;
                    case "M":
                        _managers.Add(salary.Worker(position));
                        break;
                    default:
                        Console.WriteLine("You must input Worker or Managere");
                        break;
                }
        
                Console.WriteLine("Do you want continue {T or F}?");

                string tryAgain = Console.ReadLine();

                if (tryAgain == "F")
                {
                    @continue = false;
                }
            }
            while (@continue);
        }
        
        public void OutputInformation()
        {
            Console.WriteLine();

            Console.WriteLine("Employees:");

            foreach (var item in _employees)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("Managers");

            foreach (var item in _managers)
            {
                Console.WriteLine(item);
            }
        }

    }
}

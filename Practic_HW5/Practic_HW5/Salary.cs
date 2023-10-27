namespace Practic_HW5
{
    internal class Salary
    {
        public static double employeeSalary;

        public static double managerSalary;
        public string Worker(string worker)
        {
            string name;
            string city;
            string country;
            double salaryRate;

            Console.WriteLine("Input Name:");
            name = Console.ReadLine();

            Console.WriteLine("Input City:");
            city = Console.ReadLine();

            Console.WriteLine("Input Country:");
            country = Console.ReadLine();

            bool isParse = false;

            do
            {
                Console.WriteLine("Input SalaryRate:");
                isParse = Double.TryParse(Console.ReadLine(), out salaryRate);
                if (!isParse)
                {
                    Console.WriteLine("Try again! You must input double.");
                }
            }
            while (!isParse);

            Calculation(worker, salaryRate);

            string allInformation =$"Name: {name}, City: {city}, Country: {country}, SalaryRate: {salaryRate}";
            
            return allInformation;
        }  

        public void Calculation(string worker, double salary)
        {
            if (worker == "E")
            {
                employeeSalary += salary; 
            }
            else
            {
                managerSalary += salary;
            }
        }

        public void ShowSalary()
        {
            Console.WriteLine();
            Console.WriteLine($"Total employees salary: {employeeSalary}");
            Console.WriteLine();
            Console.WriteLine($"Total employees salary: {managerSalary}");
        }
    }
}

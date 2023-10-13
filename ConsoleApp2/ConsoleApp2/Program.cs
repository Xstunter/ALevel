using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System;

int[] mas = new int[100];
Random rand = new Random();
int count = 0;

Console.WriteLine("Array range");

Console.Write("Lower number of the array:");
int min = int.Parse(Console.ReadLine());

Console.Write("Higher number of the array:");
int max = int.Parse(Console.ReadLine());

for (int i = 0; i < mas.Length; i++)
{
    mas[i] = rand.Next(min, max);
    if (mas[i] >= -100 && mas[i] <= 100)
    {
        count++;
        Console.WriteLine($"Number in the range -100 to +100: {mas[i]}");
    }
}
Console.WriteLine($"Determine the number of elements whose values are in the range - 100 to + 100 is: {count}");

Console.ReadLine();



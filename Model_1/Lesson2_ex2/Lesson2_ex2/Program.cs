int[] masA = new int[20];
Random rand = new Random();

Console.WriteLine("Array range");

Console.Write("Lower number of the array:");
int min = int.Parse(Console.ReadLine());

Console.Write("Higher number of the array:");
int max = int.Parse(Console.ReadLine());

int count = 0;

for (int i = 0; i < masA.Length; i++)
{
    masA[i] = rand.Next(min, max);
    if (masA[i] <= 888)
    {
        count++;
    }
}


int[] masB = new int[count];
int n = 0;

for (int i = 0; i < masA.Length; i++)
{
    if (masA[i] <= 888)
    {
        masB[n] = masA[i];
        n++;
    }
}

int sort;

for (int i = 0; i < masB.Length; i++)
{
    for (int j = i + 1; j < masB.Length; j++)
    {
        if (masB[i] < masB[j])
        {
            sort = masB[j];
            masB[j] = masB[i];
            masB[i] = sort;
        }
    }
}

/*Array.Sort(masB);
Array.Reverse(masB);*/

Console.WriteLine($"Array masB[{count}] in descending order:");

for (int i = 0; i < masB.Length; i++)
{
    Console.Write(masB[i] + " ");
}

Console.ReadLine();
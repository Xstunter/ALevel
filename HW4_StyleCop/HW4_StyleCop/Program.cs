// HW4

int numbersOfArrays;

bool tryParse;

do
{
    Console.WriteLine("Enter the number of numbers in the array:");

    tryParse = int.TryParse(Console.ReadLine(), out numbersOfArrays);

    if (!tryParse)
    {
        Console.WriteLine("You must enter int. Not string!");
    }
}
while (!tryParse);

int[] numbersArray = new int[numbersOfArrays];

Random random = new Random();

int evenCountArray = 0;

for (int i = 0; i < numbersArray.Length; i++)
{
    numbersArray[i] = random.Next(1, 27);

    if (EvenNumber(numbersArray[i]))
    {
        evenCountArray++;
    }

    Console.Write(numbersArray[i] + " ");
}

int[] evenNumbersArray = new int[evenCountArray];

int[] oddNumbersArray = new int[numbersArray.Length - evenCountArray];

int evenCount = 0, oddCount = 0;

for (int i = 0; i < numbersArray.Length; i++)
{
    if (EvenNumber(numbersArray[i]))
    {
        evenNumbersArray[evenCount] = numbersArray[i];
        evenCount++;
    }
    else
    {
        oddNumbersArray[oddCount] = numbersArray[i];
        oddCount++;
    }
}

Console.WriteLine();

char[] evenSymbolArray = new char[evenCountArray];

char[] oddSymbolArray = new char[numbersArray.Length - evenCountArray];

if (evenCountArray > numbersArray.Length - evenCountArray)
{
    Console.WriteLine("Even array have more symbols.");
}
else
{
    Console.WriteLine("Odd array have more symbols.");
}

Console.WriteLine("Even array:");

for (int i = 0; i < evenSymbolArray.Length; i++)
{
    evenSymbolArray[i] = ChangeToChar(evenNumbersArray[i]);

    Console.Write(evenSymbolArray[i] + " ");
}

Console.WriteLine();

Console.WriteLine("Odd array:");

for (int i = 0; i < oddSymbolArray.Length; i++)
{
    oddSymbolArray[i] = ChangeToChar(oddNumbersArray[i]);

    Console.Write(oddSymbolArray[i] + " ");
}

char ChangeToChar(int number)
{
    return (char)(64 + number);
}

bool EvenNumber(int number)
{
    return number % 2 == 0;
}

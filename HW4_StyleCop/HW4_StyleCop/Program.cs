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

char[] upperSymbol = { 'a', 'e', 'i', 'd', 'h', 'j' };

int evenUpperCount = 0, oddUpperCount = 0;

Console.WriteLine("Even array:");

for (int i = 0; i < evenSymbolArray.Length; i++)
{
    evenSymbolArray[i] = ChangeToChar(evenNumbersArray[i]);

    for (int j = 0; j < upperSymbol.Length; j++)
    {
        if (upperSymbol[j] == evenSymbolArray[i])
        {
            evenSymbolArray[i] = char.ToUpper(evenSymbolArray[i]);
            evenUpperCount++;
            break;
        }
    }

    Console.Write(evenSymbolArray[i] + " ");
}

Console.WriteLine();

Console.WriteLine("Odd array:");

for (int i = 0; i < oddSymbolArray.Length; i++)
{
    oddSymbolArray[i] = ChangeToChar(oddNumbersArray[i]);

    for (int j = 0; j < upperSymbol.Length; j++)
    {
        if (upperSymbol[j] == oddSymbolArray[i])
        {
            oddSymbolArray[i] = char.ToUpper(oddSymbolArray[i]);
            oddUpperCount++;
            break;
        }
    }

    Console.Write(oddSymbolArray[i] + " ");
}

Console.WriteLine();

if (evenUpperCount > oddUpperCount)
{
    Console.WriteLine($"Even arrays have more upper's symbols. Even:{evenUpperCount} > Odd:{oddUpperCount}");
}
else if (evenUpperCount < oddUpperCount)
{
    Console.WriteLine($"Odd arrays have more upper's symbols. Even:{evenUpperCount} < Odd:{oddUpperCount}");
}
else if (evenUpperCount == 0 && oddUpperCount == 0)
{
    Console.WriteLine("Arrays dont have upper's symbols.");
}
else
{
    Console.WriteLine("Both arrays have same count upper's symbols.");
}

char ChangeToChar(int number)
{
    return (char)(96 + number);
}

bool EvenNumber(int number)
{
    return number % 2 == 0;
}

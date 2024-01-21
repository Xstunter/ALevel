using System;

/*Console.Write("Input correct word:");
string S = Console.ReadLine();

Console.Write("Input nocorrect word:");
string T = Console.ReadLine();*/

Console.WriteLine(Func("nice", "niece"));
Console.WriteLine(Func("test", "tent"));
Console.WriteLine(Func("form", "from"));
Console.WriteLine(Func("o", "odd"));
Console.WriteLine(Func("nice", "node"));
string Func(string S, string T)
{
    if (S != T)
    {
        char correctChar = default(char), nocorrectChar = default(char);

        int count = 0;

        for (int i = 0; i < S.Length; i++) 
        {
            if (S[i] != T[i])
            {
                count++;
            }
        }

        //Insert
        if (S.Length + 1 == T.Length)
        {
            for (int i = 0; i < T.Length; i++)
            {
                if (S[i] != T[i])
                {
                    nocorrectChar = T[i];
                    return $"INSERT {nocorrectChar}";
                }
            }
        }
        //end

        if (count == 1)
        {
            //Raplace
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] != T[i])
                {
                    correctChar = S[i];
                    nocorrectChar = T[i];
                    return $"RAPLACE {correctChar} {nocorrectChar}";
                }
            }
            //end
        }

        else if (count == 2)
        {
            //Swap        
            for (int i = 0; i < S.Length - 1; i++)
            {
                if (S[i] != T[i])
                {
                    correctChar = S[i];
                    nocorrectChar = T[i];
                    if (correctChar == T[i + 1] && nocorrectChar == S[i + 1])
                    {
                        return $"SWAP {correctChar} {nocorrectChar}";
                    }
                    else
                    {
                        return "IMPOSSIBLE";
                    }
                }
            }
            //end
        } 
    }
    else if (S==T)
    {
        return "EQUAL";
    }

    return "IMPOSSIBLE";
}

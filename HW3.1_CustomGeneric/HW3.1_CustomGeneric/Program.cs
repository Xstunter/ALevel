using HW3._1_CustomGeneric.Generics;

CustomList<int> list = new CustomList<int>();

list.Add(5);
list.Add(2);
list.Add(3);
list.Add(10);
list.Add(3);

Console.WriteLine(list.Count());

list.SetDefaultAt(3, default);

list.Sort();

CustomList<string> list2 = new CustomList<string>();

list2.Add("B");
list2.Add("A");
list2.Add("X");
list2.Add("A");
list2.Add("C");

Console.WriteLine(list2.Count());

list2.SetDefaultAt(1, default);

list2.Sort();

list.Add(1);
Console.WriteLine(list.Count());
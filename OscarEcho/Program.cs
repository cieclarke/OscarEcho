using System;
using OscarEcho.ScenarioThree;

namespace OscarEcho
{
    class Program
    {
        static void Main(string[] args)
        {

            ItemList il = new ItemList();
            il.Add(new Item("GB", "GDP", 2015, 20));
            il.Add(new Item("GB", "DFS", 2015, 10));
            il.Add(new Item("GB", "GDP", 2016, 20));
            var e = il.Pivot1();
            Console.WriteLine(e);
        }
    }
}

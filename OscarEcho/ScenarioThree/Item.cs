using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace OscarEcho.ScenarioThree
{
    public class Item : IComparable<Item>
    {
        public Item(string country, string indicator, int year, double amount)
        {
            this.Country = country;
            this.Indicator = indicator;
            this.Year = year;
            this.Amount = amount;
        }
        public string Country { get; private set; }
        public string Indicator { get; private set; }
        public int Year { get; private set; }
        public double Amount { get; private set; }

        public int CompareTo([AllowNull] Item other)
        {
            int a = this.Country.CompareTo(other.Country);
            if (a != 0) return a;

            int b = this.Indicator.CompareTo(other.Indicator);
            if (b != 0) return b;

            int c = this.Year.CompareTo(other.Year);
            if (c != 0) return c;

            return 0;
        }
    }


}

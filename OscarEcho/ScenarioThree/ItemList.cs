using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace OscarEcho.ScenarioThree
{
    public class ItemList : IEnumerable<Item>
    {
        private ImmutableList<Item> items;

        public ItemList()
        {
            items = ImmutableList<Item>.Empty;
        }

        public void Add(Item item)
        {
            items = items.Add(item);
        }

        public object Pivot1(/*...*/)
        {
            return items.GroupBy(i => i.Country).Select(
                g => new
                {
                    Location = g.Key,
                    Y2015 = g.Where(c => c.Year == 2015).Sum(c => c.Amount),
                    Y2016 = g.Where(c => c.Year == 2016).Sum(c => c.Amount),
                    Y2017 = g.Where(c => c.Year == 2017).Sum(c => c.Amount),
                    Y2018 = g.Where(c => c.Year == 2018).Sum(c => c.Amount),
                    Y2019 = g.Where(c => c.Year == 2019).Sum(c => c.Amount),
                    Y2020 = g.Where(c => c.Year == 2020).Sum(c => c.Amount)
                }
            );  
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}

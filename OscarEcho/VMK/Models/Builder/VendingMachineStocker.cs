using System;
using System.Collections.Generic;
using System.Linq;
using OscarEcho.VMK.Models.Coins;
using OscarEcho.VMK.Models.Snacks;

namespace OscarEcho.VMK.Models.Builder
{
    public static class VendingMachineStocker
    {
        static VendingMachineStocker()
        {
        }

        public static VendingMachine FullyStockedAndWithChange()
        {
            VendingMachine vm = new VendingMachine();

            vm.Slots.Add(ChocolateBars(5));
            vm.Slots.Add(Cola(5));
            vm.Slots.Add(Sweets(5));

            vm.AvailableChange = Coins();

            return vm;
        }

        public static VendingMachine FullyStockedAndNoChange()
        {
            VendingMachine vm = new VendingMachine();

            vm.Slots.Add(ChocolateBars(5));
            vm.Slots.Add(Cola(5));
            vm.Slots.Add(Sweets(5));

            vm.AvailableChange = new List<ICoin>(0);

            return vm;
        }

        public static VendingMachine StockedAndWithChange()
        {
            VendingMachine vm = new VendingMachine();

            vm.Slots.Add(ChocolateBars(1));
            vm.Slots.Add(Cola(0));
            vm.Slots.Add(Sweets(1));

            vm.AvailableChange = Coins();

            return vm;
        }

        private static Slot ChocolateBars(int num)
        {
            Queue<ISnack> snacks = new Queue<ISnack>(num);
            for (var i = 0; i < num; i++)
            {
                snacks.Enqueue(new Chocolate());
            }

            return new Slot
            {
                Code = "A",
                Price = 0.5,
                Snacks = snacks
            };
        }

        private static Slot Cola(int num)
        {
            Queue<ISnack> snacks = new Queue<ISnack>(num);
            for (var i = 0; i < num; i++)
            {
                snacks.Enqueue(new Cola());
            }

            return new Slot
            {
                Code = "B",
                Price = 1,
                Snacks = snacks
            };
        }

        private static Slot Sweets(int num)
        {
            Queue<ISnack> snacks = new Queue<ISnack>(num);
            for (var i = 0; i < num; i++)
            {
                snacks.Enqueue(new Sweets());
            }

            return new Slot
            {
                Code = "C",
                Price = 0.65,
                Snacks = snacks
            };
        }

        private static List<ICoin> Coins()
        {
            List<ICoin> coins = new List<ICoin>();
            coins.AddRange(Enumerable.Repeat<ICoin>(new Pound(),10).ToArray());
            coins.AddRange(Enumerable.Repeat<ICoin>(new FiftyPence(), 10).ToArray());
            coins.AddRange(Enumerable.Repeat<ICoin>(new TwentyPence(), 10).ToArray());
            coins.AddRange(Enumerable.Repeat<ICoin>(new TenPence(), 10).ToArray());
            coins.AddRange(Enumerable.Repeat<ICoin>(new FivePence(), 10).ToArray());
            return coins;
        }
    }
}

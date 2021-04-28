using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OscarEcho.VMK.Models;
using OscarEcho.VMK.Models.Coins;
using OscarEcho.VMK.Models.Payment;
using OscarEcho.VMK.Models.Snacks;

namespace OscarEcho.VMK.Tests
{
    [TestClass]
    public class RollingChange
    {

        VendingMachine vm = null;

        [TestInitialize]
        public void Init()
        {
            vm = new VendingMachine();
            List<ICoin> coins = new List<ICoin>();
            coins.AddRange(Enumerable.Repeat<ICoin>(new FiftyPence(), 10).ToArray());
            coins.AddRange(Enumerable.Repeat<ICoin>(new Pound(), 6).ToArray());
            coins.AddRange(Enumerable.Repeat<ICoin>(new FivePence(), 4).ToArray());
            vm.AvailableChange = coins;

            Queue<ISnack> colas = new Queue<ISnack>();
            for (var i = 0; i < 5; i++)
            {
                colas.Enqueue(new Cola());
            }

            Slot colaSlot = new Slot
            {
                Code = "A1",
                Price = 0.4,
                Snacks = colas
            };

            vm.Slots.Add(colaSlot);
        }

        [TestMethod]
        public void RollingChangeCalculator()
        {
            PaymentToken fifty = new PaymentToken(50, 50);
            ITokenConverter convertor1 = new SterlingTokenConverter(fifty);


            vm.MakePayment(convertor1.Coin);
            vm.MakePurchase("A1");


            var coinChange = vm.GetChange.Sum(c => c.Worth);
            var a = vm.AvailableChange;
            Assert.AreEqual(0, a);
            Assert.AreEqual(0.1, coinChange);
        }

    }
}
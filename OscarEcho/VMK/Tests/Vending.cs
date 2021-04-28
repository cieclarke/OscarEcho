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
    public class Vending
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
        public void StockUp()
        {
            Assert.AreEqual(vm.Slots[0].Snacks.Count, 5);
        }

        [TestMethod]
        public void ChangeCoinsAvailable()
        {
            Assert.AreEqual(vm.AvailableChange.Count, 20);
        }

        [TestMethod]
        public void MakeOnePayment()
        {
            vm.MakePayment(new Pound());
            Assert.AreEqual(vm.CurrentPayment, 1);

        }

        [TestMethod]
        public void MakeSeveralPayments()
        {
            vm.MakePayment(new TwentyPence());
            vm.MakePayment(new FivePence());
            vm.MakePayment(new FivePence());
            Assert.AreEqual(vm.CurrentPayment, 0.30);
        }

        [TestMethod]
        public void MakeUnderFundedPurchase()
        {
            vm.MakePayment(new TwentyPence());
            vm.MakePayment(new FivePence());
            vm.MakePayment(new FivePence());
            var isPurchased = vm.MakePurchase("A1");
            Assert.AreEqual(isPurchased, false);
        }

        [TestMethod]
        public void MakeOverFundedPurchase()
        { 
            vm.MakePayment(new FiftyPence());
            var isPurchased = vm.MakePurchase("A1");
            var coinChange = vm.GetChange;
            Assert.AreEqual(coinChange.Sum(c => c.Worth), 0.1);
        }

        [TestMethod]
        public void ConvertMoneyForBuying()
        {
            PaymentToken pound = new PaymentToken(100, 100);

            ITokenConverter convertor = new SterlingTokenConverter(pound);
            ICoin c = convertor.Coin;

            Assert.AreEqual(c.Worth, 1);
        }

        [TestMethod]
        public void TestWrongCoin()
        {
            PaymentToken euro = new PaymentToken(101, 99);

            ITokenConverter convertor = new SterlingTokenConverter(euro);
            ICoin c = convertor.Coin;

            Assert.AreEqual(c, null);
        }

        [TestMethod]
        public void ResetCoins()
        {
            PaymentToken pound = new PaymentToken(100, 100);
            PaymentToken five = new PaymentToken(5, 5);

            ITokenConverter convertor1 = new SterlingTokenConverter(pound);
            ICoin c1 = convertor1.Coin;

            ITokenConverter convertor2 = new SterlingTokenConverter(five);
            ICoin c2 = convertor2.Coin;

            vm.MakePayment(c1);
            vm.MakePayment(c1);
            vm.ReturnCoins();

            Assert.AreEqual(vm.CurrentPayment, 0);
        }

        [TestMethod]
        public void ConvertorEqualToCoin()
        {
            PaymentToken ten = new PaymentToken(10, 10);
            ITokenConverter convertor = new SterlingTokenConverter(ten);
            ICoin c = convertor.Coin;
            ICoin coin = new TenPence();

            Assert.AreEqual(coin.Worth, c.Worth);
        }

        [TestMethod]
        public void EnsureChangeGivenFromMachine()
        {
            vm.MakePayment(new FiftyPence());

            var avaiableChangeBefore = vm.AvailableChange.Count;

            var isPurchased = vm.MakePurchase("A1");
            var coinChange = vm.GetChange;

            var avaiableChangeAfter = vm.AvailableChange.Count;
            Assert.AreEqual(avaiableChangeBefore, avaiableChangeAfter+2);
        }

        [TestMethod]
        public void IsCoinGoodForMachine()
        {
            PaymentToken two = new PaymentToken(2, 2);
            ITokenConverter convertor = new SterlingTokenConverter(two);
            var a = vm.CurrentPayment;
            vm.MakePayment(convertor.Coin);
            var b = vm.CurrentPayment;

            Assert.AreEqual(b, 0);
            Assert.AreEqual(a, 0);


        }
    }
}

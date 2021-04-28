using System;
using OscarEcho.VMK;
using OscarEcho.VMK.Models;
using OscarEcho.VMK.Models.Builder;
using OscarEcho.VMK.Models.Payment;

namespace OscarEcho
{
    class Program
    {


        public static void Main(string[] args)
        {
            VendingMachine vendingMachine = null;
            int choice = 0;

            switch (StockOptions())
            {
                case 1:
                    vendingMachine = VendingMachineStocker.FullyStockedAndWithChange();
                    break;
                case 2:
                    vendingMachine = VendingMachineStocker.FullyStockedAndNoChange();
                    break;
                case 3:
                    vendingMachine = VendingMachineStocker.StockedAndWithChange();
                    break;
                default:
                    break;

            }

            do
            {
                ITokenConverter tokenConverter;
                choice = VendorDisplay(vendingMachine);

                switch (choice)
                {
                    case 1:
                        tokenConverter = new SterlingTokenConverter(new PaymentToken(100, 100));
                        vendingMachine.MakePayment(tokenConverter.Coin);
                        break;
                    case 2:
                        tokenConverter = new SterlingTokenConverter(new PaymentToken(50, 50));
                        vendingMachine.MakePayment(tokenConverter.Coin);
                        break;
                    case 3:
                        tokenConverter = new SterlingTokenConverter(new PaymentToken(20, 20));
                        vendingMachine.MakePayment(tokenConverter.Coin);
                        break;
                    case 4:
                        tokenConverter = new SterlingTokenConverter(new PaymentToken(10, 10));
                        vendingMachine.MakePayment(tokenConverter.Coin);
                        break;
                    case 5:
                        tokenConverter = new SterlingTokenConverter(new PaymentToken(5, 5));
                        vendingMachine.MakePayment(tokenConverter.Coin);
                        break;
                    case 6:
                        tokenConverter = new SterlingTokenConverter(new PaymentToken(2, 2));
                        vendingMachine.MakePayment(tokenConverter.Coin);
                        break;
                    case 7:
                        tokenConverter = new SterlingTokenConverter(new PaymentToken(1, 1));
                        vendingMachine.MakePayment(tokenConverter.Coin);
                        break;
                    case 8:
                        tokenConverter = new SterlingTokenConverter(new PaymentToken(102, 98));
                        vendingMachine.MakePayment(tokenConverter.Coin);
                        break;
                    case 9:
                        vendingMachine.ReturnCoins();
                        break;
                    case 10:
                        PurchaseDisplay(vendingMachine);
                        break;
                    default:
                        //choice = Start();
                        break;

                }

            } while (choice != 99);
        }

        public static int StockOptions()
        {
            Console.WriteLine("1. Add Full Stock and Change");
            Console.WriteLine("2. Add Full Stock and No Change");
            Console.WriteLine("3. Add Some Stock and Change");
            var choice = Console.ReadLine();
            return Convert.ToInt32(choice);
        }

        public static int VendorDisplay(VendingMachine vendingMachine)
        {
            Console.WriteLine("WINDOW");
            foreach (Slot slot in vendingMachine.Slots)
            {
                Console.Write("Slot: '" + slot.Code + "' ");
                if (slot.Snacks.Count <= 0)
                {
                    Console.Write("SOLD OUT");
                }
                else
                {
                    Console.Write(string.Format("{0} - £{1:0.00}", slot.Snacks.Peek().Name, slot.Price));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            
            Console.WriteLine(String.Format("{1}, CURRENT PAYMENT: £{0:0.00}", vendingMachine.CurrentPayment,
                vendingMachine.AvailableChange.Count == 0 ? "EXACT CHANGE ONLY" : "INSERT COIN"));
            Console.WriteLine("1. £1");
            Console.WriteLine("2. 50p");
            Console.WriteLine("3. 20p");
            Console.WriteLine("4. 10p");
            Console.WriteLine("5. 5p");
            Console.WriteLine("6. 2p");
            Console.WriteLine("7. 1p");
            Console.WriteLine("8. 1Euro");
            Console.WriteLine("9. Return Coins");
            Console.WriteLine("10. Make Purchase");
            Console.WriteLine("99. Exit");
            var choice = Console.ReadLine();
            return Convert.ToInt32(choice);
        }

        public static int PurchaseDisplay(VendingMachine vendingMachine)
        {
            Console.WriteLine("Enter Slot Code:");
            var code = Console.ReadLine();

            vendingMachine.MakePurchase(code);
            Console.Write("Coins Change: ");
            foreach (ICoin coin in vendingMachine.GetChange)
            {
                Console.Write(string.Format("{0}", coin.Name));
            }
            Console.WriteLine("");


            return 1;
        }
    }
}

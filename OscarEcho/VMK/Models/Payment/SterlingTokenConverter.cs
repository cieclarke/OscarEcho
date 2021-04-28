using System;
using OscarEcho.VMK.Models.Coins;

namespace OscarEcho.VMK.Models.Payment
{
    public class SterlingTokenConverter : ITokenConverter
    {
        private PaymentToken paymentToken;

        public SterlingTokenConverter(PaymentToken paymentToken)
        {
            this.paymentToken = paymentToken;
            Convert();
        }

        public ICoin Coin { get; private set; }

        private void Convert()
        {
            if(paymentToken.Weight == 100 && paymentToken.Size == 100)
            {
                this.Coin = new Pound();
            }

            if (paymentToken.Weight == 50 && paymentToken.Size == 50)
            {
                this.Coin = new FiftyPence();
            }

            if (paymentToken.Weight == 20 && paymentToken.Size == 20)
            {
                this.Coin = new TwentyPence();
            }

            if (paymentToken.Weight == 10 && paymentToken.Size == 10)
            {
                this.Coin = new TenPence();
            }

            if (paymentToken.Weight == 5 && paymentToken.Size == 5)
            {
                this.Coin = new FivePence();
            }

            if (paymentToken.Weight == 2 && paymentToken.Size == 2)
            {
                this.Coin = new TwoPence();
            }

            if (paymentToken.Weight == 1 && paymentToken.Size == 1)
            {
                this.Coin = new OnePence();
            }

        }
    }
}

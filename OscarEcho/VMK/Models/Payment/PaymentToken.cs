using System;
namespace OscarEcho.VMK.Models.Payment
{
    public class PaymentToken : IToken
    {
      
        public PaymentToken(int size, int weight)
        {
            this.Size = size;
            this.Weight = weight;
        }

        public int Size { get; private set; }
        public int Weight { get; private set; }
    }
}

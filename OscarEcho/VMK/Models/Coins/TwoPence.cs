using System;
namespace OscarEcho.VMK.Models.Coins
{
    public class TwoPence : ICoin
    {
        public TwoPence()
        {
        }

        public string Name { get => "2p"; }
        public double Worth { get => 0.02; }
    }
}

using System;
namespace OscarEcho.VMK.Models.Coins
{
    public class OnePence : ICoin
    {
        public OnePence()
        {
        }

        public string Name { get => "1p"; }
        public double Worth { get => 0.01; }
    }
}

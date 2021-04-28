using System;
namespace OscarEcho.VMK.Models.Coins
{
    public class TwentyPence : ICoin
    {
        public TwentyPence()
        {
        }

        public string Name { get => "20p"; }
        public double Worth { get => 0.20; }
    }
}

using System;
namespace OscarEcho.VMK.Models.Coins
{
    public class FiftyPence : ICoin
    {
        public FiftyPence()
        {
        }

        public string Name { get => "50p"; }
        public double Worth { get => 0.5; }
    }
}

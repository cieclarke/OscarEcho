using System;
namespace OscarEcho.VMK.Models.Coins
{
    public class Pound : ICoin
    {
        public Pound()
        {
        }

        public string Name { get => "£1"; }
        public double Worth { get => 1; }
    }
}

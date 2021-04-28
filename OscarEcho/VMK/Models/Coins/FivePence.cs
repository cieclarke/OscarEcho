using System;
namespace OscarEcho.VMK.Models.Coins
{
    public class FivePence : ICoin
    {
        public FivePence()
        {
        }

        public string Name { get => "5p"; }
        public double Worth { get => 0.05; }
    }
}

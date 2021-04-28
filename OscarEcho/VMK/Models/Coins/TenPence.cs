using System;
namespace OscarEcho.VMK.Models.Coins
{
    public class TenPence : ICoin
    {
        public TenPence()
        {
        }

        public string Name { get => "10p"; }
        public double Worth { get => 0.10; }
    }
}

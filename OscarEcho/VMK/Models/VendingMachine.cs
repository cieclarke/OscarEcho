using System;
using System.Collections.Generic;
using System.Linq;

namespace OscarEcho.VMK.Models
{

    public class VendingMachine
    {

        private List<Slot> slots;
        private List<ICoin> change = new List<ICoin>();

        public VendingMachine()
        {
        }

        public List<Slot> Slots
        {
            get
            {
                if(this.slots == null)
                {
                    this.slots = new List<Slot>();
                    return slots;
                }
                else
                {
                    return this.slots;
                }
            }
        }

        public void ReturnCoins()
        {
            this.CurrentPayment = 0;
        }


        public void MakePayment(ICoin coin)
        {
            bool isValid = coin != null;

            if (isValid && coin.Worth >= 0.05)
            {
                this.CurrentPayment += coin.Worth;
            }
        }

        public bool MakePurchase(string slotCode)
        {
            Slot slot = this.slots.Find(s => s.Code == slotCode);
            if (slot.Snacks.Count > 0 && CurrentPayment >= slot.Price)
            { 
                Takings += slot.Price;
                slot.Snacks.Dequeue();
                this.change = CalculateChange(slot.Price);
                CurrentPayment = 0;
                return true;
            }
            else
            { return false; }
        }

        public List<ICoin> GetChange
        {
            get { return change; }

        }

        public double CurrentPayment { get; private set;  }

        public double Takings { get; private set; }

        public List<ICoin> AvailableChange { get; set; }

        private List<ICoin> CalculateChange(double cost)
        {
            double difference = CurrentPayment - cost;
            List<ICoin> changeCoins = new List<ICoin>();
            List<ICoin> coins = AvailableChange;
            var coinGroups = coins.GroupBy(c => new { c.Name, c.Worth })
                .Select(c => new { Coin = c.Key.Name, Worth = c.Key.Worth, Count = c.ToList().Count }).OrderBy(c => c.Worth).Reverse();

            
            while (difference > 0 && AvailableChange.Count > 0)
            {
                difference = Math.Round(difference, 2);
                foreach (var cg in coinGroups)
                {
                    if(difference - cg.Worth >= 0)
                    {
                        difference -= cg.Worth;
                        ICoin coin = AvailableChange.Find(c => c.Name == cg.Coin);
                        changeCoins.Add(coin);
                        RemoveCoin(coin.Name);
                        break;
                    }
                }

            }

            return changeCoins;
        }

        private void RemoveCoin(string name)
        {
            var coinIndex = AvailableChange.FindIndex(c => c.Name == name);
            if(coinIndex >= 0)
            {
                AvailableChange.RemoveAt(coinIndex);
            }
            
        }

    }
}

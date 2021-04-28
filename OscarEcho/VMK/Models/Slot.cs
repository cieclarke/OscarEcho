using System;
using System.Collections.Generic;

namespace OscarEcho.VMK.Models
{
    public class Slot
    {
        public Slot()
        {
        }

        public string Code;
        public double Price;
        public Queue<ISnack> Snacks;
            
    }
}

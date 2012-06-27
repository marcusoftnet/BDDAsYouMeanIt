using System;
using Domain;

namespace Web
{
    public class RealCashDispenser : ICashDispenser
    {
        public int Contents
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispense(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
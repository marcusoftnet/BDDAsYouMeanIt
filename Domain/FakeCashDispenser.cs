namespace Domain
{
    public class FakeCashDispenser : ICashDispenser
    {
        private int _contents;

        public int Contents
        {
            get { return _contents; }
        }

        public void Dispense(int amount)
        {
            _contents = amount;
        }
    }
}
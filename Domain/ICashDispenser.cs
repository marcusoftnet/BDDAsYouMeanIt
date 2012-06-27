namespace Domain
{
    public interface ICashDispenser
    {
        int Contents { get; }
        void Dispense(int amount);
    }
}
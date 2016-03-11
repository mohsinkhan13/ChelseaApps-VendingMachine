namespace ChelseaApps.VendingMachine.Shared.Validations
{
    public interface ICurrencyValidator
    {
        bool Contains(decimal value);
    }
}

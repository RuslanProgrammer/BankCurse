using System.Runtime.CompilerServices;

namespace BankCurse
{
    public class Currency
    {
        public int CurrencyId { set; get; }
        public string CurrencyName { set; get; }
        public string CurrencySign { set; get; }
        public bool IsChanged { set; get; }

        public Currency(int currencyId, string currencyName, string currencySign)
        {
            CurrencyId = currencyId;
            CurrencyName = currencyName;
            CurrencySign = currencySign;
            IsChanged = true;
        }

        public Currency()
        {
            IsChanged = false;

        }
    }
}

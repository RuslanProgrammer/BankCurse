using System;

namespace BankCurse
{
    public class Account
    {
        public int AccountId { set; get; }
        public Client Client { set; get; }
        public double Balance { set; get; }
        public Currency Currency { set; get; }
        public string OpenDate { set; get; } = DateTime.Today.ToString("yyyy-MM-dd");
        public bool IsChanged { set; get; }

        public Account(int accountId, Client client, double balance, Currency currency)
        {
            AccountId = accountId;
            Client = client;
            Balance = balance;
            Currency = currency;
            IsChanged = true;
        }

        public Account()
        {
            IsChanged = false;
        }
    }
}

using System;

namespace BankCurse
{
    public class LoansTransaction
    {
        public int TransactionId { set; get; }
        public Loan Loan { set; get; }
        public string TransactionDate { set; get; } = DateTime.Today.ToString("yyyy-MM-dd");
        public double Amount { set; get; }
        public bool IsChanged { set; get; }


        public LoansTransaction(int transactionId, Loan loan, string transactionDate, double amount)
        {
            TransactionId = transactionId;
            Loan = loan;
            TransactionDate = transactionDate;
            Amount = amount;
            IsChanged = true;
        }

        public LoansTransaction()
        {
            IsChanged = false;
        }
    }
}

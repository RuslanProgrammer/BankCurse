using System;
using System.Collections.Generic;
using System.Linq;

namespace BankCurse
{
    public class Loan
    {
        public int LoanId { set; get; }
        public Account Account { set; get; }
        public string OpenDate { set; get; } = DateTime.Today.ToString("yyyy-MM-dd");
        public double TotalAmount { set; get; }
        public double InterestRate { set; get; }
        public bool IsChanged { set; get; }
        public List<LoansTransaction> LoanTransactions = new List<LoansTransaction>();
        public bool IsClose
        {
            get
            {
                if(LoanTransactions.Count > 0)
                    return LoanTransactions.Sum(x => x.Amount) >= TotalAmount + TotalAmount *
                    Convert.ToDateTime(LoanTransactions.Max(x => Convert.ToDateTime(x.TransactionDate)))
                        .Subtract((Convert.ToDateTime(OpenDate))).Days * InterestRate;
                return false;
            }
        }

        public double Left
        {
            get
            {
                if (LoanTransactions.Count > 0)
                    return TotalAmount +
                       TotalAmount * DateTime.Today.Date.Subtract(Convert.ToDateTime(OpenDate)).Days * InterestRate -
                       LoanTransactions.Sum(x => x.Amount);
                return TotalAmount;
            }
        }

        public Loan(int loanId, Account account, string openDate, double totalAmount, double interestRate)
        {
            LoanId = loanId;
            Account = account;
            OpenDate = openDate;
            TotalAmount = totalAmount;
            InterestRate = interestRate;
            IsChanged = true;
        }

        public Loan()
        {
            IsChanged = false;
        }
    }
}

using System;

namespace BankCurse
{
    public class Deposit
    {
        public int DepositId { set; get; }
        public Account Account { set; get; }
        public double InterestRate { set; get; }
        public double InitialAmount { set; get; }
        public string OpenDate { set; get; } = DateTime.Today.ToString("yyyy-MM-dd");
        public string CloseDate { set; get; }
        public bool IsChanged { set; get; }

        public double FinalAmount => InitialAmount + InitialAmount * Convert.ToDateTime(CloseDate).Subtract((Convert.ToDateTime(OpenDate))).Days * (InterestRate / 36000);

        public Deposit(int depositId, Account account, double interestRate, double initialAmount, string openDate, string closeDate)
        {
            DepositId = depositId;
            Account = account;
            InterestRate = interestRate;
            InitialAmount = initialAmount;
            OpenDate = openDate;
            CloseDate = closeDate;
            IsChanged = true;
        }

        public Deposit()
        {
            IsChanged = false;
        }
    }
}

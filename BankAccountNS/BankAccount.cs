using System;

namespace BankAccountNS
{
    public class BankAccount
    {
        public const string InitBankAccountCustomerNameIsNullMessage = "Initial customer name is 'null'";
        public const string InitBankAccountCustomerNameIsEmptyMessage = "Initial customer name is empty";
        public const string InitBankAccountBalanceLessThanZeroMessage = "Initial balance is less than zero";
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            if (customerName == null)
            {
                throw new ArgumentNullException("customerName", InitBankAccountCustomerNameIsEmptyMessage);
            }
            if (customerName == "")
            {
                throw new ArgumentNullException("customerName", InitBankAccountCustomerNameIsEmptyMessage);
            }
            if (balance < 0)
            {
                throw new ArgumentOutOfRangeException("balance", balance, InitBankAccountBalanceLessThanZeroMessage);
            }

            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}


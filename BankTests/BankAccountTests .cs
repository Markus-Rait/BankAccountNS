using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        private const string customerName = "Mr. Bryan Walton";
        private const double beginningBalance = 10.00;

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            const double expected = 5.45;
            const double debitAmount = 4.55;
            BankAccount account = new BankAccount(customerName, beginningBalance);

            account.Debit(debitAmount);

            Assert.AreEqual(expected, account.Balance, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            const double debitAmount = -100.00;
            BankAccount account = new BankAccount(customerName, beginningBalance);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            const double debitAmount = 20.0;
            BankAccount account = new BankAccount(customerName, beginningBalance);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            const double expected = 15.00;
            const double creditAmount = 5.00;
            BankAccount account = new BankAccount(customerName, beginningBalance);

            account.Credit(creditAmount);

            Assert.AreEqual(expected, account.Balance, 0.001, "Account not credited correctly");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            const double creditAmount = -5.00;
            BankAccount account = new BankAccount(customerName, beginningBalance);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }

        [TestMethod]
        public void BankAccountInit_WhenCustomerNameIsNull_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new BankAccount(null, beginningBalance));
        }

        [TestMethod]
        public void BankAccountInit_WhenCustomerNameIsEmpty_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new BankAccount("", beginningBalance));
        }

        [TestMethod]
        public void BankAccountInit_WhenBalanceIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new BankAccount(customerName, -1));
        }
    }
}


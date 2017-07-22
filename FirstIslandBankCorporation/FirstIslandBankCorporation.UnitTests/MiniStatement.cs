using System;
using System.Collections.Generic;
using System.Linq;
using DataObject;
using Facade;
using NUnit.Framework;

namespace FirstIslandBankCorporation.UnitTests
{
    [TestFixture]
    public class MiniStatement
    {
        /// <summary>
        /// Unit Test Method for Login
        /// </summary>
        [Test]
        public void Login()
        {
            try
            {
                var email = "ram@gmail.com";
                var password = "Password@123";
                MiniStatementFacade _miniStatementFacade = new MiniStatementFacade();
                var user = _miniStatementFacade.FindUserByEmail(email);
                Assert.AreEqual(password, user.Password);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }
        }

        /// <summary>
        /// Unit Test Method for Accounts
        /// </summary>
        [Test]
        public void Accounts()
        {
            try
            {
                var userId = 1;
                var totalAvaialbeBalance = decimal.Zero;
                MiniStatementFacade _miniStatementFacade = new MiniStatementFacade();
                var userTransactions = _miniStatementFacade.GetUserTransactionsByUserId(userId);
                totalAvaialbeBalance = _miniStatementFacade.GetCurrentAvailableBalance(userTransactions);

                Assert.AreEqual(35400, totalAvaialbeBalance);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        /// <summary>
        /// Unit Test Method for Transactions
        /// </summary>
        [Test]
        public void Transactions()
        {
            try
            {
                var userId = 1;
                MiniStatementFacade _miniStatementFacade = new MiniStatementFacade();
                IList<Transaction> userTransactions = _miniStatementFacade.GetUserTransactionsByUserId(userId);
                var savingActBalance = GetAccountBalance(userTransactions.Where(x => x.Account.AccountName == "Savings Account").ToList());
                var currentActBalance = GetAccountBalance(userTransactions.Where(x => x.Account.AccountName == "Current Account").ToList());
                var seniorCitizenActBalance = GetAccountBalance(userTransactions.Where(x => x.Account.AccountName == "Senior Citizen Account").ToList());

                Assert.AreEqual(2200, savingActBalance);
                Assert.AreEqual(22400, currentActBalance);
                Assert.AreEqual(10800, seniorCitizenActBalance);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        #region Utilities

        private decimal GetAccountBalance(IList<Transaction> transactions)
        {
            var balance = decimal.Zero;
            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }

        #endregion
    }
}

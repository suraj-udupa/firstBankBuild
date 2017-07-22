using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObject;
using Facade;
using FirstIslandBankCorporation.Models;
using System.IO;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;
using System.Data.SqlClient;
using OfficeOpenXml;

namespace FirstIslandBankCorporation.Controllers
{
    /// <summary>
    /// Mini Statement Controller
    /// </summary>
    public partial class MiniStatementController : Controller
    {
        public MiniStatementController()
        {
        }

        /// <summary>
        /// User mini statement view controller
        /// Entry Criteria : userid and accountid shouldnt be null. 
        /// Responsibility : Display user mini statement
        /// Success Criteria : Fetchs users transactions from DB displays to user
        /// Exception condition: Fail when the database call fails for any exception.
        /// @return
        /// @throws SQLException
        /// @throws ClassNotFoundException
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        /// <returns>UserTransactionsModel</returns>
        public ActionResult ViewMiniStatement(int userId, int accountId)
        {
            UserTransactionsModel model = new UserTransactionsModel();
            try
            {
                PrepareModel(model, userId, accountId);
            }
            catch (Exception)
            {
            }
            return View(model);
        }

        #region Utilities

        private void PrepareModel(UserTransactionsModel model, int userId, int accountId)
        {
            try
            {
                MiniStatementFacade _miniStatementFacade = new MiniStatementFacade();
                IList<Transaction> transactions = _miniStatementFacade.GetUserTransactionsByAccountId(userId, accountId);
                var userAccounts = _miniStatementFacade.GeUsertAccountsByUserId(userId);
                var userAccount = userAccounts.Where(x => x.AccountId == accountId).FirstOrDefault();

                if (transactions.Count > 0)
                {
                    var account = transactions[0].Account;
                    model.AccountType = account.AccountName;
                    model.AccountNumber = userAccount.AccountNumber;
                }
                model.UserTransactions = transactions;
                model.AccountBalance = GetAccountBalance(transactions);
                model.UserId = userId;
                model.AccountId = accountId;
            }
            catch (Exception)
            {

            }
        }

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
 
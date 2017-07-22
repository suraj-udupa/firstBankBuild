using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObject;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;

namespace Facade
{
    /// <summary>
    /// Mini Statement Facade
    /// </summary>
    public partial class MiniStatementFacade
    {
        /// <summary>
        /// Get user transactions by accountId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        /// <returns>List transactions</returns>
        public IList<Transaction> GetUserTransactionsByAccountId(int userId, int accountId)
        {
            return MiniStatement.FindUserTransactionsByAccountId(userId, accountId);
        }

        /// <summary>
        /// Find user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Transaction Collection</returns>
        public User FindUserByEmail(string email)
        {
            return MiniStatement.GetUserByEmail(email);
        }

        /// <summary>
        /// Gets Current Available Balance for user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Current Available Balance</returns>
        public decimal GetCurrentAvailableBalance(IList<Transaction> transactions)
        {
            return MiniStatement.GetCurrentAvailableBalance(transactions);
        }

        /// <summary>
        /// Gets user transactions by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Trasaction collection</returns>
        public IList<Transaction> GetUserTransactionsByUserId(int userId)
        {
            return MiniStatement.GetUserTransactionsByUserId(userId);
        }

        /// <summary>
        /// Gets UserAccounts by UserId.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>UserAccounts</returns>
        public List<UserAccounts> GeUsertAccountsByUserId(int userId)
        {
            return MiniStatement.GetUserAccountsByUserId(userId);
        }

        /// <summary>
        /// Get the balance of a user to a specific account
        /// </summary>
        /// <returns></returns>
        public decimal GetBalanceByAccount(string accountName, IList<Transaction> transactions)
        {
            return MiniStatement.GetBalanceByAccount(accountName, transactions);
        }

        /// <summary>
        /// Returns user had a specific account or not
        /// </summary>
        /// <returns></returns>
        public bool HasUserHadAccount(IList<UserAccounts> userAccounts, string accountName)
        {
            return MiniStatement.HasUserHadAccount(userAccounts, accountName);
        }

        /// <summary>
        /// Gets Account by AccountId.
        /// </summary>
        /// <param name="userAccounts"></param>
        /// <param name="accountName"></param>
        /// <returns>Account</returns>
        public void GetUserAccount(IList<UserAccounts> userAccounts, string accountName, out int accountId, out string accountNumber)
        {
            accountId = 0;
            accountNumber = string.Empty;
            try
            {
                var userAccount = MiniStatement.GetUserAccount(userAccounts, accountName);
                if (userAccount != null)
                {
                    accountId = userAccount.AccountId;
                    accountNumber = userAccount.AccountNumber;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}

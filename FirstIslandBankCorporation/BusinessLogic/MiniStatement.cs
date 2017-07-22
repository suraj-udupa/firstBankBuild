using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObject;
using DAO;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    /// <summary>
    /// MiniStatement Business Logic
    /// </summary>
    public class MiniStatement
    {
        /// <summary>
        /// Get Account by account name
        /// </summary>
        /// <params>UserAccounts Collection</params>
        /// <params>accountName</params>
        /// <returns>UserAccounts</returns>
        public static UserAccounts GetUserAccount(IList<UserAccounts> userAccounts, string accountName)
        {
            UserAccounts userAccnts = new UserAccounts();
            try
            {
                foreach (var userAccount in userAccounts)
                {
                    if (userAccount.Account.AccountName.ToUpper() == accountName.ToUpper())
                    {
                        return userAccount;
                    }
                }
            }
            catch (Exception)
            {

            }
            return userAccnts;
        }

        /// <summary>
        /// Gets the balance of a user to a specific account
        /// </summary>
        /// <params>UserAccounts Collection</params>
        /// <params>accountName</params>
        /// <returns>BalanceAmount</returns>
        public static decimal GetBalanceByAccount(string accountName, IList<Transaction> transactions)
        {
            var accountBalanceAmount = Decimal.Zero;
            try
            {
                transactions = transactions.Where(x => x.Account.AccountName == accountName).ToList();
                foreach (var transaction in transactions)
                {
                    accountBalanceAmount += transaction.Amount;
                }
            }
            catch (Exception)
            {

            }
            return accountBalanceAmount;
        }

        /// <summary>
        /// Returns user had a specific account or not
        /// </summary>
        /// <params>UserAccounts Collection</params>
        /// <params>accountName</params>
        /// <returns>Bool</returns>
        public static bool HasUserHadAccount(IList<UserAccounts> userAccounts, string accountName)
        {
            var result = false;
            try
            {
                foreach (var userAccount in userAccounts)
                {
                    if (userAccount.Account.AccountName.ToUpper() == accountName.ToUpper())
                    {
                        result = true;
                        break;
                    }
                }
            }
            catch (Exception)
            {

            }
            return result;
        }

        /// <summary>
        /// Find user transactions by accountid and userid
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        /// <returns>List of transactions</returns>
        public static IList<Transaction> FindUserTransactionsByAccountId(int userId, int accountId)
        {
            return MiniStatementRepository.GetUserTransactionsByUserIdandAccountId(userId, accountId);
        }

        /// <summary>
        /// Find user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User data</returns>
        public static User GetUserByEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return new User();
            }
            else
            {
                return MiniStatementRepository.GetUserByEmail(email);
            }
        }

        /// <summary>
        /// Gets Current Available Balance for user
        /// </summary>
        /// <param name="Transaction Collection"></param>
        /// <returns>Current Available Balance</returns>
        public static decimal GetCurrentAvailableBalance(IList<Transaction> transactions)
        {
            var avaiableBalanceAmount = Decimal.Zero;
            try
            {
                foreach (var transaction in transactions)
                {
                    avaiableBalanceAmount += transaction.Amount;
                }
            }
            catch (Exception)
            {

            }
            return avaiableBalanceAmount;
        }

        /// <summary>
        /// Gets user transactions by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Trasaction collection</returns>
        public static IList<Transaction> GetUserTransactionsByUserId(int userId)
        {
            if (userId > 0)
            {
                return MiniStatementRepository.GetUserTransactionsByUserId(userId);
            }
            else
            {
                return new List<Transaction>();
            }
        }

        /// <summary>
        /// Find useraccunt by userid
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>User Account</returns>
        public static List<UserAccounts> GetUserAccountsByUserId(int userId)
        {
            if (userId > 0)
            {
                return MiniStatementRepository.GetUserAccountsByUserId(userId);
            }
            else
            {
                return new List<UserAccounts>();
            }
        }
    }
}

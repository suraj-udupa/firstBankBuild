using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class MiniStatementRepository
    {
        /// <summary>
        /// Gets user by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User Data</returns>
        public static User GetUserByEmail(string email)
        {
            MiniStatementContext miniStatementContext;
            var user = new User();
            try
            {
                using (miniStatementContext = new MiniStatementContext())
                {
                    user = miniStatementContext.Users.Where(x => x.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
               var z =  ex.StackTrace;
            }
            return user;
        }

        /// <summary>
        /// Gets Account by AccountId.
        /// </summary>
        /// <param name="AccountId"></param>
        /// <returns>Account</returns>
        public static Account GetAccountByAccountId(int accountId)
        {
            MiniStatementContext miniStatementContext;
            var account = new Account();
            try
            {
                using (miniStatementContext = new MiniStatementContext())
                {
                    account = miniStatementContext.Accounts.Where(x => x.AccountId == accountId).FirstOrDefault();
                }
            }
            catch (Exception)
            {

            }
            return account;
        }

        /// <summary>
        /// Gets user accounts by userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User Accounts</returns>
        public static List<UserAccounts> GetUserAccountsByUserId(int userId)
        {
            MiniStatementContext miniStatementContext;
            var userAccounts = new List<UserAccounts>();
            try
            {
                using (miniStatementContext = new MiniStatementContext())
                {
                    userAccounts = miniStatementContext.UserAccounts.Include("Account").Where(x => x.UserId == userId).ToList();
                }
            }
            catch (Exception)
            {

            }
            return userAccounts;
        }

        /// <summary>
        /// Gets user transactions by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Trasaction collection</returns>
        public static IList<Transaction> GetUserTransactionsByUserId(int userId)
        {
            MiniStatementContext miniStatementContext;
            var transactions = new List<Transaction>();
            try
            {
                using (miniStatementContext = new MiniStatementContext())
                {
                    transactions = miniStatementContext.Transactions.Include("User").Include("Account").Where(x => x.UserId == userId).ToList();
                }
            }
            catch (Exception)
            {
            }
            return transactions;
        }

        /// <summary>
        /// Gets user transactions by userid and accountId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param> 
        /// <returns>Trasaction collection</returns>
        public static IList<Transaction> GetUserTransactionsByUserIdandAccountId(int userId, int accountId)
        {
            MiniStatementContext miniStatementContext;
            var transactions = new List<Transaction>();
            try
            {
                using (miniStatementContext = new MiniStatementContext())
                {
                    transactions = miniStatementContext.Transactions.Include("User").Include("Account").Where(x => x.UserId == userId && x.AccountId == accountId).ToList();
                }
            }
            catch (Exception)
            {
            }
            return transactions;
        }
    }
}
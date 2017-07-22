using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Data
{
    public class MockData
    {
        public static List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>()
            {
               new Account()
               {
                  AccountName = "Savings Account",
               },
               new Account()
               {
                  AccountName = "Current Account",
               },
               new Account()
               {
                  AccountName = "Senior Citizen Account",
               }
            };
            return accounts;
        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
               new User()
               {
                    Email = "ram@gmail.com",
                    Password = "Password@123"
               },
               new User()
               {
                  Email = "shiva@gmail.com",
                  Password = "Password@123"
               }
            };
            return users;
        }

        public static List<Transaction> GetTransactions(MiniStatementContext context)
        {
            List<Transaction> transactions = new List<Transaction>()
            {
               new Transaction()
               {
                    TransactionDate = DateTime.UtcNow,
                    Description = "Transaction 001 XYZ",
                    Amount = 1000,
                    TransactionType = "Credit",
                    UserId = context.Users.Where(x=>x.Email == "ram@gmail.com").FirstOrDefault().UserId,
                    AccountId = context.Accounts.Where(x=>x.AccountName == "Savings Account").FirstOrDefault().AccountId,
               },
               new Transaction()
               {
                  TransactionDate = DateTime.UtcNow,
                    Description = "Transaction 002 XYZ",
                    Amount = 100,
                    TransactionType = "Debit",
                    UserId = context.Users.Where(x=>x.Email == "ram@gmail.com").FirstOrDefault().UserId,
                    AccountId = context.Accounts.Where(x=>x.AccountName == "Savings Account").FirstOrDefault().AccountId,
               },
               new Transaction()
               {
                    TransactionDate = DateTime.UtcNow,
                    Description = "Transaction 003 XYZ",
                    Amount = 10000,
                    TransactionType = "Credit",
                    UserId = context.Users.Where(x=>x.Email == "ram@gmail.com").FirstOrDefault().UserId,
                    AccountId = context.Accounts.Where(x=>x.AccountName == "Current Account").FirstOrDefault().AccountId,
               },
               new Transaction()
               {
                  TransactionDate = DateTime.UtcNow,
                    Description = "Transaction 004 XYZ",
                    Amount = 1200,
                    TransactionType = "Debit",
                    UserId = context.Users.Where(x=>x.Email == "ram@gmail.com").FirstOrDefault().UserId,
                    AccountId = context.Accounts.Where(x=>x.AccountName == "Current Account").FirstOrDefault().AccountId,
               },
               new Transaction()
               {
                    TransactionDate = DateTime.UtcNow,
                    Description = "Transaction 005 XYZ",
                    Amount = 5000,
                    TransactionType = "Credit",
                    UserId = context.Users.Where(x=>x.Email == "ram@gmail.com").FirstOrDefault().UserId,
                    AccountId = context.Accounts.Where(x=>x.AccountName == "Senior Citizen Account").FirstOrDefault().AccountId,
               },
               new Transaction()
               {
                  TransactionDate = DateTime.UtcNow,
                    Description = "Transaction 006 XYZ",
                    Amount = 400,
                    TransactionType = "Debit",
                    UserId = context.Users.Where(x=>x.Email == "ram@gmail.com").FirstOrDefault().UserId,
                    AccountId = context.Accounts.Where(x=>x.AccountName == "Senior Citizen Account").FirstOrDefault().AccountId,
               },
            };
            return transactions;
        }

        public static List<UserAccounts> GetUserAccounts(MiniStatementContext context)
        {
            List<UserAccounts> userAccounts = new List<UserAccounts>()
            {
               new UserAccounts()
               {
                    UserId = context.Users.Where(x=>x.Email == "ram@gmail.com").FirstOrDefault().UserId,
                    AccountId = context.Accounts.Where(x=>x.AccountName == "Savings Account").FirstOrDefault().AccountId,
                    AccountNumber = "12345678911"
               },
               new UserAccounts()
               {
                    UserId = context.Users.Where(x=>x.Email == "ram@gmail.com").FirstOrDefault().UserId,
                    AccountId = context.Accounts.Where(x=>x.AccountName == "Current Account").FirstOrDefault().AccountId,
                    AccountNumber = "12345678922"
               },
               new UserAccounts()
               {
                    UserId = context.Users.Where(x=>x.Email == "ram@gmail.com").FirstOrDefault().UserId,
                    AccountId = context.Accounts.Where(x=>x.AccountName == "Senior Citizen Account").FirstOrDefault().AccountId,
                    AccountNumber = "12345678933"
               }
            };
            return userAccounts;
        }
    }
}

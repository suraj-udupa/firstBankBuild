using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObject;

namespace FirstIslandBankCorporation.Models
{
    public class UserTransactionsModel
    {
        public UserTransactionsModel()
        {
            UserTransactions = new List<Transaction>();
        }

        public string AccountType { get; set; }

        public string AccountNumber { get; set; }

        public int UserId { get; set; }

        public int AccountId { get; set; }

        public decimal AccountBalance { get; set; }

        public IList<Transaction> UserTransactions { get; set; }
    }
}
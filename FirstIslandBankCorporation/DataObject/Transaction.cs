using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    /// <summary>
    /// UserTransaction Data Object
    /// </summary>
    public class Transaction
    {
        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public string TransactionType { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual IList<Transaction> UserTransactions { get; set; }

        public virtual IList<UserAccounts> UserAccounts { get; set; }
    }
}

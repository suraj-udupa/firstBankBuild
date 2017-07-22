using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class UserAccounts
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int AccountId { get; set; }

        public string AccountNumber { get; set; }

        public virtual User User { get; set; }

        public virtual Account Account { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementConverter.Logic.Model
{
    class CapitalOneRow
    {
        private DateTime transactionDate;
        private string description;
        private string amount;

        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set { transactionDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}

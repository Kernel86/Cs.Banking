/*************************
 * [CTransaction.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-12-06
 *************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Cs.Banking.Business
{
    public class CTransaction
    {
    // Private Fields
        #region "Private Fields"
        private int _iTransactionId;
        private double _dAmount;
        private DateTime _dtDate;
        #endregion

    // Public Properties
        #region "Public Properties"
        public int TransactionId
        {
            get { return _iTransactionId; }
            set { _iTransactionId = value; }
        }

        public double Amount
        {
            get { return _dAmount; }
            set { _dAmount = value; }
        }

        public DateTime Date
        {
            get { return _dtDate; }
            set { _dtDate = value; }
        }
        #endregion

    // Public Constructors
        #region "Public Constructors"
        public CTransaction()
        {

        }

        public CTransaction(int transactionId, double amount, DateTime date)
        {
            _iTransactionId = transactionId;
            _dAmount = amount;
            _dtDate = date;
        }

        public CTransaction(DataRow oDR)
        {
            _iTransactionId = (int)oDR["transaction_id"];
            _dAmount = (double)oDR["transaction_amount"];
            _dtDate = DateTime.Parse((string)oDR["transaction_date"]);
        }
        #endregion
    }
}

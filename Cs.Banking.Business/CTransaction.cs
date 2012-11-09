/*************************
 * [CTransaction.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-11-08
 *************************/

using System;
using System.Collections.Generic;
using System.Linq;
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
        #endregion
    }
}

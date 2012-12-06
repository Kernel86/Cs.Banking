/*************************
 * [CCustomer.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-12-06
 *************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Cs.Banking.Data;

namespace Cs.Banking.Business
{
    public class CCustomer : CPerson
    {
    // Private Fields
        #region "Private Fields"
        private int _iCustomerId;
        private CTransactions _oTransactionList;
        #endregion

    // Public Properties
        #region "Public Properties"
        public int CustomerId
        {
            get { return _iCustomerId; }
            set { _iCustomerId = value; }
        }

        public double LastDepositAmount
        {
            get
            {
                double dLastDepositAmount = 0.0;
                DateTime dtLastDepositDate = DateTime.Parse("01/01/0001");

                foreach (CTransaction oTrasaction in _oTransactionList.Items)
                    if (oTrasaction.Date.CompareTo(dtLastDepositDate) > 0 && oTrasaction.Amount > 0)
                    {
                        dtLastDepositDate = oTrasaction.Date;
                        dLastDepositAmount = oTrasaction.Amount;
                    }

                return dLastDepositAmount;
            }
        }

        public DateTime LastDepositDate
        {
            get
            {
                DateTime dtLastDepositDate = DateTime.Parse("01/01/0001");

                foreach (CTransaction oTrasaction in _oTransactionList.Items)
                    if (oTrasaction.Date.CompareTo(dtLastDepositDate) > 0 && oTrasaction.Amount > 0)
                        dtLastDepositDate = oTrasaction.Date;

                return dtLastDepositDate;
            }
        }

        public double LastWithdrawalAmount
        {
            get
            {
                double dLastWithdrawalAmount = 0.0;
                DateTime dtLastWithdrawalDate = DateTime.Parse("01/01/0001");

                foreach (CTransaction oTrasaction in _oTransactionList.Items)
                    if (oTrasaction.Date.CompareTo(dtLastWithdrawalDate) > 0 && oTrasaction.Amount < 0)
                    {
                        dtLastWithdrawalDate = oTrasaction.Date;
                        dLastWithdrawalAmount = oTrasaction.Amount;
                    }

                return dLastWithdrawalAmount;
            }
        }

        public DateTime LastWithdrawalDate
        {
            get
            {
                DateTime dtLastWithdrawalDate = DateTime.Parse("01/01/0001");

                foreach (CTransaction oTrasaction in _oTransactionList.Items)
                    if (oTrasaction.Date.CompareTo(dtLastWithdrawalDate) > 0 && oTrasaction.Amount < 0)
                        dtLastWithdrawalDate = oTrasaction.Date;

                return dtLastWithdrawalDate;
            }
        }

        public List<CTransaction> DepositList
        {
            get { return this.GetDeposits(); }
        }

        public List<CTransaction> WithdrawalList
        {
            get { return this.GetWithdrawals(); }
        }

        public CTransactions TransactionList
        {
            get { return _oTransactionList; }
            set { _oTransactionList = value; }
        }
        #endregion

    // Public Constructors
        #region "Public Constructors"
        public CCustomer()
        {
            _oTransactionList = new CTransactions();
        }

        public CCustomer(int id, string ssn, string firstname, string lastname, DateTime birthdate, int customerid)
        {
            Id = id;
            SSN = ssn;
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            _iCustomerId = customerid;
            _oTransactionList = new CTransactions();
        }

        public CCustomer(DataRow oDR)
        {
            _iCustomerId = (int)oDR["customer_id"];
            SSN = (string)oDR["ssn"];
            FirstName = (string)oDR["first_name"];
            LastName = (string)oDR["last_name"];
            BirthDate = DateTime.Parse((string)oDR["birth_date"]);
            _oTransactionList = new CTransactions();
        }
        #endregion

    // Public Methods
        public List<CTransaction> GetDeposits()
        {
            List<CTransaction> lstDeposits = new List<CTransaction>();

            foreach (CTransaction oTransaction in _oTransactionList.Items)
                if (oTransaction.Amount > 0)
                    lstDeposits.Add(oTransaction);

            return lstDeposits;
        }

        public List<CTransaction> GetWithdrawals()
        {
            List<CTransaction> lstWithdrawals = new List<CTransaction>();

            foreach (CTransaction oTransaction in _oTransactionList.Items)
                if (oTransaction.Amount < 0)
                    lstWithdrawals.Add(oTransaction);

            return lstWithdrawals;
        }
    }
}

/*************************
 * [CTransactions.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-12-06
 *************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Cs.Banking.Data;

namespace Cs.Banking.Business
{
    public class CTransactions
    {
    // Private Fields
        private List<CTransaction> _glItems;

    // Public Properties
        public int Count
        {
            get { return _glItems.Count; };
        }

        public List<CTransaction> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

    // Public Constructors
        public CTransactions()
        {
            _glItems = new List<CTransaction>();
        }

    // Public Methods
        public void Add(CTransaction oItem)
        {
            _glItems.Add(oItem);
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
        }

        public void GetData(int iCustomerId)
        {
            try
            {
                this.Items = new List<CTransaction>();
                CSQLServer oSQL = new CSQLServer();

                DataTable odtCustomers = oSQL.GetData("SELECT * FROM A6.tblTransactions WHERE customer_id = " + iCustomerId + ";");
                foreach (DataRow oDR in odtCustomers.Rows)
                {
                    this.Add(new CTransaction(oDR));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

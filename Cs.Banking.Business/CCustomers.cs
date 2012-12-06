/*************************
 * [CCustomers.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-11-29
 *************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Cs.Banking.Data;

namespace Cs.Banking.Business
{
    public class CCustomers
    {
    // Private Fields
        private List<CCustomer> _glItems;

    // Public Properties
        public List<CCustomer> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

    // Public Constructors
        public CCustomers()
        {
            _glItems = new List<CCustomer>();
        }

    // Events
        public event EventHandler CustomersChanged;

    // Public Methods
        public int Count()
        {
            return _glItems.Count;
        }

        public void Add(CCustomer oItem)
        {
            _glItems.Add(oItem);
            CustomersChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            CustomersChanged(this, new EventArgs());
        }

        // Populate the object
        public void Populate()
        {
            try
            {
                // Use the CStatic class for static values
                CStatic oStatic = new CStatic();
                ParseCustomers(oStatic.StaticCustomers());
                oStatic = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save()
        {
            try
            {
                CXml oXml = new CXml(Properties.Settings.Default.Filename);
                oXml.Serialize(Items, typeof(List<CCustomer>));

                oXml = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Load()
        {
            try
            {
                CXml oXml = new CXml(Properties.Settings.Default.Filename);
                Items = (List<CCustomer>)oXml.Deserialize(typeof(List<CCustomer>));

                oXml = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    // Private Methods
        private void ParseCustomers(string sCustomers)
        {
            try
            {
                CStatic oStatic = new CStatic();

                string[] sSplit = sCustomers.Split('\n');
                
                // Make a new Customer with Transactions frm each Customer record
                foreach (string sCustomer in sSplit)
                {
                    if (sCustomer.Length > 0)
                    {
                        string[] sFields = sCustomer.Split('|');

                        CCustomer oCustomer = new CCustomer(int.Parse(sFields[0]), sFields[1], sFields[2], sFields[3], DateTime.Parse(sFields[4]), int.Parse(sFields[5]));

                        oCustomer.TransactionList.Items = ParseTransactions(oStatic.StaticTransactions(int.Parse(sFields[5])));
                        this.Add(oCustomer);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<CTransaction> ParseTransactions(string sTransactions)
        {
            try
            {
                List<CTransaction> oTransactions = new List<CTransaction>();
                string[] sSplit = sTransactions.Split('\n');

                // Make a new Transactions collection
                foreach (string sTransaction in sSplit)
                {
                    string[] sFields = sTransaction.Split('|');
                    CTransaction oTransaction = new CTransaction(int.Parse(sFields[0]), double.Parse(sFields[1]), DateTime.Parse(sFields[2]));
                    oTransactions.Add(oTransaction);
                    oTransaction = null;
                }

                return oTransactions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

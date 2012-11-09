/*************************
 * [CTransactions.cs]
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
    public class CTransactions
    {
    // Private Fields
        private List<CTransaction> _glItems;

    // Public Properties
        public List<CTransaction> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

    // Public Methods
        public int Count()
        {
            return _glItems.Count;
        }

        public void Add(CTransaction oItem)
        {
            _glItems.Add(oItem);
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
        }

    // Public Constructors
        public CTransactions()
        {
            _glItems = new List<CTransaction>();
        }
    }
}

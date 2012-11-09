/*************************
 * [CFile.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-11-08
 *************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cs.Banking.Data
{
    public class CFile
    {
    // Private Fields
        private string _sFilename;

    // Public Properties
        public string Filename
        {
            get { return _sFilename; }
            set { _sFilename = value; }
        }

    // Constructors
        public CFile()
        {

        }

        public CFile(string sFilename)
        {
            _sFilename = sFilename;
        }

    // Public Methods
    }
}

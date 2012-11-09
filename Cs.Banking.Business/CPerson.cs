/*************************
 * [CPerson.cs]
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
    public class CPerson
    {
    // Private Fields
        #region "Private Fields"
        private int _iId;
        private string _sSSN;
        private string _sFirstName;
        private string _sLastName;
        private DateTime _dtBirthDate;
        #endregion

    // Public Properties
        #region "Public Properties"
        public int Id
        {
            get { return _iId; }
            set { _iId = value; }
        }

        public string SSN
        {
            get { return _sSSN; }
            set { _sSSN = value; }
        }

        public string FirstName
        {
            get { return _sFirstName; }
            set { _sFirstName = value; }
        }

        public string LastName
        {
            get { return _sLastName; }
            set { _sLastName = value; }
        }

        public string FullName
        {
            get { return _sFirstName + " " + _sLastName; }
        }

        public int Age
        {
            get { return (DateTime.Now.Year - _dtBirthDate.Year); }
        }

        public DateTime BirthDate
        {
            get { return _dtBirthDate; }
            set { _dtBirthDate = value; }
        }
        #endregion

    // Public Constructors
        #region "Public Constructors"
        public CPerson()
        {

        }
        #endregion
    }
}

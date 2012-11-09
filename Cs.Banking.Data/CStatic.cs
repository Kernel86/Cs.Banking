/*************************
 * [CStaic.cs]
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
    public class CStatic
    {
        public string StaticCustomers()
        {
            string sCustomers = "1|234-82-1497|Bob|Villa|11-24-1966|1\n"
                              + "2|935-12-2045|Sam|Summer|09-11-1959|2\n"
                              + "3|173-06-1258|Homer|Ruth|03-30-1973|3";
                  
            return sCustomers;
        }

        public string StaticTransactions(int iCustomerId)
        {
            string sTransactions;

            switch (iCustomerId)
            {
            case 1:
                sTransactions = "1|2500.00|11-01-2012\n"
                              + "2|-505.13|11-02-2012\n"
                              + "3|-46.67|11-05-2012\n"
                              + "4|250.47|11-05-2012\n"
                              + "5|-13.99|11-07-2012\n"
                              + "6|515.51|11-09-2012";
                break;
            case 2:
                sTransactions = "1|500.00|10-10-2012\n"
                              + "2|-234.00|11-01-2012\n"
                              + "3|200.11|11-02-2012\n"
                              + "4|-125.99|11-02-2012\n"
                              + "5|-13.99|11-07-2012\n"
                              + "6|100.10|11-07-2012";
                break;
            case 3:
                sTransactions = "1|5000.00|10-02-2012\n"
                              + "2|5500.75|10-09-2012\n"
                              + "3|-99.67|10-20-2012\n"
                              + "4|-1000.26|11-05-2012\n"
                              + "5|-13.99|11-07-2012\n"
                              + "6|625.01|11-08-2012";
                break;
            default:
                sTransactions = "";
                break;
            }

            return sTransactions;
        }
    }
}

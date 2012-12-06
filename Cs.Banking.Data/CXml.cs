/*************************
 * [CXml.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-11-29
 *************************/


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Cs.Banking.Data
{
    public class CXml : CFile
    {
    // Private Fields

    // Public Properties

    // Constructors
        public CXml()
        {

        }

        public CXml(string sFilename)
        {
            Filename = sFilename;
        }

    // Public Methods
        public void Serialize(object oInObject, Type oInObjectType)
        {
            try
            {
                Delete();

                TextWriter oTextWriter = new StreamWriter(Filename);
                XmlSerializer oSerializer = new XmlSerializer(oInObjectType);
                oSerializer.Serialize(oTextWriter, oInObject);

                oTextWriter.Close();
                oTextWriter.Dispose();
                oTextWriter = null;
                oSerializer = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Deserialize(Type oObjectType)
        {
            TextReader oTextReader = new StreamReader(Filename);
            XmlSerializer oSerializer = new XmlSerializer(oObjectType);
            object oTemp = oSerializer.Deserialize(oTextReader);

            oTextReader.Close();
            oTextReader.Dispose();
            oTextReader = null;
            oSerializer = null;

            return oTemp;
        }
    }
}

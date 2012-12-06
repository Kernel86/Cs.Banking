/*************************
 * [CFile.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-11-29
 *************************/

using System;
using System.Collections.Generic;
using System.IO;
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
        public string Read()
        {
            try
            {
                StreamReader oReader = new StreamReader(_sFilename);
                oReader = File.OpenText(_sFilename);
                string sContents = oReader.ReadToEnd();

                oReader.Close();
                oReader.Dispose();
                oReader = null;

                return sContents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Write(string sContents)
        {
            try
            {
                Delete();

                StreamWriter oWriter = File.CreateText(_sFilename);
                oWriter.Write(sContents);

                oWriter.Close();
                oWriter.Dispose();
                oWriter = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete()
        {
            try
            {
                if (File.Exists(_sFilename))
                    File.Delete(_sFilename);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

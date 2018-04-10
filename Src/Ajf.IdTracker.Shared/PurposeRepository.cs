using System;
using System.Configuration;
using System.IO;

namespace Ajf.IdTracker.Shared
{
    public class CsvPurposeRepository : IPurposeRepository
    {
        private string _csvFileName;

        public CsvPurposeRepository():this(ConfigurationManager.AppSettings["CsvPurposeLocation"])
        {
        }

        public CsvPurposeRepository(string csvFileName)
        {
            _csvFileName = csvFileName;
        }

        public string[] GetItems()
        {
            return File.ReadAllLines(_csvFileName);
        }
    }
}

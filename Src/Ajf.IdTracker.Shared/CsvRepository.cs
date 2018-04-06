using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace Ajf.IdTracker.Shared
{
    public class CsvRepository : IRepository
    {
        public class StrItemClassMap : ClassMap<UniqueNumber>
        {
            public StrItemClassMap()
            {
                AutoMap();
                Map(m => m.Id);
                Map(m => m.Name);
                Map(m => m.Cpr);
                Map(m => m.Date);
                Map(m => m.Purpose);
                Map(m => m.TrialNumber);
            }
        }

        private string _csvFileName;

        public CsvRepository():this(ConfigurationManager.AppSettings["CsvLocation"])
        {
        }

        public CsvRepository(string csvFileName)
        {
            _csvFileName = csvFileName;
        }

        public IEnumerable<UniqueNumber> GetUniqueNumbers(StreamReader streamReader)
        {
            if (File.Exists(_csvFileName))
            {

                var csv = new CsvReader(streamReader);
                csv.Configuration.HasHeaderRecord = true;

                csv.Configuration.RegisterClassMap(typeof(StrItemClassMap));
                return csv.GetRecords<UniqueNumber>().ToList();
            }

            return new List<UniqueNumber>();
        }

        public UniqueNumber GetUniqueNewNumber2(DateTime date, string cpr)
        {
            if(!File.Exists(_csvFileName))
            {
                return UniqueNumber.Create(date, 1, cpr);
            }

            using (var fileReader = File.OpenText(_csvFileName))
            {
                var uniqueNumbers = GetUniqueNumbers(fileReader);

                var fromDate = uniqueNumbers.Where(x => x.Date == date);
                var maxTrialNumber = fromDate.Any() ?
                    fromDate.Max(x => x.TrialNumber) :
                    0;

                var newUniqueNumber = UniqueNumber.Create(date, maxTrialNumber + 1, cpr);
                return newUniqueNumber;
            };
        }

        public void Add(UniqueNumber newUniqueNumber)
        {
            var fileWasThere = File.Exists(_csvFileName);

            using (TextWriter fileReader = File.AppendText(_csvFileName))
            {
                var csv = new CsvWriter(fileReader);

                if(!fileWasThere)
                {
                    csv.WriteHeader<UniqueNumber>();
                    csv.NextRecord();
                }

                //csv.Configuration.HasHeaderRecord = true;
                //csv.Configuration.Delimiter = ";";
                csv.Configuration.QuoteAllFields = true;
                csv.Configuration.RegisterClassMap(typeof(StrItemClassMap));

                csv.WriteRecord(newUniqueNumber);
                csv.NextRecord();
            }
        }
    }
}

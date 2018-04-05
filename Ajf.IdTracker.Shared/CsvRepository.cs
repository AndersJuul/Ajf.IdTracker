using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using CsvHelper;
using System.Globalization;
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
                //Map(m => m.Id).TypeConverterOption(CultureInfo.CurrentCulture);
                //Map(m => m.Name).TypeConverterOption(CultureInfo.CurrentCulture);
                //Map(m => m.Cpr).TypeConverterOption(CultureInfo.CurrentCulture);
                //Map(m => m.Date).TypeConverterOption(CultureInfo.CurrentCulture);
                //Map(m => m.Purpose).TypeConverterOption(CultureInfo.CurrentCulture);
                //Map(m => m.TrialNumber).TypeConverterOption(CultureInfo.InvariantCulture);
            }
        }

        private string _csvFileName;

        public CsvRepository()
        {
            _csvFileName = ConfigurationManager.AppSettings["CsvLocation"];
        }

        public IEnumerable<UniqueNumber> GetUniqueNumbers(StreamReader streamReader)
        {
            if (File.Exists(_csvFileName))
            {

                var csv = new CsvReader(streamReader);
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.Encoding = Encoding.UTF8;

                csv.Configuration.RegisterClassMap(typeof(StrItemClassMap));
                return csv.GetRecords<UniqueNumber>().ToList();
            }

            return new List<UniqueNumber>();
        }

        public string GetUniqueNewNumber(DateTime date)
        {
            var newUniqueNumber= GetUniqueNewNumber2(date);

            Add(newUniqueNumber);

            return "";
        }

        private UniqueNumber GetUniqueNewNumber2(DateTime date)
        {
            using (var fileReader = File.OpenText(_csvFileName))
            {
                var uniqueNumbers = GetUniqueNumbers(fileReader);

                var fromDate = uniqueNumbers.Where(x => x.Date == date);
                var maxTrialNumber = fromDate.Any() ?
                    fromDate.Max(x => x.TrialNumber) :
                    0;

                var newUniqueNumber = new UniqueNumber()
                {
                    Date = date,
                    TrialNumber = maxTrialNumber + 1
                };

                return newUniqueNumber;
            };
        }

        private void Add(UniqueNumber newUniqueNumber)
        {
            using (TextWriter fileReader = File.AppendText(_csvFileName))
            {
                var csv = new CsvWriter(fileReader);
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.RegisterClassMap(typeof(StrItemClassMap));

                csv.WriteRecord<UniqueNumber>(newUniqueNumber);
                csv.NextRecord();
            }
        }
    }
}

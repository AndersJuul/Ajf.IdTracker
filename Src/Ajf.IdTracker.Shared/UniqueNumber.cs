using System;

namespace Ajf.IdTracker.Shared
{
    public class UniqueNumber
    {
        public static UniqueNumber Create(DateTime date, int trialNumber, string cpr, string name, string purpose)
        {
            var un = new UniqueNumber()
            {
                Date = date,
                Cpr = cpr,
                TrialNumber = trialNumber,
                Name=name,
                Id= date.ToString("yyyyMMdd") + "-" + trialNumber.ToString("00"),
                Purpose=purpose
            };

            return un;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Cpr { get; set; }
        public DateTime Date { get; set; }
        public int TrialNumber { get; set; }
        public string Purpose { get; set; }
    }
}
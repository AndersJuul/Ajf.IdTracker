using System;

namespace Ajf.IdTracker.Shared
{
    public class UniqueNumber
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public string Cpr { get; internal set; }
        public DateTime Date { get; internal set; }
        public int TrialNumber { get; internal set; }
        public string Purpose { get; internal set; }
    }
}
using System;
using System.Windows;

namespace Ajf.IdTracker.Shared
{
    public class MainViewModel 
    {
        private readonly IUniqueNumberProvider _uniqueNumberProvider;

        public MainViewModel(IUniqueNumberProvider uniqueNumberProvider)
        {
            _uniqueNumberProvider = uniqueNumberProvider;

            Cpr = "031069-0503";
        }

        public string Title => "Risk";

        public string Cpr { get; set; }

        public void Generate()
        {
            var date = DateTime.Today;

            var uniqueNewNumber= _uniqueNumberProvider
                .GetUniqueNewNumber(date, Cpr);

            Clipboard.SetText(uniqueNewNumber);
        }
    }
}

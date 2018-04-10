using System;
using System.Linq;
using System.Windows;

namespace Ajf.IdTracker.Shared
{
    public class MainViewModel : IMainViewModel
    {
        private readonly IUniqueNumberProvider _uniqueNumberProvider;

        public MainViewModel(IUniqueNumberProvider uniqueNumberProvider)
        {
            _uniqueNumberProvider = uniqueNumberProvider;

            Cpr = "031069-0503";
        }

        public string Title => "Risk";

        public string Cpr { get; set; }

        public string Name { get; set; }

        public int PurposeId { get; set; }
        public string Purpose
        {
            get
            {
                return _purposeItems[PurposeId];
            }
        }

        private string[] _purposeItems;
        public string[] PurposeItems
        {
            get { return _purposeItems; }
            set
            {
                _purposeItems = value;
            }
        }


        public void Generate()
        {
            var date = DateTime.Today;

            var uniqueNewNumber = _uniqueNumberProvider
                .GetUniqueNewNumber(date, Cpr, Name, Purpose);

            Clipboard.SetText(uniqueNewNumber);
        }
    }
}

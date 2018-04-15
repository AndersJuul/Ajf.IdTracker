using System;
using System.Configuration;
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
        }

        public string Title => "IdTracker";

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


        public string Generate()
        {
            var date = DateTime.Today;

            var uniqueNewNumber = _uniqueNumberProvider
                .GetUniqueNewNumber(date, Cpr, Name, Purpose, ConfigurationManager.AppSettings["EquipmentID"]);

            Clipboard.SetText(uniqueNewNumber);

            return uniqueNewNumber;
        }
    }
}

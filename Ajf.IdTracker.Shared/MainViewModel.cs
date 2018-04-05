using System;
using System.Windows;

namespace Ajf.IdTracker.Shared
{
    public class MainViewModel 
    {
        private IRepository _cvsRepository;

        public MainViewModel(IRepository cvsRepository)
        {
            _cvsRepository = cvsRepository;
            Cpr = "031069-0503";
        }

        public string Title => "Risk";

        public string Cpr { get; set; }

        public void Generate()
        {
            var date = DateTime.Today;

            var uniqueNewNumber= _cvsRepository
                .GetUniqueNewNumber(date, Cpr);

            Clipboard.SetText(uniqueNewNumber);
        }
    }
}

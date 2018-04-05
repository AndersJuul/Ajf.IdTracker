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
        }

        public string Title => "Risk";

        public void Generate()
        {
            var date = DateTime.Today;

            var uniqueNewNumber= _cvsRepository.GetUniqueNewNumber(date);

            Clipboard.SetText(uniqueNewNumber);
        }
    }
}

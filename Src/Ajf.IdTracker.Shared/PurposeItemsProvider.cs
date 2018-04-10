using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajf.IdTracker.Shared
{
    public class PurposeItemsProvider : IPurposeItemsProvider
    {
        private readonly IPurposeRepository _purposeRepository;

        public PurposeItemsProvider(IPurposeRepository purposeRepository)
        {
            _purposeRepository = purposeRepository;
        }
        public string[] GetPurposeItems()
        {
            return _purposeRepository.GetItems();
        }
    }
}

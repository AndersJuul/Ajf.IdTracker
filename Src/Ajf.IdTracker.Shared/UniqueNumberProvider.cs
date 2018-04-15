using System;

namespace Ajf.IdTracker.Shared
{
    public class UniqueNumberProvider : IUniqueNumberProvider
    {
        private readonly IRepository _repository;

        public UniqueNumberProvider(IRepository repository)
        {
            _repository = repository;
        }
        public string GetUniqueNewNumber(DateTime date, string cpr, string name, string purpose, string equipmentID)
        {
            var newUniqueNumber = _repository.GetUniqueNewNumber2(date, cpr, name, purpose, equipmentID);

            _repository.Add(newUniqueNumber);

            return newUniqueNumber.Id;
        }
    }
}
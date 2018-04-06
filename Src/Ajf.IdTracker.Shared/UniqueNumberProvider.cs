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
        public string GetUniqueNewNumber(DateTime date, string cpr, string name)
        {
            var newUniqueNumber = _repository.GetUniqueNewNumber2(date, cpr, name);

            _repository.Add(newUniqueNumber);

            return newUniqueNumber.Id;
        }
    }
}
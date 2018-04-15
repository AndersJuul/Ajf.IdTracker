using System;

namespace Ajf.IdTracker.Shared
{
    public interface IRepository
    {
        UniqueNumber GetUniqueNewNumber2(DateTime date, string cpr, string name, string purpose, string equipmentID);
        void Add(UniqueNumber newUniqueNumber);
    }
}
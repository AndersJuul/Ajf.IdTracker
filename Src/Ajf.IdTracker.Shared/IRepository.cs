using System;

namespace Ajf.IdTracker.Shared
{
    public interface IRepository
    {
        UniqueNumber GetUniqueNewNumber2(DateTime date, string cpr);
        void Add(UniqueNumber newUniqueNumber);
    }
}
using System;

namespace Ajf.IdTracker.Shared
{
    public interface IUniqueNumberProvider
    {
        string GetUniqueNewNumber(DateTime date, string cpr, string name, string purpose, string equipmentID);
    }
}
using System;

namespace Ajf.IdTracker.Shared
{
    public interface IUniqueNumberProvider
    {
        string GetUniqueNewNumber(DateTime date, string cpr);
    }
}
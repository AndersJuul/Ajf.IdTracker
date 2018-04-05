using System;

namespace Ajf.IdTracker.Shared
{
    public interface IRepository
    {
        string GetUniqueNewNumber(DateTime date, string cpr);
    }
}
using StructureMap;

namespace Ajf.IdTracker.Shared
{
    public class IdTrackerSharedRegistry : Registry
    {
        public IdTrackerSharedRegistry()
        {
            Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });

            For<IRepository>().Use<CsvRepository>();
            For<IPurposeRepository>().Use<CsvPurposeRepository>();
        }
    }
}
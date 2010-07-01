using StructureMap;
using StructureMap.Configuration.DSL;

namespace jqGridAddEditDelete
{
    public static class Bootstrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new MyApplicationRegistry()));
        }
    }

    public class MyApplicationRegistry : Registry
    {
        public MyApplicationRegistry()
        {
            Scan(assemblyScanner =>
            {
                assemblyScanner.TheCallingAssembly();
                assemblyScanner.WithDefaultConventions();
            });
        }
    }
}


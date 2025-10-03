using MosaicCRM.Core.Modularity.Abstractions;

namespace MosaicCRM.Core.Modularity
{
    public static class ModuleInitializer
    {
        private static readonly List<Type> _modules = [];
        public static void AddModule<TModule>() where TModule : ICrmModule
        {
            _modules.Add(typeof(TModule));
        }

        internal static IEnumerable<Type> Modules => _modules.AsEnumerable();
    }
}

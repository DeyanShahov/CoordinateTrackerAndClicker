using CoordinateTrackerAndClicker.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoordinateTrackerAndClicker.Db_Json
{
    internal class MacroStorageManager
    {
        private IDataStorageStrategy _dataStorageStrategy;

        public MacroStorageManager(IDataStorageStrategy dataStorageStrategy)
        {
            _dataStorageStrategy = dataStorageStrategy;
        }

        public void SetStrategy(IDataStorageStrategy strategy) => _dataStorageStrategy = strategy;
        public Task <List<Macro>> LoadMacroAsync() =>  _dataStorageStrategy.LoadMacrosAsync();
        public Task<bool> SaveMacros(List<Macro> macros) => _dataStorageStrategy.SaveMacrosAsync(macros);
        public Task<bool> DeleteMacro(Macro macro) => _dataStorageStrategy.DeleteMacroAsync(macro);
    }
}

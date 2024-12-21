using CoordinateTrackerAndClicker.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoordinateTrackerAndClicker.Db_Json
{
    public interface IDataStorageStrategy
    {
        Task<List<Macro>> LoadMacrosAsync();

        Task<bool> SaveMacrosAsync(List<Macro> macros);

        Task<bool> DeleteMacroAsync(Macro macro);
    }
}

using CoordinateTrackerAndClicker.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoordinateTrackerAndClicker.Db_Json
{
    internal class JsonDataStorage : IDataStorageStrategy
    {
        private readonly string SaveFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Save");
        private readonly string SaveFilePath;

        public JsonDataStorage()
        {
            SaveFilePath = Path.Combine(SaveFolder, "SaveMacros.json");
            if (!Directory.Exists(SaveFolder)) Directory.CreateDirectory(SaveFolder);
            if (!File.Exists(SaveFilePath)) File.WriteAllText(SaveFilePath, "[]");
        }

        public async Task<bool> DeleteMacroAsync(Macro macro)
        {
            try
            {
                var macros = await LoadMacrosAsync();
                var macroToDelete = macros.FirstOrDefault(m => m.Name == macro.Name);
                if (macroToDelete != null)
                {
                    macros.Remove(macroToDelete);
                    await SaveMacrosAsync(macros);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }                      
        }

        public async Task<List<Macro>> LoadMacrosAsync()
        {
            if (File.Exists(SaveFilePath))
            {
                using (FileStream openStream = new FileStream(SaveFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return await JsonSerializer.DeserializeAsync<List<Macro>>(openStream) ?? new List<Macro>();
                }
            }
            return new List<Macro>();
        }

        public async Task<bool> SaveMacrosAsync(List<Macro> macros)
        {
            try
            {
                // Създаване на поток към файла
                using (FileStream createStream = new FileStream(SaveFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    // Асинхронно сериализиране на обектите в JSON файл await
                    await JsonSerializer.SerializeAsync(createStream, macros, new JsonSerializerOptions { WriteIndented = true });
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

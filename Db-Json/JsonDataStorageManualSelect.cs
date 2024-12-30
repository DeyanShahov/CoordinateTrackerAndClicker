using CoordinateTrackerAndClicker.Core.Models;
using CoordinateTrackerAndClicker.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker.Db_Json
{
    internal class JsonDataStorageManualSelect : IDataStorageStrategy
    {
        private readonly string PathConfigFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MacroSavePath.json");
        private string SaveFolder;
        public static string SaveFilePath;
        private bool isSaveArchiveOK;

        public JsonDataStorageManualSelect()
        {
            isSaveArchiveOK = LoadSavePath();
            //EnsureSaveFileExists();
        }

        /// <summary>
        /// Зарежда пътя до директорията от MacroSavePath.json.
        /// </summary>
        private bool LoadSavePath()
        {
            if (File.Exists(PathConfigFile))
            {
                var pathConfig = File.ReadAllText(PathConfigFile);
                SaveFolder = JsonSerializer.Deserialize<string>(pathConfig) ?? string.Empty;
                SaveFilePath = Path.Combine(SaveFolder, "SaveMacros.json");
                return true;
            }
            return false;       
        }

        /// <summary>
        /// Проверява дали SaveMacros.json съществува и го създава, ако е необходимо.
        /// </summary>
        private void EnsureSaveFileExists()
        {
            if (!Directory.Exists(SaveFolder))
            {
                Directory.CreateDirectory(SaveFolder);
            }

            if (!File.Exists(SaveFilePath))
            {
                File.WriteAllText(SaveFilePath, "[]");
            }
        }

        public bool CheckForDirectoryFileExists()
        {          
            return (Directory.Exists(SaveFolder) && File.Exists(SaveFilePath));
        }

        /// <summary>
        /// Позволява на потребителя да избере нова директория за запазване.
        /// </summary>
        public void SetSaveDirectory()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = LanguageManager.GetString(SAM.SET_SAVE_DIRECTORY);
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFolder = folderDialog.SelectedPath;
                    SaveFilePath = Path.Combine(SaveFolder, "SaveMacros.json");

                    // Запазване на новия път в MacroSavePath.json
                    var json = JsonSerializer.Serialize(SaveFolder, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(PathConfigFile, json);

                    // Създаване на SaveMacros.json, ако не съществува
                    EnsureSaveFileExists();
                }
            }
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
                using (FileStream createStream = new FileStream(SaveFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
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

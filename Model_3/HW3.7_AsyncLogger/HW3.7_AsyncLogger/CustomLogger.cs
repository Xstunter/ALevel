using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace HW3._7_AsyncLogger
{
    internal sealed class Config
    {
        public int Count { get; set; }   //for json  file
    }
    internal sealed class CustomLogger
    {
        public event Action Logic;

        public async Task<bool> BackUp()
        {

            string filePath = "D:\\C#\\HW3.7_AsyncLogger\\HW3.7_AsyncLogger\\BackupFiles\\";
            string fileName = DateTime.Now.ToString("MM_dd_yyyy");

            string jsonFile = File.ReadAllText("config.json");
            
            var config = JsonSerializer.Deserialize<Config>(jsonFile);

            for (int i = 1; i < config.Count + 1; i++)
            {
                string path = Path.Combine($"{filePath}", $"{fileName + "_" + i}.txt");

                await CreateFileAsync(path);
                
                if (!File.Exists(path))
                {
                    return false;
                }
                
            }
            return true;
        }
        public async Task StartEvent()
        {
            Logic?.Invoke();
        }
        private async Task CreateFileAsync(string path)
        {
            using (var file = File.Create(path))
            {
                
            }
        }
    }
}

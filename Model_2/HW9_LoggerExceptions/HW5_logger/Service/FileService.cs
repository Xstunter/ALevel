using HW9_LoggerExceptions.Service.Abstracts;
using Microsoft.Extensions.Configuration;

namespace HW9_LoggerExceptions.Service
{
    public class FileService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public FileService(ILogger logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public void InputTextInFile()
        {
            string logFilePath = _configuration["Path"];

            string logs = _logger.GetLogs();

            string logName = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss");
            string filePath = Path.Combine($"{logFilePath}", $"{logName}.txt");

            File.WriteAllText(filePath, logs);

            DeleteOldFiles(logFilePath, 3);
        }

        private void DeleteOldFiles(string directoryPath, int maxFiles)
        {
            var files = Directory.GetFiles(directoryPath)
                                 .OrderBy(f => new FileInfo(f).CreationTime)
                                 .ToList();

            while (files.Count > maxFiles)
            {
                File.Delete(files[0]);
                files.RemoveAt(0);
            }
        }

    }
}

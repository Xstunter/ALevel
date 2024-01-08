using HW9_LoggerExceptions.Enum;
using HW9_LoggerExceptions.Service.Abstracts;

namespace HW9_LoggerExceptions.Service
{
    public class Logger : ILogger
    {
        private static string _logs = string.Empty;
        
        public void Log(TypeOf type, string message)
        {
            string log_time = DateTime.Now.ToString();
            _logs += $"{log_time}: {type}: {message}\n";
            Console.WriteLine($"{log_time}: {type}: {message}");
        }

        public string GetLogs()
        { 
            return _logs;
        }
    }
}

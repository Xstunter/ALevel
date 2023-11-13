using HW9_LoggerExceptions.Enum;

namespace HW9_LoggerExceptions.Service.Abstracts
{
    public interface ILogger
    {
        public void Log(TypeOf type, string massege);
        public string GetLogs();
    }
}

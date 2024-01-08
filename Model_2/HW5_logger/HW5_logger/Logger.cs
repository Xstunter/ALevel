namespace HW5_logger
{
    internal class Logger
    {
        private static readonly Logger instance = new Logger();

        private string _logs;
        static Logger()
        {
        }

        private Logger() 
        {
            _logs = string.Empty;
        }
        
        public static Logger Instance
        {
            get 
            {
                return instance;
            }
        }

        public void Log(string log_type, string message) 
        {
            string log_time = DateTime.Now.ToString();
            _logs += $"{log_time}: {log_type}: {message}\n";
            Console.WriteLine($"{log_time}: {log_type}: {message}");
        }

        public string GetLogs()
        {
            return _logs;
        }
    }
}

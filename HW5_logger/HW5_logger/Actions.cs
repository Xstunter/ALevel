namespace HW5_logger
{
    internal class Result
    {
        public bool _status { get; set; }
        public string _errorMessege { get; set; }

    }
    internal class Actions
    {
        private Logger logger;
        public Actions()
        {
            logger = Logger.Instance;
        }

        public Result StartMethod()
        {
            logger.Log("Info", "Start Method");
            return new Result { _status = true };
        }
        public Result MissingLogic(string methodName) 
        {
            logger.Log("Warning", $"Skipped logic in method: {methodName}");
            return new Result { _status = true };
        }
        public Result BrokenLogic()
        {
            logger.Log("Error", "I broke a logic");
            return new Result { _status = false, _errorMessege = "I broke a logic" };
        }
    }
}

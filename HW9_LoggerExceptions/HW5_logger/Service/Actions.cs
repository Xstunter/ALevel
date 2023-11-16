using HW9_LoggerExceptions.Enum;
using HW9_LoggerExceptions.Exceptions;
using HW9_LoggerExceptions.Service.Abstracts;

namespace HW9_LoggerExceptions.Service
{
    internal class Actions : IActions
    {
        private readonly ILogger _logger;
        public Actions(ILogger logger)
        {
            _logger = logger;
        }
        public void StartMethod()
        {
            _logger.Log(TypeOf.Info, "Start method");
        }
        public void MissingLogic()
        {
            try
            {
                throw new BusinessException("Skipped logic in method");
            }
            catch (BusinessException e)
            {
                string msg = $"Action got this custom Exception: {e.Message}";
                _logger.Log(TypeOf.Warning, msg);
            }
        }
        public void BrokenLogic()
        {
            try
            {
                throw new Exception("I broke a logic");
            }
            catch (Exception e)
            {
                string msg = $"Action failed by reason: {e.Message}";
                _logger.Log(TypeOf.Error, msg);
            }
        }
    }
}
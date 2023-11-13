using HW9_LoggerExceptions.Service;
using HW9_LoggerExceptions.Service.Abstracts;

namespace HW5_logger
{
    internal class Starter
    {
        private readonly IActions _action;
        private readonly FileService _fileService;
        public Starter(IActions action, FileService fileService)
        {
            _action = action;
            _fileService = fileService;

        }
        public void Run()
        {
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {

                int randomNumber = rand.Next(1, 4);

                if (randomNumber == 1)
                {
                    _action.StartMethod();
                }
                else if (randomNumber == 2)
                {
                    _action.MissingLogic();
                }
                else
                {
                    _action.BrokenLogic();
                }
            }

            _fileService.InputTextInFile();
        }
    }
}

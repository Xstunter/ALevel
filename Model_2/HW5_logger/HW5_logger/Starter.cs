namespace HW5_logger
{
    internal class Starter
    {
        public void Run()
        {
            Actions actions = new Actions();

            Random rand = new Random();

            int _count = 1;

            for (int i = 0; i < 100; i++)
            {
                int randomNumber = rand.Next(1, 4);

                if (randomNumber == 1)
                {
                    actions.StartMethod();
                }
                else if (randomNumber == 2) 
                {
                    actions.MissingLogic($"Method {_count}");
                    _count++;
                }
                else
                {
                    Result result = actions.BrokenLogic();
                    if(!result._status) 
                    {
                        Logger.Instance.Log("Error", $"Action failed by a reason: {result._errorMessege}");
                    }
                }
            }

            string logs = Logger.Instance.GetLogs();
            System.IO.File.WriteAllText("D:\\C#\\Turtle\\ALevel\\HW5_logger\\logs.txt", logs);
        }
    }
}

using HW3._6_Lock.Enums;
using System;
using System.Threading.Tasks;

namespace HW3._6_Lock
{
    public sealed class MessageBox
    {
        private int _number = 1;

        private string _message;

        public event EventHandler<EventArgs> Message;
    
        public async void OpenAsync()  //Типу у мене async метод, але навіщо? типу не знаю що робити з ним
        {
            TaskCompletionSource<string> taskSource = new TaskCompletionSource<string>();

            Console.WriteLine("Window is open");
            
            Console.CancelKeyPress += (o, e) =>
            {
                taskSource.SetResult("Window was closed by the user");
                e.Cancel = true;
                _number = 2;
                Console.WriteLine(_message);
            };

            _message = await taskSource.Task;
        }
        public void EventStart()
        {
            Message?.Invoke(this, EventArgs.Empty);
        }
        public void StartEvent(object o, EventArgs e) 
        {
            if((int)State.Ok == _number)
            {
                Console.WriteLine("The operation has been confirmed");
            }
            else
            {
                Console.WriteLine("The operation was rejected");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3._7_AsyncLogger
{
    internal sealed class App
    {
        public async Task Start()
        {
            CustomLogger log = new CustomLogger();

            log.Logic += async () =>
            {
                var compete = await log.BackUp();
                Console.WriteLine($"Operation is competed? {compete}");
            };
            log.Logic += async () =>
            {
                var compete = await log.BackUp();
                Console.WriteLine($"Operation is competed? {compete}");
            };

            await log.StartEvent();
        }
         
    }
}

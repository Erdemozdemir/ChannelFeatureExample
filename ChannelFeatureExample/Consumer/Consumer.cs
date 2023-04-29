using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChannelFeatureExample.Consumer
{
    public static class Consumer
    {
        public static Task ConsumeData<T>(Channel<T> channel)
        {
            var consumer = Task.Run(async () =>
            {
                await foreach (var item in channel.Reader.ReadAllAsync())
                {
                    Console.WriteLine($"Consuming Message: {item}");
                }
            });

            return Task.CompletedTask;
        }
    }
}

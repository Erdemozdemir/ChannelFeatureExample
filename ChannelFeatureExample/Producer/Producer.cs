using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChannelFeatureExample.Producer
{
    public static class Producer
    {
        public static Task ProduceData<T>(Channel<T> channel, T message)
        {
            var producer = Task.Run(async () =>
            {
                await Task.Delay(500);
                Console.WriteLine($"Producing: {message}");
                await channel.Writer.WriteAsync(message);
            });

            return Task.CompletedTask;
        }


    }
}

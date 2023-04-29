﻿// See https://aka.ms/new-console-template for more information
using ChannelFeatureExample.Consumer;
using ChannelFeatureExample.Producer;
using System.Threading.Channels;


//Console.WriteLine("Welcome to Custom Channel Example!");
var channel = CreateChannel<string>();
var anotherChannel = CreateChannel<int>();
var message = string.Empty;





while (message.ToLower() != "exit")
{
    message = Console.ReadLine();

    if (string.IsNullOrEmpty(message))
        continue;

    Producer.ProduceData<string>(channel, message);
    Producer.ProduceData<string>(channel, "Default Message");

    Consumer.ConsumeData<string>(channel);


    //Consumer.ConsumeData<int>(channel);
}

Console.WriteLine("End Of the Process");

Channel<T> CreateChannel<T>()
{
    return Channel.CreateUnbounded<T>();
}
using EasyNetQ;
using System;
using TextMessage1 = TextMessage.TextMessage;

namespace Consume
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var bus = RabbitHutch.CreateBus("host=localhost"))
			{
				bus.Subscribe<TextMessage1>("test", HandleTextMessage);

				Console.WriteLine("Listening for messages. Hit <return> to quit.");
				Console.ReadLine();
			}
		}

		static void HandleTextMessage(TextMessage1 textMessage)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Got message: {0}", textMessage.Text);
			Console.ResetColor();
		}
	}

}

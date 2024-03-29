﻿using EasyNetQ;
using System;
using TextMessage1 = TextMessage.TextMessage;

namespace Publisher
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var bus = RabbitHutch.CreateBus("host=localhost"))
			{
				var input = "";
				Console.WriteLine("Enter a message. 'Quit' to quit.");
				while ((input = Console.ReadLine()) != "Quit")
				{
					bus.Publish(new TextMessage1
					{
						Text = input
					});
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace easynetqdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {

		[HttpGet()]
		public ActionResult<string> Get([FromQuery(Name ="message")] string message)
		{
			if (null == message || "" == message)
			{
				return "This is Producer Controller";
			}

			var bus = RabbitHutch.CreateBus("host=localhost");
			
			Messages messages = new Messages(message);
			bus.Publish(messages);
			
			
			return message;
		}
    }

	internal class Messages
	{
		public string Text { get; set; }
		public Messages(string message)
		{
			this.Text = message;
		}
	}
}
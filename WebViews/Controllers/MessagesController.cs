using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using Newtonsoft.Json.Linq;

namespace WebViews
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        ///     POST: api/Messages
        ///     Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));

            var reply = activity.CreateReply();

            var attachment = new
            {
                type = "template",
                payload = new
                {
                    template_type = "button",
                    text = "Your 🍕 is on it's way!",
                    buttons = new[]
                    {
                        new
                        {
                            type = "web_url",
                            url = "https://webviewtest2103.azurewebsites.net/?q=" + Guid.NewGuid().ToString(),
                            title = "See on map",
                            webview_height_ratio = "compact",
                            messenger_extensions = true
                        }
                    }
                }
            };

            reply.ChannelData = JObject.FromObject(new {attachment});

            await connector.Conversations.ReplyToActivityAsync(reply);

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
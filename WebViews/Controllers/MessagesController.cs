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
            // In order to access a webview from a messenger app, it must first be whitelisted
            // POST https://graph.facebook.com/v2.6/me/thread_settings?access_token=<accesstoken>
            // Content-Type: application/json
            // Host: graph.facebook.com
            // Content-Length: 161
            // 
            // {
            //   "setting_type" : "domain_whitelisting",
            //   "domain_action_type": "add",
            //   "whitelisted_domains":[
            //     "https://webviewtest2103.azurewebsites.net/"
            //   ]
            // }

            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));

            var reply = activity.CreateReply();

            var attachment = new
            {
                type = "template",
                payload = new
                {
                    template_type = "button",
                    text = "something...",
                    buttons = new[]
                    {
                        new
                        {
                            type = "web_url",
                            url = "https://webviewtest2103.azurewebsites.net/",
                            title = "click me",
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
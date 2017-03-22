1. Create an azure web app to host your webapp
	Make a note of:
	- URL
	
	Download the publishing profile
2. Register your bot with dev.botframework.com
   Make a note of:
	- App Id
	- App Name
	- App Password
	Being sure to add the messaging endpoint : <Azure Web App URL>/api/messages
3. Create a Facebook page/messenger app
   Make a note of:
	- Page ID
	- Page token
	- App ID
	- App Secret
4. Configure your bot at dev.botframework.com to distribute your bot on the Facebook Messenger channel.  Use the values collected previously.
5. Publish your bot.
6. Whitelist yout bot
```
In order to access a webview from a messenger app, it must first be whitelisted
POST https://graph.facebook.com/v2.6/me/thread_settings?access_token=<accesstoken>
Content-Type: application/json
Host: graph.facebook.com
Content-Length: 161

{
  "setting_type" : "domain_whitelisting",
  "domain_action_type": "add",
  "whitelisted_domains":[
    "https://webviewtest2103.azurewebsites.net/"
  ]
}```
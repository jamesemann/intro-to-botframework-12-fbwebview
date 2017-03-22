1. Create an azure web app to host your webapp.  Download the publishing profile
	Make a note of:
	- `Web App URL`	
2. Register your bot with dev.botframework.com
   Make a note of:
	- `Bot Id`
	- `App Id`
	- `App Password`
	Being sure to add the messaging endpoint : `Web App URL/api/messages`
3. Create a Facebook page/messenger app
   Make a note of:
	- `Page ID`
	- `Page token`
	- `App ID`
	- `App Secret`
4. Configure your bot at dev.botframework.com to distribute your bot on the Facebook Messenger channel.  Use the values collected previously.
5. Open Webviews.sln and open web.config.  Fill in the `Bot Id`, `App Id`, and `App Password`.  
6. Publish it out using the publishing profile downloaded in step 1.
7. Whitelist your WebView https URL using the HTTP client of your choice (Fiddler, CURL, etc.)
```
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
8. Test!
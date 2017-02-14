using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace BOT.Dialogs
{
    [Serializable]
    [LuisModel("9f090551-840a-40eb-8dd9-0cafb9b43c77", "9f735e6fb86542ef8186ea7e6d4338ab")]

    public class RootLuisDialog : LuisDialog<object>
    {


        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Please try again";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("greeting")]
        public async Task Greeting(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
             
            await context.PostAsync("Hello there.  How can I help ?");

            context.Wait(this.MessageReceived);

        }

        [LuisIntent("sendEmail")]
        public async Task SendEmail(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {

            var contact = result.Entities.Where(e => e.Type == "contact").Select(a => a.Entity);
            await context.PostAsync($"Sending message to '{contact}");


            context.Wait(this.MessageReceived);
        }


    }
}
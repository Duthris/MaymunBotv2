using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    public class PurgeManager : ModuleBase<SocketCommandContext>
    {
        [Command("sil")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task PurgeChat(uint amount)
        {
            IEnumerable<IMessage> messages = await Context.Channel.GetMessagesAsync((int)(amount + 1)).FlattenAsync();
            await ((ITextChannel)Context.Channel).DeleteMessagesAsync(messages);
            
            const int delay = 5000;

            IUserMessage msg = await ReplyAsync($"{amount} adet mesaj silindi.");
            await Task.Delay(delay);
            await msg.DeleteAsync();
        }
    }
}
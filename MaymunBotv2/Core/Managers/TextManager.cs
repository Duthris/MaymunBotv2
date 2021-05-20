using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaymunBotv2.Core.Managers
{
    public class TextManager : ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task testAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("**BERKAY**")
                .WithDescription(":white_check_mark: **test başarılı** :white_check_mark:")
                .WithColor(Color.Purple);

            await ReplyAsync("", false, builder.Build());
        }
    }
}
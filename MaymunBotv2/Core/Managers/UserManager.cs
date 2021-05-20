using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace MaymunBotv2.Core.Managers
{
    [Group("maymunbul")]
    public class UserManager : ModuleBase<SocketCommandContext>
    {
        [Command]
        public async Task DefaultUserInfo()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.AddField("Aranan Maymun", $"{Context.User.Mention}")
                .WithColor(Color.Purple)
                .AddField("Hesap oluşturma tarihi", $"{Context.User.CreatedAt}")
                .AddField("Avatar Linki", $"{Context.User.GetAvatarUrl(size: 2048)}")
                .WithDescription($"Daha fazla bilgi için: !31maymun {Context.User.Mention}")
                .WithThumbnailUrl($"{Context.User.GetAvatarUrl(ImageFormat.Auto)}")
                .WithFooter($"{DateTime.Now}");

            await ReplyAsync("", false, builder.Build());
        }

        [Command]
        public async Task TargetUserInfo(SocketGuildUser user)
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.AddField("Aranan Maymun", $"{user.Mention}")
                .WithColor(Color.Purple)
                .AddField("Hesap oluşturma tarihi", $"{user.CreatedAt}")
                .AddField("Maymun Olma Tarihi", $"{user.JoinedAt}")
                .AddField("Rol Sayısı", $"{user.Roles.Count - 1}")
                .AddField("Avatar Linki", $"{user.GetAvatarUrl(size: 2048)}")
                .WithThumbnailUrl($"{user.GetAvatarUrl(ImageFormat.Auto)}")
                .WithFooter($"{DateTime.Now}");

            await ReplyAsync("", false, builder.Build());
        }
    }
}


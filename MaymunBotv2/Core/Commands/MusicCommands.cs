using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using MaymunBotv2.Core.Managers;

namespace MaymunBotv2.Core.Commands
{
    [Name("Music")]
    public class MusicCommands : ModuleBase<SocketCommandContext>
    {
        [Command("gel")]
        public async Task Join()
            => await Context.Channel.SendMessageAsync(await AudioManager.JoinAsync(Context.Guild, Context.User as IVoiceState,
                Context.Channel as ITextChannel));

        [Command("çal")]
        public async Task Play([Remainder] string search)
        => await Context.Channel.SendMessageAsync(await AudioManager.PlayAsync(Context.User as SocketGuildUser,
            Context.Guild, search));

        [Command("kaybol")]
        public async Task Leave()
            => await Context.Channel.SendMessageAsync(await AudioManager.LeaveAsync(Context.Guild));

        [Command("yeter")]
        public async Task Stop()
            => await Context.Channel.SendMessageAsync(await AudioManager.StopAsync(Context.Guild));

        [Command("geç")]
        public async Task Skip()
            => await Context.Channel.SendMessageAsync(await AudioManager.SkipAsync(Context.Guild));

        [Command("ses")]
        public async Task Volume(ushort vol)
            => await Context.Channel.SendMessageAsync(await AudioManager.SetVolumeAsync(vol, Context.Guild));

        [Command("dur")]
        [Alias("devamke")]
        public async Task Pause()
            => await Context.Channel.SendMessageAsync(await AudioManager.PauseOrResumeAsync(Context.Guild));

        [Command("devamke")]
        public async Task Resume()
            => await Context.Channel.SendMessageAsync(await AudioManager.ResumeAsync(Context.Guild));

    }
}

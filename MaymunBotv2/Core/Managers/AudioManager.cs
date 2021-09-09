using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victoria;
using Victoria.Enums;
using Victoria.EventArgs;

namespace MaymunBotv2.Core.Managers
{
    public static class AudioManager
    {
        private static readonly LavaNode _lavaNode = ServiceManager.Provider.GetRequiredService<LavaNode>();

        public static async Task<string> JoinAsync(IGuild guild, IVoiceState voiceState, ITextChannel channel)
        {
            if (_lavaNode.HasPlayer(guild)) return "ikiye mi bölüneyim orospucocugu?";
            if (voiceState.VoiceChannel is null) return "bir yere gir babun";

            try
            {
                await _lavaNode.JoinAsync(voiceState.VoiceChannel, channel);
                return $"{voiceState.VoiceChannel.Name} kanalına geldik sa";
            }
            catch (Exception ex)
            {
                return $"HATA\n{ex.Message}";
            }
        }

        public static async Task<string> PlayAsync(SocketGuildUser user, IGuild guild, string query)
        {
            if (user.VoiceChannel is null) return "bir kanala gir babun";

            try
            {
                var player = _lavaNode.GetPlayer(guild);

                LavaTrack track;

                var search = Uri.IsWellFormedUriString(query, UriKind.Absolute)
                    ? await _lavaNode.SearchAsync(query)
                    : await _lavaNode.SearchYouTubeAsync(query);

                if (search.LoadStatus == LoadStatus.NoMatches)
                {
                    return $"{query} hakkında bir şey bulamadım :(";
                }

                track = search.Tracks.FirstOrDefault();


                if (player.Track != null && player.PlayerState is PlayerState.Playing ||
                    player.PlayerState is PlayerState.Paused)
                {
                    player.Queue.Enqueue(track);
                    Console.WriteLine($"[{DateTime.Now}]\t(AUDIO)\tŞarkı sıraya eklendi.");
                    return $"{track.Title} sıraya eklendi.";
                }

                 await player.PlayAsync(track);
                Console.WriteLine($"Şuanda Çalan Parça: {track.Title}");
                return $"Şuanda Çalan Parça: {track.Title} {track.Duration}";
            }
            catch (Exception ex)
            {
                return $"ERROR:\t{ex.Message}";
            }

        }



        public static async Task<string> LeaveAsync(IGuild guild)
        {

            try
            {
                var player = _lavaNode.GetPlayer(guild);
                if (player.PlayerState is PlayerState.Playing) await player.StopAsync();
                await _lavaNode.LeaveAsync(player.VoiceChannel);

                Console.WriteLine($"[{DateTime.Now}]\t(AUDIO)\tBen kaçtım maymunlar bye.");
                return "Ben kaçtım maymunlar bye.";
            }
            catch (InvalidOperationException ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }



        public static async Task<string> StopAsync(IGuild guild)
        {
 
            var player = _lavaNode.GetPlayer(guild);
            if (player is null)
                return "kim bu";
            await player.StopAsync();
            return "Çalan şarkı duraklatıldı.";
        }



        public static async Task<string> SkipAsync(IGuild guild)
        {
  
            var player = _lavaNode.GetPlayer(guild);
            if (player is null || player.Queue.Count() is 0)
                return "Sırada başka şarkı yok!";

            var oldTrack = player.Track;
            await player.SkipAsync();
            return $"Sonraki Şarkıya Geçildi: {oldTrack.Title} \nŞuanda Çalınan Parça: {player.Track.Title}";
        }



        public static async Task<string> SetVolumeAsync(ushort vol, IGuild guild)
        {

            var player = _lavaNode.GetPlayer(guild);
            if (player is null)
                return "çalmıyo bu";

            if (vol > 150 || vol <= 2)
            {
                return "2 - 150 arasında bir sayı gir";
            }

            await player.UpdateVolumeAsync(vol);
            return $"ok ses verdim: {vol}";
        }



        public static async Task<string> PauseOrResumeAsync(IGuild guild)
        {

            var player = _lavaNode.GetPlayer(guild);
            if (player is null)
                return "çalmıyo bu";

            if (!(player.PlayerState == PlayerState.Paused))
            {
                await player.PauseAsync();
                return "ok durduk";
            }
            else
            {
                await player.ResumeAsync();
                return "devamke";
            }
        }



        public static async Task<string> ResumeAsync(IGuild guild)
        {
     
            var player = _lavaNode.GetPlayer(guild);
            if (player is null)
                return "çalmıyo bu";

            if (player.PlayerState == PlayerState.Paused)
            {
                await player.ResumeAsync();
                return "devamke";
            }

            return "durmam";
        }



        public static async Task TrackEnded(TrackEndedEventArgs args)
        {
            if (!args.Reason.ShouldPlayNext()) return;

            if (!args.Player.Queue.TryDequeue(out var queuable)) return;

            if (!(queuable is LavaTrack track))
            {
                await args.Player.TextChannel.SendMessageAsync("Sırada başka şarkı kalmadı!");
                return;
            }

            await args.Player.PlayAsync(track);
            await args.Player.TextChannel.SendMessageAsync($"Şuanda Çalan Parça: *{track.Title} - {track.Author}*");
        }
    }
}

using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord.WebSocket;
using MaymunBotv2.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MaymunBotv2.Core.Managers
{
    public class TextManager : ModuleBase<SocketCommandContext>
    {
        [Command("cu")]
        [Alias("cu ne","cu neresi","cu nedir","cu mu")]
        public async Task cuAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("**CU**")
                .WithDescription(":rofl: **ANANIN AMCUUU HAHAHAHAHA XD** :rofl:")
                .WithColor(Color.Purple);

            await ReplyAsync("", false, builder.Build());
        }

        [Command("mıyala")]
        [Alias("mıyala ne","mıyala nedir","mıyala hastalığı","mıyala?")]
        public async Task miyalaAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("**MI YALA**")
                .WithDescription(":rofl: **YARRAMI YALA HAHAHAHAHA XD** :rofl:")
                .WithColor(Color.Purple);

            await ReplyAsync("", false, builder.Build());
        }


        [Command("ğ")]
        [Alias("Ğ")]
        public async Task gAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("**Ğ**")
                .WithColor(Color.Purple);

            await ReplyAsync("", false, builder.Build());
        }


        [Command("nazlı")]
        public async Task nazlıAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("**POGACA NAZLI MI ?**")
                .WithImageUrl("http://www.tarifsandigi.com/wp-content/uploads/z-5-768x1024.jpg")
                .WithColor(Color.Orange);

            await ReplyAsync("", false, builder.Build());

        }


        [Command("31")]
        public async Task threeoneAsync()
        {
            SendAndReactAsync(Context.Channel);
            await Context.Message.DeleteAsync();
        }

        [Command("sa")]
        [Alias("sea","selamun aleyküm","selamın aleyküm","selamın aleykum","selamun aleykum","saa","selam","merhaba","hello")]
        public async Task asAsync()
        {
            Context.Channel.SendMessageAsync("as");
        }

        [Command("gunaydın")]
        [Alias("günaydın","guno","güno","gunaydınn", "günaydınss","günaydınn","gunoo","günoo","günaydıns","gunaydinn","gunaydin")]
        public async Task gunaydınAsync()
        {
            List<string> responses = new List<string> {
                "günaydınn",
                "günoo",
                "günaydınss",
                "günaydın canımm",
                "biz uyandıkk",
                "sanadaa",
            };

            Context.Channel.SendMessageAsync(Context.Message.Author.Mention + " " + responses[_random.Next(0, 5)]);
        }

        public async Task SendAndReactAsync(ISocketMessageChannel channel)
        {
            var message = await channel.SendMessageAsync("3   AHAHAHAHAHAHAHA   1");

            var testemoji1 = new Emoji("3️⃣");

            var testemoji2 = new Emoji("1️⃣");

            await message.AddReactionAsync(testemoji1);

            await message.AddReactionAsync(testemoji2);

            var emote = Emote.Parse("<:thonkang:282745590985523200>");

            await message.AddReactionAsync(emote);
        }

        [Command("söyle")]
        public async Task EchoAsync([Remainder] string text)
        {
            await ReplyAsync(text);
            await Context.Message.DeleteAsync();

        }

        [Command("hesapla")]
        public async Task MathAsync([Remainder] string math)
        {
            var dt = new DataTable();
            var result = dt.Compute(math, null);

            var message = await Context.Channel.SendMessageAsync($"Sonuç: {result}");
        }

        private readonly Random _random = new Random();

        [Command("sayı tut")]
        public async Task sayitutAsync()
        {
            int value = _random.Next(1, 10);
            await ReplyAsync("Tuttuğum sayı: " + value);
        }

        [Command("yazı tura")]
        public async Task yazituraAsync()
        {
            var value = _random.Next(1, 3);

            switch (value)
            {
                case 1:
                    await ReplyAsync("Yazı tura atıldı kazanan: **YAZI**");
                    break;
                case 2:
                    await ReplyAsync("Yazı tura atıldı kazanan: **TURA**");
                    break;
            }
        }

        [Command("zar at")]
        public async Task rollDiceAsync()
        {
            int roll = _random.Next(1, 7);
            switch (roll)
            {
                case 1:
                    await ReplyAsync(
                        "```\r╭─────────────╮\r│             │\r│             │\r│     ╭─╮     │\r│     ╰─╯     │\r│             │\r│             │\r╰─────────────╯\r  Bir geldi.```");
                    break;
                case 2:
                    await ReplyAsync(
                        "```\r╭─────────────╮\r│        ╭─╮  │\r│        ╰─╯  │\r│             │\r│             │\r│ ╭─╮         │\r│ ╰─╯         │\r╰─────────────╯\r  İki geldi.```");
                    break;
                case 3:
                    await ReplyAsync(
                        "```\r╭─────────────╮\r│        ╭─╮  │\r│        ╰─╯  │\r│     ╭─╮     │\r│     ╰─╯     │\r│ ╭─╮         │\r│ ╰─╯         │\r╰─────────────╯\r  Üç geldi.```");
                    break;
                case 4:
                    await ReplyAsync(
                        "```\r╭─────────────╮\r│ ╭─╮    ╭─╮  │\r│ ╰─╯    ╰─╯  │\r│             │\r│             │\r│ ╭─╮    ╭─╮  │\r│ ╰─╯    ╰─╯  │\r╰─────────────╯\r  Dört geldi.```");
                    break;
                case 5:
                    await ReplyAsync(
                        "```\r╭─────────────╮\r│ ╭─╮    ╭─╮  │\r│ ╰─╯    ╰─╯  │\r│    ╭─╮      │\r│    ╰─╯      │\r│ ╭─╮    ╭─╮  │\r│ ╰─╯    ╰─╯  │\r╰─────────────╯\r  Beş Geldi.```");
                    break;
                case 6:
                    await ReplyAsync(
                        "```\r╭─────────────╮\r│ ╭─╮    ╭─╮  │\r│ ╰─╯    ╰─╯  │\r│ ╭─╮    ╭─╮  │\r│ ╰─╯    ╰─╯  │\r│ ╭─╮    ╭─╮  │\r│ ╰─╯    ╰─╯  │\r╰─────────────╯\r  Altı geldi.```");
                    break;
                default:
                    await ReplyAsync("Ops, zar masadan düştü :/");
                    break;
            }
        }

        [Command("ping?")]
        public async Task GetLatencyAsync()
        {
            var timeStamp = Context.Message.CreatedAt;

            var latency = Context.Client.Latency;

            var color = latency >= 250 ? Color.DarkRed : Color.Green;
            var message = await Context.Channel.SendMessageAsync("Kontrol Ediliyor...");

            const int delay = 2000;

            await Task.Delay(delay);

            message.DeleteAsync();

            await Context.Channel.SendMessageAsync("Kontrol Edildi :white_check_mark:");

            var newLat = (message.CreatedAt - timeStamp).Milliseconds;

            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("**Pong! :ping_pong:**")
                .WithColor(color)
                .AddField("WS Latency", $"{latency}ms")
                .AddField("Client Latency", $"{newLat}ms");

            await ReplyAsync("", false, builder.Build());
        }

        [Command("orospucocugu")]

        public async Task orospucocuguAsync()
        {
            await Context.User.SendMessageAsync("efendim");
        }

        [Command("test31")]
        public async Task testTaskAsync()
        {
            using (var client = new System.Net.Http.HttpClient())
            using (var testStream = await client.GetStreamAsync("https://www.drupal.org/files/issues/sample_7.png"))
                await Context.Channel.SendFileAsync(testStream, "image.png");
        }

        [Command("nick31")]
        [RequireBotPermission(GuildPermission.ManageNicknames)]
        public async Task nickAsync(string nick)
        {

            var guildChannel = Context.Message.Channel as SocketGuildChannel;
            var textChannel = Context.Message.Channel as SocketTextChannel;
            var botGuildUser = guildChannel.GetUser(Context.User.Id);
            var existingNickname = botGuildUser.Nickname;
            await botGuildUser.ModifyAsync(m => m.Nickname = nick);

            const int delay = 5000;

            var message =
                await Context.Channel.SendMessageAsync(
                    $"Sunucudaki adını **{nick}** olarak değiştitrdim :white_check_mark:");

            await Task.Delay(delay);

            await message.DeleteAsync();
            await Context.Message.DeleteAsync();
        }


        [Command("sus31")]
        [RequireBotPermission(GuildPermission.MuteMembers)]
        public async Task muteAsync(SocketGuildUser user)
        {
            var guildChannel = Context.Message.Channel as SocketGuildChannel;
            var textChannel = Context.Message.Channel as SocketTextChannel;
            var botGuildUser = guildChannel.GetUser(Context.User.Id);

            const int delay = 5000;

            await user.ModifyAsync(m => m.Mute = true);
            var message = await Context.Channel.SendMessageAsync($"sus bakalım {user.Mention}");

            await Task.Delay(delay);

            await message.DeleteAsync();
        }


        [Command("konuş31")]
        [RequireBotPermission(GuildPermission.MuteMembers)]
        public async Task unmuteAsync(SocketGuildUser user)
        {
            var guildChannel = Context.Message.Channel as SocketGuildChannel;
            var textChannel = Context.Message.Channel as SocketTextChannel;
            var botGuildUser = guildChannel.GetUser(Context.User.Id);

            await user.ModifyAsync(m => m.Mute = false);
            var message = await Context.Channel.SendMessageAsync($"konuş bakalım {user.Mention}");
        }


        [Command("nsfw")]
        [RequireNsfw]
        public async Task nsfwAsync()
        {
            using (var client = new HttpClient(new HttpClientHandler
                {AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate}))
            {
                string apiUrl = "http://titsnarse.co.uk/random_json.php";
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage response = client.GetAsync("").Result;
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(result);
                var rnd = new Random();
                string nsfwImage = json["src"].ToString();
                int g1 = rnd.Next(1, 255);
                int g2 = rnd.Next(1, 255);
                int g3 = rnd.Next(1, 255);
                var builder = new EmbedBuilder
                {
                    Color = new Discord.Color(g1, g2, g3),
                    Title = ("ⓒ Maymunlar Dünyası Gizli Mekan"),
                    ImageUrl = "http://titsnarse.co.uk/" + nsfwImage,
                };
                await ReplyAsync("", false, builder.Build());
            }

        }


        [Command("hentai")]
        [RequireNsfw]
        public async Task nekosAsync()
        {
            using (var client = new HttpClient(new HttpClientHandler
                {AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate}))
            {
                string apiUrl = "https://api.waifu.pics/nsfw/waifu";
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage response = client.GetAsync("").Result;
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(result);
                var rnd = new Random();
                string nsfwImage = json["url"].ToString();
                int g1 = rnd.Next(1, 255);
                int g2 = rnd.Next(1, 255);
                int g3 = rnd.Next(1, 255);
                var builder = new EmbedBuilder
                {
                    Color = new Discord.Color(g1, g2, g3),
                    Title = ("ⓒ Maymunlar Dünyası Gizli Mekan"),
                    ImageUrl = nsfwImage,
                };
                await ReplyAsync("", false, builder.Build());
            }
        }

        [Command("nsfwold")]
        public async Task nsfwoldAsync(string subreddit = null)
        {
            var channel = Context.Channel as SocketTextChannel;

            Context.Message.DeleteAsync();

            var httpClient = new HttpClient();
            var result =
                await httpClient.GetStringAsync($"https://reddit.com/r/{subreddit ?? "EllieLeen"}/random.json?limit=1");

            if (!result.StartsWith("["))
            {
                await channel.SendMessageAsync("Bu başlık mevcut değil!");
                return;
            }

            var array = JArray.Parse(result);
            var post = JObject.Parse(array[0]["data"]["children"][0]["data"].ToString());

            var builder = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
                .WithColor(new Color(33, 176, 252))
                .WithTitle("ⓒ Maymunlar Dünyası Gizli Mekan")
                .WithUrl($"https://reddit.com{post["permalink"]}")
                .WithFooter($"💬 {post["num_comments"]} ⬆️ {post["ups"]}");

            await channel.SendMessageAsync(null, false, builder.Build());
        }

        [Command("xdxd")]
        public async Task Meme(string subreddit = null)
        {
            var channel = Context.Channel as SocketTextChannel;

            Context.Message.DeleteAsync();

            var httpClient = new HttpClient();
            var result =
                await httpClient.GetStringAsync(
                    $"https://reddit.com/r/{subreddit ?? "TurkeyJerky"}/random.json?limit=1");

            if (!result.StartsWith("["))
            {
                await channel.SendMessageAsync("Bu başlık mevcut değil!");
                return;
            }

            var array = JArray.Parse(result);
            var post = JObject.Parse(array[0]["data"]["children"][0]["data"].ToString());

            var builder = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
                .WithColor(new Color(33, 176, 252))
                .WithTitle(post["title"].ToString())
                .WithUrl($"https://reddit.com{post["permalink"]}")
                .WithFooter($"💬 {post["num_comments"]} ⬆️ {post["ups"]}");

            var embed = builder.Build();

            await channel.SendMessageAsync(null, false, embed);
        }

        [Command("seç")]
        public async Task<RuntimeResult> chooseAsync([Remainder] string input)
        {
            var regexParsed = Regex.Split(input, "or|;|,|and|ve", RegexOptions.IgnoreCase);
            int g1 = _random.Next(1, 255);
            int g2 = _random.Next(1, 255);
            int g3 = _random.Next(1, 255);

            var embed = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    Name = "Bence seeeen... 🤔",
                    IconUrl = Context.Client.CurrentUser.GetAvatarUrl()
                },
                Color = new Discord.Color(g1, g2, g3),
                Description = "**" + regexParsed[_random.Next(0, regexParsed.Length)] + "**" +
                              " seçmelisin :white_check_mark:"
            };
            Console.Write(regexParsed.Length == 0);
            await ReplyAsync("", embed: embed.Build()).ConfigureAwait(false);
            return CommandRuntimeResult.FromSuccess();
        }


        [Command("yarrak31")]
        public async Task penisAsync()
        {
            string penis()
            {
                var length = _random.Next(1, 8);
                var shaft = "";
                for (int i = 0; i < length; i++)
                {
                    shaft += "=";
                }

                return $"8{shaft}D";
            }

            var response = await Task.Run(() => penis());
            await ReplyAsync(Context.Message.Author.Mention + " senin yarrak boyu kesin böyle:   " + $"**{response}**",
                false);
        }


        [Command("set status")]
        [RequireOwner]
        public async Task statusAsync([Remainder] string args)
        {
            switch (args)
            {
                case "afk":
                    Context.Client.SetStatusAsync(UserStatus.AFK);
                    Context.Client.StopAsync();
                    Context.Client.StartAsync();
                    Context.Channel.SendMessageAsync($"Durumumu {UserStatus.AFK} olarak değiştirdim :white_check_mark:");
                    break;

                case "online":
                    Context.Client.SetStatusAsync(UserStatus.Online);
                    Context.Client.StopAsync();
                    Context.Client.StartAsync();
                    Context.Channel.SendMessageAsync($"Durumumu {UserStatus.Online} olarak değiştirdim :white_check_mark:");
                    break;

                case "offline":
                    Context.Client.SetStatusAsync(UserStatus.Offline);
                    Context.Client.StopAsync();
                    Context.Client.StartAsync();
                    Context.Channel.SendMessageAsync($"Durumumu {UserStatus.Offline} olarak değiştirdim :white_check_mark:");
                    break;

                case "away":
                    Context.Client.SetStatusAsync(UserStatus.Idle);
                    Context.Client.StopAsync();
                    Context.Client.StartAsync();
                    Context.Channel.SendMessageAsync($"Durumumu {UserStatus.Idle} olarak değiştirdim :white_check_mark:");
                    break;

                case "dnd":
                    Context.Client.SetStatusAsync(UserStatus.DoNotDisturb);
                    Context.Client.StopAsync();
                    Context.Client.StartAsync();
                    Context.Channel.SendMessageAsync($"Durumumu {UserStatus.DoNotDisturb} olarak değiştirdim :white_check_mark:");
                    break;
            }
        }

        [Command("set game")]
        [RequireOwner]
        public async Task status2Async([Remainder] string args)
        {
            Context.Client.SetActivityAsync(new Game($"{args}"));
            Context.Channel.SendMessageAsync($"Durumumu {ActivityType.Playing} {args} olarak değiştirdim :white_check_mark:");
            Context.Client.StopAsync();
            Context.Client.StartAsync();
    }

        [Command("set streaming")]
        [RequireOwner]
        public async Task streamingAsync([Remainder] string args)
        {
            Context.Client.SetGameAsync(name: $"Komutlar: yardım", streamUrl: $"{args}", ActivityType.Streaming);
            Context.Channel.SendMessageAsync($"Durumumu {ActivityType.Streaming} {args} olarak değiştirdim :white_check_mark:");
            Context.Client.StopAsync();
            Context.Client.StartAsync();
        }

        [Command("test3131")]
        public Task test3131()
        {
            List<string> responses = new List<string> {
                "günaydınn",
                "günoo",
                "günaydınss",
                "günaydın canımm",
                "biz uyandıkk",
            };

            return ReplyAsync(responses[_random.Next(0,9)]);
        }
    }
}

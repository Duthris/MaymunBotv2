using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    public class HelpCommand : ModuleBase<SocketCommandContext>
    {
        [Command("yardım")]
        public async Task HelpAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.AddField("**Maymun BOT Komut Listesi**", "**© MAYMUNLAR DÜNYASI**")
                .AddField("**KOMUTLAR**" , "Tüm komutlar başına !31 koyarak çalışır.")
                .AddField("**Kullanılabilir Komutlar**",
                "**yardım** | Buradaki komutlar bölümüne getirir." +
                "\n**maymunbul** | @ ile taglenen kişi hakkında bilgi verir." +
                "\n**sil** | Belirtilen miktarda mesaj siler. !31sil 10 gibi.")
                .AddField("**MÜZİK KOMUTLARI**",
                "\n**gel** | Botu bulunulan odaya çağırır. Bot odaya gelmeden müzik komutları çalışmaz." +
                "\n**çal** | Yazılan şarkıyı çalar veya sıraya ekler." +
                "\n**kaybol** | Botun gitmesini sağlar." +
                "\n**yeter** | Çalan şarkıyı bitirir." +
                "\n**geç** | Çalan şarkıyı geçmeye yarar." +
                "\n**dur** | Çalan şarkıyı duraksatır." +
                "\n**devamke** | Durdurulan şarkıyı devam ettirir." + 
                "\n**ses** | Botun ses seviyesini herkeste 2 - 150 arası değiştirir. !31ses 120 gibi.")

                .WithColor(Color.Purple)
                .WithThumbnailUrl(Context.Guild.IconUrl);

            await ReplyAsync("", false, builder.Build());
        }
    }
}
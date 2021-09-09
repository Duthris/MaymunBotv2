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
                .AddField("**KOMUTLAR**" , "Tüm komutlar direkt çalışır.")
                .AddField("**Kullanılabilir Komutlar**",
                "**yardım** | Buradaki komutlar bölümüne getirir." +
                "\n**maymunbul** | @ ile taglenen kişi hakkında bilgi verir. **maymunbul @maymunbot** gibi." +
                "\n**sil** | Belirtilen miktarda mesaj siler. **sil 10** gibi." + 
                "\n**hesapla** | İstenilen matematik işlemini yapar. **hesapla 15+20** gibi kullanılır." +
                "\n**sayı tut** | 1-10 arası bir sayı tutar." + 
                "\n**yazı tura** | Yazı - Tura atar." + 
                "\n**söyle** | Söylenilen şeyi tekrar eder. **söyle Merhaba** gibi kullanılır. Merhaba yazar." +
                "\n**ping?** | Botun ping durumunu gösterir kritik seviyenin üzerindeyse kırmızı, değilse yeşil renk olarak yanıtlar." +
                "\n**nick** | Sunucudaki adınızı değiştirmeye yarar. **nick31 test** şeklinde kullanılır." +
                "\nYapacağınız isim birden fazla kelimeyse **nick31 \"test isim\"** şeklinde kullanılır." +
                "\n**sus** | Birini susturmaya yarar. **sus31 @nick** şeklinde etiketlenen kişiyi susturur." +
                "\n**konuş** | Birinin susturmasını kaldırmaya yarar. **konuş31 @nick** şeklinde etiketlenen kişinin susturmasını kaldırır.")

                .AddField("**MÜZİK KOMUTLARI**",
                "\n**gel** | Botu bulunulan odaya çağırır. Bot odaya gelmeden müzik komutları çalışmaz." +
                "\n**çal** | Yazılan şarkıyı çalar veya sıraya ekler." +
                "\n**kaybol** | Botun gitmesini sağlar." +
                "\n**yeter** | Çalan şarkıyı bitirir." +
                "\n**geç** | Çalan şarkıyı geçmeye yarar." +
                "\n**dur** | Çalan şarkıyı duraksatır." +
                "\n**devamke** | Durdurulan şarkıyı devam ettirir." + 
                "\n**ses** | Botun ses seviyesini herkes için 2 - 150 arası değiştirir. **ses 120** gibi.")

                .WithColor(Color.Purple)
                .WithThumbnailUrl("https://media.giphy.com/media/KzGCAlMiK6hQQ/giphy.gif");

            await ReplyAsync("", false, builder.Build());
        }
    }
}

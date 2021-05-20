using System;
using System.Threading.Tasks;
using DSharpPlus;
using MaymunBotv2.Core;
using MaymunBotv2.Core.Managers;

namespace MaymunBotv2
{
    class Program
    {
        static void Main(string[] args)
            => new Bot().MainAsync().GetAwaiter().GetResult();
    }
}

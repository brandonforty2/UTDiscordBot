using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;

namespace BotCode.Modules
{
    public class Administration : ModuleBase
    {
        // ~say hello -> hello
        [Command("say"), Summary("Echos a message.")]
        public async Task Say([Remainder, Summary("The text to echo")] string echo)
        {
            // ReplyAsync is a method on ModuleBase
            var user = Context.User as SocketGuildUser;
            var permission = (user as IGuildUser).GuildPermissions;
            if (permission.Administrator == true)
            {
                await ReplyAsync(echo);
            }
            else if (user.Id == 239099905849819137)
            {
                await ReplyAsync("Mox please stop messing with stuff");
            }
            else
            {
                await ReplyAsync("You do not have permission to do that");
            }

        }

        [Command("mute"), Summary("Mutes a person, sends them a warning, and logs the infraction")]
        public async Task Mute([Remainder, Summary("~mute [user] [reason]")] string mute)
        {
            var user = Context.User as SocketGuildUser;
            var permission = (user as IGuildUser).GuildPermissions;
            if (permission.Administrator == true)
            {
                await ReplyAsync("yeet");
            }
            else if (user.Id == 239099905849819137)
            {
                await ReplyAsync("Mox please stop messing with stuff");
            }
            else
            {
                await ReplyAsync("You do not have permission to do that");
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
        public async Task Mute([Remainder, Summary("~mute user, time in minutes, reason")] string mute)
        {
            var user = Context.User as SocketGuildUser;
            var permission = (user as IGuildUser).GuildPermissions;
            if (permission.Administrator == true)
            {
                //Parse Command
                List<string> command = mute.Split(',').ToList();
                await ReplyAsync(command[0] + command[1] + command[2]);

                //Get the time, only continue if the time is an integer
                int time = -1;
                if (Int32.TryParse(command[1], out time))
                {
                    await ReplyAsync("Executing Command");
                    //Convert time to seconds from minutes
                    time = time * 60;
                    Console.WriteLine(time);

                    //Mute the user (Does not assign the role?)
                    var role = Context.Guild.GetRole(511321342549688336);
                    await (user as IGuildUser).AddRoleAsync(role);


                }
                else
                {
                    await ReplyAsync("Error: Time is not a number");
                }

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

        private static void Unmuter(object user)
        {

        }
    }
}

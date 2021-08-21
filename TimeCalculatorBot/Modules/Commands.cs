using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace TimeCalculatorBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("Pong");
        }

        [Command("now")]
        public async Task Now(string convert = null, [Remainder] string extraTimeZone = null)
        {
            if (convert != null) convert.ToLower();
            var message = Context.Message.Content;
            string timeFormat = "HH:mm tt";
            DateTime cetTZ = DateTime.UtcNow.AddHours(1);
            string cetTZtring = cetTZ.ToString(timeFormat);
            string cetTZtring1 = "Central European Time";

            DateTime cestTZ = DateTime.UtcNow.AddHours(2);
            string cestTZtring = cestTZ.ToString(timeFormat);
            string cestTZtring1 = "Central European Summer Time";

            DateTime localUTC = DateTime.UtcNow;
            string localUTCString = localUTC.ToString(timeFormat);
            string localUTCString1 = "UTC/Coordinated Universal Time";

            DateTime estTZ = DateTime.UtcNow.AddHours(-5);
            string estTZString = estTZ.ToString(timeFormat);
            string estTZString1 = "Eastern Standard Time";

            DateTime bstTZ = DateTime.UtcNow.AddHours(1);
            string bstTZString = bstTZ.ToString(timeFormat);
            string bstTZString1 = "British Summer Time";

            //To add: gmt+9, AEST, IST, AKDT, ARE, PST, GMT! and automatic...



            if (convert == null || convert == "24h")
            {
                if (extraTimeZone != null)
                {
                    try
                    {
                        await ReplyAsync(TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(extraTimeZone)).ToString(timeFormat));
                    }
                    catch (TimeZoneNotFoundException e)
                    {
                        await ReplyAsync($"I may not have {extraTimeZone} as a time zone. Want this as a time zone? dm ConfuzzedCat, like this: Can you add 'Eastern Standard Time'?");
                        return;
                    }
                } else
                {
                    var EmbedBuilder = new EmbedBuilder()
                        .WithDescription($"({cestTZtring}) - {cestTZtring1}.\n({cetTZtring}) - {cetTZtring1}\n({bstTZString}) - {bstTZString1}\n({localUTCString}) - {localUTCString1}\n({estTZString}) - {estTZString1}")
                        .WithFooter(footer =>
                            {
                                footer
                                .WithText("!time now 24h");
                            });
                    Embed embed = EmbedBuilder.Build();

                    if (Context.Message.Content.StartsWith("!time now")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed);

                }
            }
            else if (convert == "12h" || convert == "12" || convert == "12hour" || convert == "12-hour" || convert == "12hours" || convert == "12-hours" || convert == "am" || convert == "pm")
            {

                timeFormat = "hh:mm tt";

                if (extraTimeZone != null)
                {
                    try
                    {
                        await ReplyAsync(TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(extraTimeZone)).ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US")));
                    }
                    catch (TimeZoneNotFoundException e)
                    {
                        await ReplyAsync($"I may not have {extraTimeZone} as a time zone. Want this as a time zone? dm ConfuzzedCat, like this: Can you add 'Eastern Standard Time'?");
                        return;
                    }
                }
                else
                {


                    cetTZtring = cetTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    cestTZtring = cestTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    localUTCString = localUTC.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    estTZString = estTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    bstTZString = bstTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));

                    var EmbedBuilder = new EmbedBuilder()
                        .WithDescription($"({cestTZtring}) - {cestTZtring1}.\n({cetTZtring}) - {cetTZtring1}\n({bstTZString}) - {bstTZString1}\n({localUTCString}) - {localUTCString1}\n({estTZString}) - {estTZString1}")
                        .WithFooter(footer =>
                        {
                            footer
                                            .WithText("!time now 12h");
                        });
                    Embed embed = EmbedBuilder.Build();
                    if (Context.Message.Content.StartsWith("!time now")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed);
                    //curTime = DateTime.Now.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    //await ReplyAsync($"The bot's currrent time is {curTime} {localTZ}.");
                }

            } 
            else
            {
                if (Context.Message.Content.StartsWith("!time now")) await Context.Message.DeleteAsync();
                await ReplyAsync("Invaild sub command, Try with either '12', '12h', '12hour', '12hours', '12-hour', '12-hours', 'am', 'pm' or '24h'.");
            }
        }

        [Command("time")]
        public async Task Time(string getTime = null, string ampm = null, string getTimeTZ = null)
        {
            DateTime outputTimeParse;
            DateTime.TryParse(getTime, out outputTimeParse);
            string timeFormat_Time = "HH:mm tt";
            if (ampm == "am" || ampm == "pm")
            {
                timeFormat_Time = "hh:mm tt";
                await ReplyAsync(outputTimeParse.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US")));
            }

        }
    }
}

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
    { // if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync(); deletes command message
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
            string timeFormat = "HH:mm";
            DateTime cetTZ = DateTime.UtcNow.AddHours(1);
            string cetTZString = cetTZ.ToString(timeFormat);
            string cetTZString1 = "Central European Time";

            DateTime cestTZ = DateTime.UtcNow.AddHours(2);
            string cestTZString = cestTZ.ToString(timeFormat);
            string cestTZString1 = "Central European Summer Time";

            DateTime localUTC = DateTime.UtcNow;
            string localUTCString = localUTC.ToString(timeFormat);
            string localUTCString1 = "UTC/Coordinated Universal Time";

            DateTime estTZ = DateTime.UtcNow.AddHours(-5);
            string estTZString = estTZ.ToString(timeFormat);
            string estTZString1 = "Eastern Standard Time";

            DateTime bstTZ = DateTime.UtcNow.AddHours(1);
            string bstTZString = bstTZ.ToString(timeFormat);
            string bstTZString1 = "British Summer Time";

            DateTime aestTZ = DateTime.UtcNow.AddHours(10);
            string aestTZString = aestTZ.ToString(timeFormat);
            string aestTZString1 = "Australian Eastern Standard Time";

            DateTime istTZ = DateTime.UtcNow.AddHours(5);
            istTZ.AddMinutes(30);
            string istTZString = istTZ.ToString(timeFormat);
            string istTZString1 = "India Standard Time";

            DateTime pstTZ = DateTime.UtcNow.AddHours(-8);
            string pstTZString = pstTZ.ToString(timeFormat);
            string pstTZString1 = "Pacific Standard Time";

            DateTime pdtTZ = DateTime.UtcNow.AddHours(-7);
            string pdtTZString = pdtTZ.ToString(timeFormat);
            string pdtTZString1 = "Pacific Daylight Time";

            DateTime gmtTZ = DateTime.UtcNow.AddHours(0);
            string gmtTZString = gmtTZ.ToString(timeFormat);
            string gmtTZString1 = "Greenwich Mean Time";

            //To add: AEST, IST, PST, PDT, GMT! and automatic...



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
                        .WithDescription($"({cestTZString}) - {cestTZString1}.\n({cetTZString}) - {cetTZString1}.\n({bstTZString}) - {bstTZString1}.\n({localUTCString}) - {localUTCString1}.\n({estTZString}) - {estTZString1}.\n({aestTZString}) - {aestTZString1}.\n({istTZString}) - {istTZString1}.\n({pstTZString}) - {pstTZString1}.\n({pdtTZString}) - {pdtTZString1}.\n({gmtTZString}) - {gmtTZString1}.")
                        .WithFooter(footer =>
                            {
                                footer
                                .WithText("!time now 24h");
                            });
                    Embed embed = EmbedBuilder.Build();

                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
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


                    cetTZString = cetTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    cestTZString = cestTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    localUTCString = localUTC.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    estTZString = estTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    bstTZString = bstTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    aestTZString = aestTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    istTZString = istTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    pstTZString = pstTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    pdtTZString = pdtTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US")); 
                    gmtTZString = gmtTZ.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));

                    var EmbedBuilder = new EmbedBuilder()
                        .WithDescription($"({cestTZString}) - {cestTZString1}.\n({cetTZString}) - {cetTZString1}.\n({bstTZString}) - {bstTZString1}.\n({localUTCString}) - {localUTCString1}.\n({estTZString}) - {estTZString1}.\n({aestTZString}) - {aestTZString1}.\n({istTZString}) - {istTZString1}.\n({pstTZString}) - {pstTZString1}.\n({pdtTZString}) - {pdtTZString1}.\n({gmtTZString}) - {gmtTZString1}.")
                        .WithFooter(footer =>
                        {
                            footer
                                            .WithText("!time now 12h");
                        });
                    Embed embed = EmbedBuilder.Build();
                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed);
                    //curTime = DateTime.Now.ToString(timeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                    //await ReplyAsync($"The bot's currrent time is {curTime} {localTZ}.");
                }

            } 
            else
            {
                if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                await ReplyAsync("Invaild sub command, Try with either '12', '12h', '12hour', '12hours', '12-hour', '12-hours', 'am', 'pm' or '24h'.");
            }
        }

        [Command("time")]
        public async Task Time(string getTime = null, string getTimeTZ = null, string ampm = null)
        {
            if (getTimeTZ != null) getTimeTZ.ToLower();
            if (ampm != null) ampm.ToLower();
            DateTime outputTimeParse;
            string timeFormat_Time;

            if (DateTime.TryParse(getTime, out outputTimeParse))
            {
                DateTime bstTimeTemp = outputTimeParse;
                DateTime cestTimeTemp = outputTimeParse;
                DateTime cetTimeTemp = outputTimeParse;
                DateTime utcTimeTemp = outputTimeParse;
                DateTime estTimeTemp = outputTimeParse;
                DateTime aestTimeTemp = outputTimeParse;
                DateTime istTimeTemp = outputTimeParse;
                istTimeTemp = istTimeTemp.AddMinutes(30);
                DateTime pstTimeTemp = outputTimeParse;
                DateTime pdtTimeTemp = outputTimeParse;
                DateTime gmtTimeTemp = outputTimeParse;

                string bstString = "British Summer Time";
                string cestString = "Central European Summer Time";
                string cetString = "Central European Time";
                string utcString = "UTC/Coordinated Universal Time";
                string estString = "Eastern Standard Time";
                string aestString = "Australian Eastern Standard Time";
                string istString = "India Standard Time";
                string pstString = "Pacific Standard Time";
                string pdtString = "Pacific Daylight Time";
                string gmtString = "Greenwich Mean Time";
                string bstTime;
                string cestTime;
                string cetTime;
                string utcTime;
                string estTime;
                string aestTime;
                string istTime;
                string pstTime;
                string pdtTime;
                string gmtTime;
                if (ampm != "am" || ampm != "pm" || ampm == null)
                {
                    timeFormat_Time = "HH:mm";

                    switch (getTimeTZ)
                    {
                        case "bst":                                     //11:00        
                            cestTimeTemp = cestTimeTemp.AddHours(1);
                            cetTimeTemp = cetTimeTemp.AddHours(0);
                            utcTimeTemp = utcTimeTemp.AddHours(-1);
                            estTimeTemp = estTimeTemp.AddHours(-6);
                            aestTimeTemp = aestTimeTemp.AddHours(9);
                            istTimeTemp = istTimeTemp.AddHours(4);
                            pstTimeTemp = pstTimeTemp.AddHours(-9);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-8);
                            gmtTimeTemp = gmtTimeTemp.AddHours(-1);

                            cestTime = cestTimeTemp.ToString(timeFormat_Time);
                            cetTime = cetTimeTemp.ToString(timeFormat_Time);
                            utcTime = utcTimeTemp.ToString(timeFormat_Time);
                            estTime = estTimeTemp.ToString(timeFormat_Time);
                            aestTime = aestTimeTemp.ToString(timeFormat_Time);
                            istTime = istTimeTemp.ToString(timeFormat_Time);
                            pstTime = pstTimeTemp.ToString(timeFormat_Time);
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time);
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time);

                            var EmbedBuilder_bst = new EmbedBuilder()
                                .WithDescription($"({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz");
                                });
                            Embed embed_bst = EmbedBuilder_bst.Build();
                            await ReplyAsync(embed: embed_bst);
                            break;


                        case "cest":                                //12:00
                            bstTimeTemp = bstTimeTemp.AddHours(-1); //11:00
                            cetTimeTemp = cetTimeTemp.AddHours(-1);
                            utcTimeTemp = utcTimeTemp.AddHours(-2);
                            estTimeTemp = estTimeTemp.AddHours(-6);
                            aestTimeTemp = aestTimeTemp.AddHours(8);
                            istTimeTemp = istTimeTemp.AddHours(3);
                            pstTimeTemp = pstTimeTemp.AddHours(-10);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-9);
                            gmtTimeTemp = gmtTimeTemp.AddHours(-2);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time);
                            cetTime = cetTimeTemp.ToString(timeFormat_Time);
                            utcTime = utcTimeTemp.ToString(timeFormat_Time);
                            estTime = estTimeTemp.ToString(timeFormat_Time);
                            aestTime = aestTimeTemp.ToString(timeFormat_Time);
                            istTime = istTimeTemp.ToString(timeFormat_Time);
                            pstTime = pstTimeTemp.ToString(timeFormat_Time);
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time);
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time);

                            var EmbedBuilder_cest = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz");
                                });
                            Embed embed_cest = EmbedBuilder_cest.Build();
                            await ReplyAsync(embed: embed_cest);
                            break;


                        case "cet":                                 //11:00
                            bstTimeTemp = bstTimeTemp.AddHours(0);
                            cestTimeTemp = cestTimeTemp.AddHours(1);
                            utcTimeTemp = utcTimeTemp.AddHours(-1);
                            estTimeTemp = estTimeTemp.AddHours(-5);
                            aestTimeTemp = aestTimeTemp.AddHours(9);
                            istTimeTemp = istTimeTemp.AddHours(4);
                            pstTimeTemp = pstTimeTemp.AddHours(-7);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-6);
                            gmtTimeTemp = gmtTimeTemp.AddHours(-1);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time);
                            cestTime = cestTimeTemp.ToString(timeFormat_Time);
                            utcTime = utcTimeTemp.ToString(timeFormat_Time);
                            estTime = estTimeTemp.ToString(timeFormat_Time);
                            aestTime = aestTimeTemp.ToString(timeFormat_Time);
                            istTime = istTimeTemp.ToString(timeFormat_Time);
                            pstTime = pstTimeTemp.ToString(timeFormat_Time);
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time);
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time);

                            var EmbedBuilder_cet = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz");
                                });
                            Embed embed_cet = EmbedBuilder_cet.Build();
                            await ReplyAsync(embed: embed_cet);
                            break;


                        case "utc":                                 //10:00
                            bstTimeTemp = bstTimeTemp.AddHours(1);
                            cestTimeTemp = cestTimeTemp.AddHours(2);
                            cetTimeTemp = cetTimeTemp.AddHours(1);
                            estTimeTemp = estTimeTemp.AddHours(-4);
                            aestTimeTemp = aestTimeTemp.AddHours(10);
                            istTimeTemp = istTimeTemp.AddHours(5);
                            pstTimeTemp = pstTimeTemp.AddHours(-8);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-7);
                            gmtTimeTemp = gmtTimeTemp.AddHours(0);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time);
                            cestTime = cestTimeTemp.ToString(timeFormat_Time);
                            cetTime = cetTimeTemp.ToString(timeFormat_Time);
                            estTime = estTimeTemp.ToString(timeFormat_Time);
                            aestTime = aestTimeTemp.ToString(timeFormat_Time);
                            istTime = istTimeTemp.ToString(timeFormat_Time);
                            pstTime = pstTimeTemp.ToString(timeFormat_Time);
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time);
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time);

                            var EmbedBuilder_utc = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz");
                                });
                            Embed embed_utc = EmbedBuilder_utc.Build();
                            await ReplyAsync(embed: embed_utc);
                            break;


                        case "est":                                 //06:00
                            bstTimeTemp = bstTimeTemp.AddHours(5);
                            cestTimeTemp = cestTimeTemp.AddHours(6);
                            cetTimeTemp = cetTimeTemp.AddHours(5);
                            utcTimeTemp = utcTimeTemp.AddHours(4);
                            aestTimeTemp = aestTimeTemp.AddHours(14);
                            istTimeTemp = istTimeTemp.AddHours(9);
                            pstTimeTemp = pstTimeTemp.AddHours(-4);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-3);
                            gmtTimeTemp = gmtTimeTemp.AddHours(4);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time);
                            cestTime = cestTimeTemp.ToString(timeFormat_Time);
                            cetTime = cetTimeTemp.ToString(timeFormat_Time);
                            utcTime = utcTimeTemp.ToString(timeFormat_Time);
                            aestTime = aestTimeTemp.ToString(timeFormat_Time);
                            istTime = istTimeTemp.ToString(timeFormat_Time);
                            pstTime = pstTimeTemp.ToString(timeFormat_Time);
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time);
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time);

                            var EmbedBuilder_est = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz");
                                });
                            Embed embed_est = EmbedBuilder_est.Build();
                            await ReplyAsync(embed: embed_est);
                            break;


                        case "aest":                                //20:00
                            bstTimeTemp = bstTimeTemp.AddHours(-9);
                            cestTimeTemp = cestTimeTemp.AddHours(-8);
                            cetTimeTemp = cetTimeTemp.AddHours(-9);
                            utcTimeTemp = utcTimeTemp.AddHours(-10);
                            estTimeTemp = estTimeTemp.AddHours(-14);
                            istTimeTemp = istTimeTemp.AddHours(-5);
                            pstTimeTemp = pstTimeTemp.AddHours(-18);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-17);
                            gmtTimeTemp = gmtTimeTemp.AddHours(-10);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time);
                            cestTime = cestTimeTemp.ToString(timeFormat_Time);
                            cetTime = cetTimeTemp.ToString(timeFormat_Time);
                            utcTime = utcTimeTemp.ToString(timeFormat_Time);
                            estTime = estTimeTemp.ToString(timeFormat_Time);
                            istTime = istTimeTemp.ToString(timeFormat_Time);
                            pstTime = pstTimeTemp.ToString(timeFormat_Time);
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time);
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time);

                            var EmbedBuilder_aest = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz");
                                });
                            Embed embed_aest = EmbedBuilder_aest.Build();
                            await ReplyAsync(embed: embed_aest);
                            break;


                        case "ist":                                 //15:30
                            bstTimeTemp = bstTimeTemp.AddHours(-4);
                            cestTimeTemp = cestTimeTemp.AddHours(-3);
                            cetTimeTemp = cetTimeTemp.AddHours(-4);
                            utcTimeTemp = utcTimeTemp.AddHours(-5);
                            estTimeTemp = estTimeTemp.AddHours(-9);
                            aestTimeTemp = aestTimeTemp.AddHours(5);
                            pstTimeTemp = pstTimeTemp.AddHours(-13);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-12);
                            gmtTimeTemp = gmtTimeTemp.AddHours(-5);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time);
                            cestTime = cestTimeTemp.ToString(timeFormat_Time);
                            cetTime = cetTimeTemp.ToString(timeFormat_Time);
                            utcTime = utcTimeTemp.ToString(timeFormat_Time);
                            estTime = estTimeTemp.ToString(timeFormat_Time);
                            aestTime = aestTimeTemp.ToString(timeFormat_Time);
                            pstTime = pstTimeTemp.ToString(timeFormat_Time);
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time);
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time);

                            var EmbedBuilder_ist = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz");
                                });
                            Embed embed_ist = EmbedBuilder_ist.Build();
                            await ReplyAsync(embed: embed_ist);
                            break;


                        case "pst":                                 //02:00
                            bstTimeTemp = bstTimeTemp.AddHours(9);
                            cestTimeTemp = cestTimeTemp.AddHours(10);
                            cetTimeTemp = cetTimeTemp.AddHours(9);
                            utcTimeTemp = utcTimeTemp.AddHours(8);
                            estTimeTemp = estTimeTemp.AddHours(4);
                            aestTimeTemp = aestTimeTemp.AddHours(18);
                            istTimeTemp = istTimeTemp.AddHours(13);
                            pdtTimeTemp = pdtTimeTemp.AddHours(1);
                            gmtTimeTemp = gmtTimeTemp.AddHours(8);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time);
                            cestTime = cestTimeTemp.ToString(timeFormat_Time);
                            cetTime = cetTimeTemp.ToString(timeFormat_Time);
                            utcTime = utcTimeTemp.ToString(timeFormat_Time);
                            estTime = estTimeTemp.ToString(timeFormat_Time);
                            aestTime = aestTimeTemp.ToString(timeFormat_Time);
                            istTime = istTimeTemp.ToString(timeFormat_Time);
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time);
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time);

                            var EmbedBuilder_pst = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz");
                                });
                            Embed embed_pst = EmbedBuilder_pst.Build();
                            await ReplyAsync(embed: embed_pst);
                            break;


                        case "pdt":                                 //03:00
                            bstTimeTemp = bstTimeTemp.AddHours(8);
                            cestTimeTemp = cestTimeTemp.AddHours(9);
                            cetTimeTemp = cetTimeTemp.AddHours(8);
                            utcTimeTemp = utcTimeTemp.AddHours(7);
                            estTimeTemp = estTimeTemp.AddHours(3);
                            aestTimeTemp = aestTimeTemp.AddHours(17);
                            istTimeTemp = istTimeTemp.AddHours(12);
                            pstTimeTemp = pstTimeTemp.AddHours(-1);
                            gmtTimeTemp = gmtTimeTemp.AddHours(7);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time);
                            cestTime = cestTimeTemp.ToString(timeFormat_Time);
                            cetTime = cetTimeTemp.ToString(timeFormat_Time);
                            utcTime = utcTimeTemp.ToString(timeFormat_Time);
                            estTime = estTimeTemp.ToString(timeFormat_Time);
                            aestTime = aestTimeTemp.ToString(timeFormat_Time);
                            istTime = istTimeTemp.ToString(timeFormat_Time);
                            pstTime = pstTimeTemp.ToString(timeFormat_Time);
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time);

                            var EmbedBuilder_pdt = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz");
                                });
                            Embed embed_pdt = EmbedBuilder_pdt.Build();
                            await ReplyAsync(embed: embed_pdt);
                            break;


                        case "gmt":                                 //10:00
                            bstTimeTemp = bstTimeTemp.AddHours(1);
                            cestTimeTemp = cestTimeTemp.AddHours(2);
                            cetTimeTemp = cetTimeTemp.AddHours(1);
                            estTimeTemp = estTimeTemp.AddHours(-4);
                            aestTimeTemp = aestTimeTemp.AddHours(10);
                            istTimeTemp = istTimeTemp.AddHours(5);
                            pstTimeTemp = pstTimeTemp.AddHours(-8);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-7);
                            utcTimeTemp = utcTimeTemp.AddHours(0);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time);
                            cestTime = cestTimeTemp.ToString(timeFormat_Time);
                            cetTime = cetTimeTemp.ToString(timeFormat_Time);
                            estTime = estTimeTemp.ToString(timeFormat_Time);
                            aestTime = aestTimeTemp.ToString(timeFormat_Time);
                            istTime = istTimeTemp.ToString(timeFormat_Time);
                            pstTime = pstTimeTemp.ToString(timeFormat_Time);
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time);
                            utcTime = utcTimeTemp.ToString(timeFormat_Time);

                            var EmbedBuilder_gmt = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz");
                                });
                            Embed embed_gmt = EmbedBuilder_gmt.Build();
                            await ReplyAsync(embed: embed_gmt);
                            break;


                        default:
                            var EmbedBuilder_default = new EmbedBuilder()
                                .WithDescription($"{getTimeTZ} was not found.\n'bst', 'cest', 'cet', 'utc', 'est', 'aest', 'ist', 'pst', 'pdt' and 'gmt' is the only vaild time zones(case sensitive). not on the list? use !time UTC")
                                .WithFooter(footer =>
                                {
                                    footer
                                        .WithText("!time time HH:mm tz");
                                });
                            Embed embed_default = EmbedBuilder_default.Build();

                            await ReplyAsync(embed: embed_default);
                            break;

                    }
                }
                
                else if (ampm == "am" || ampm == "pm")
                {

                    timeFormat_Time = "hh:mm tt";
                    switch (getTimeTZ)
                    {
                        case "bst":                                     //11:00        
                            cestTimeTemp = cestTimeTemp.AddHours(1);
                            cetTimeTemp = cetTimeTemp.AddHours(0);
                            utcTimeTemp = utcTimeTemp.AddHours(-1);
                            estTimeTemp = estTimeTemp.AddHours(-6);
                            aestTimeTemp = aestTimeTemp.AddHours(9);
                            istTimeTemp = istTimeTemp.AddHours(4);
                            pstTimeTemp = pstTimeTemp.AddHours(-9);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-8);
                            gmtTimeTemp = gmtTimeTemp.AddHours(-1);

                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cetTime = cetTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

                            var EmbedBuilder_bst = new EmbedBuilder()
                                .WithDescription($"({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_bst = EmbedBuilder_bst.Build();
                            await ReplyAsync(embed: embed_bst);
                            break;


                        case "cest":                                //12:00
                            bstTimeTemp = bstTimeTemp.AddHours(-1); //11:00
                            cetTimeTemp = cetTimeTemp.AddHours(-1);
                            utcTimeTemp = utcTimeTemp.AddHours(-2);
                            estTimeTemp = estTimeTemp.AddHours(-6);
                            aestTimeTemp = aestTimeTemp.AddHours(8);
                            istTimeTemp = istTimeTemp.AddHours(3);
                            pstTimeTemp = pstTimeTemp.AddHours(-10);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-9);
                            gmtTimeTemp = gmtTimeTemp.AddHours(-2);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cetTime = cetTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

                            var EmbedBuilder_cest = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_cest = EmbedBuilder_cest.Build();
                            await ReplyAsync(embed: embed_cest);
                            break;


                        case "cet":                                 //11:00
                            bstTimeTemp = bstTimeTemp.AddHours(0);
                            cestTimeTemp = cestTimeTemp.AddHours(1);
                            utcTimeTemp = utcTimeTemp.AddHours(-1);
                            estTimeTemp = estTimeTemp.AddHours(-5);
                            aestTimeTemp = aestTimeTemp.AddHours(9);
                            istTimeTemp = istTimeTemp.AddHours(4);
                            pstTimeTemp = pstTimeTemp.AddHours(-7);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-6);
                            gmtTimeTemp = gmtTimeTemp.AddHours(-1);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

                            var EmbedBuilder_cet = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_cet = EmbedBuilder_cet.Build();
                            await ReplyAsync(embed: embed_cet);
                            break;


                        case "utc":                                 //10:00
                            bstTimeTemp = bstTimeTemp.AddHours(1);
                            cestTimeTemp = cestTimeTemp.AddHours(2);
                            cetTimeTemp = cetTimeTemp.AddHours(1);
                            estTimeTemp = estTimeTemp.AddHours(-4);
                            aestTimeTemp = aestTimeTemp.AddHours(10);
                            istTimeTemp = istTimeTemp.AddHours(5);
                            pstTimeTemp = pstTimeTemp.AddHours(-8);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-7);
                            gmtTimeTemp = gmtTimeTemp.AddHours(0);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cetTime = cetTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

                            var EmbedBuilder_utc = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_utc = EmbedBuilder_utc.Build();
                            await ReplyAsync(embed: embed_utc);
                            break;


                        case "est":                                 //06:00
                            bstTimeTemp = bstTimeTemp.AddHours(5);
                            cestTimeTemp = cestTimeTemp.AddHours(6);
                            cetTimeTemp = cetTimeTemp.AddHours(5);
                            utcTimeTemp = utcTimeTemp.AddHours(4);
                            aestTimeTemp = aestTimeTemp.AddHours(14);
                            istTimeTemp = istTimeTemp.AddHours(9);
                            pstTimeTemp = pstTimeTemp.AddHours(-4);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-3);
                            gmtTimeTemp = gmtTimeTemp.AddHours(4);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cetTime = cetTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

                            var EmbedBuilder_est = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_est = EmbedBuilder_est.Build();
                            await ReplyAsync(embed: embed_est);
                            break;


                        case "aest":                                //20:00
                            bstTimeTemp = bstTimeTemp.AddHours(-9);
                            cestTimeTemp = cestTimeTemp.AddHours(-8);
                            cetTimeTemp = cetTimeTemp.AddHours(-9);
                            utcTimeTemp = utcTimeTemp.AddHours(-10);
                            estTimeTemp = estTimeTemp.AddHours(-14);
                            istTimeTemp = istTimeTemp.AddHours(-5);
                            pstTimeTemp = pstTimeTemp.AddHours(-18);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-17);
                            gmtTimeTemp = gmtTimeTemp.AddHours(-10);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cetTime = cetTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

                            var EmbedBuilder_aest = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_aest = EmbedBuilder_aest.Build();
                            await ReplyAsync(embed: embed_aest);
                            break;


                        case "ist":                                 //15:30
                            bstTimeTemp = bstTimeTemp.AddHours(-4);
                            cestTimeTemp = cestTimeTemp.AddHours(-3);
                            cetTimeTemp = cetTimeTemp.AddHours(-4);
                            utcTimeTemp = utcTimeTemp.AddHours(-5);
                            estTimeTemp = estTimeTemp.AddHours(-9);
                            aestTimeTemp = aestTimeTemp.AddHours(5);
                            pstTimeTemp = pstTimeTemp.AddHours(-13);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-12);
                            gmtTimeTemp = gmtTimeTemp.AddHours(-5);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cetTime = cetTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

                            var EmbedBuilder_ist = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_ist = EmbedBuilder_ist.Build();
                            await ReplyAsync(embed: embed_ist);
                            break;


                        case "pst":                                 //02:00
                            bstTimeTemp = bstTimeTemp.AddHours(9);
                            cestTimeTemp = cestTimeTemp.AddHours(10);
                            cetTimeTemp = cetTimeTemp.AddHours(9);
                            utcTimeTemp = utcTimeTemp.AddHours(8);
                            estTimeTemp = estTimeTemp.AddHours(4);
                            aestTimeTemp = aestTimeTemp.AddHours(18);
                            istTimeTemp = istTimeTemp.AddHours(13);
                            pdtTimeTemp = pdtTimeTemp.AddHours(1);
                            gmtTimeTemp = gmtTimeTemp.AddHours(8);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cetTime = cetTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

                            var EmbedBuilder_pst = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_pst = EmbedBuilder_pst.Build();
                            await ReplyAsync(embed: embed_pst);
                            break;


                        case "pdt":                                 //03:00
                            bstTimeTemp = bstTimeTemp.AddHours(8);
                            cestTimeTemp = cestTimeTemp.AddHours(9);
                            cetTimeTemp = cetTimeTemp.AddHours(8);
                            utcTimeTemp = utcTimeTemp.AddHours(7);
                            estTimeTemp = estTimeTemp.AddHours(3);
                            aestTimeTemp = aestTimeTemp.AddHours(17);
                            istTimeTemp = istTimeTemp.AddHours(12);
                            pstTimeTemp = pstTimeTemp.AddHours(-1);
                            gmtTimeTemp = gmtTimeTemp.AddHours(7);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cetTime = cetTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

                            var EmbedBuilder_pdt = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({gmtTime}) - {gmtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_pdt = EmbedBuilder_pdt.Build();
                            await ReplyAsync(embed: embed_pdt);
                            break;


                        case "gmt":                                 //10:00
                            bstTimeTemp = bstTimeTemp.AddHours(1);
                            cestTimeTemp = cestTimeTemp.AddHours(2);
                            cetTimeTemp = cetTimeTemp.AddHours(1);
                            estTimeTemp = estTimeTemp.AddHours(-4);
                            aestTimeTemp = aestTimeTemp.AddHours(10);
                            istTimeTemp = istTimeTemp.AddHours(5);
                            pstTimeTemp = pstTimeTemp.AddHours(-8);
                            pdtTimeTemp = pdtTimeTemp.AddHours(-7);
                            utcTimeTemp = utcTimeTemp.AddHours(0);

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cetTime = cetTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

                            var EmbedBuilder_gmt = new EmbedBuilder()
                                .WithDescription($"({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pstTime}) - {pstString}\n({pdtTime}) - {pdtString}")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_gmt = EmbedBuilder_gmt.Build();
                            await ReplyAsync(embed: embed_gmt);
                            break;


                        default:
                            var EmbedBuilder_default = new EmbedBuilder()
                                .WithDescription($"{getTimeTZ} was not found.\n'bst', 'cest', 'cet', 'utc', 'est', 'aest', 'ist', 'pst', 'pdt' and 'gmt' is the only vaild time zones(case sensitive). not on the list? use !time UTC")
                                .WithFooter(footer =>
                                {
                                    footer
                                    .WithText("!time time HH:mm tz am");
                                });
                            Embed embed_default = EmbedBuilder_default.Build();

                            await ReplyAsync(embed: embed_default);
                            break;

                    }
                }
            } 
            else
            {
                await ReplyAsync("Invaild time format, needs to like this '13:45 cet' and 24 hours.");
            }



        }

        [Command("utc")]
        public async Task Utc(string utcTime = null, double utcOffset = 0, string ampm = null)
        {
            if (utcTime != null) utcTime.ToLower();
            if (ampm != null) ampm.ToLower();
            DateTime outputTimeParse;
            string timeformat = "HH:mm";
            string utcOffsetString;
            if (utcOffset > 0)
            {
                utcOffsetString = "+" + utcOffset.ToString();
            } else
            {
                utcOffsetString = utcOffset.ToString();
            }

            string bstString = "British Summer Time";
            string cestString = "Central European Summer Time";
            string cetString = "Central European Time";
            string utcString = "UTC/Coordinated Universal Time";
            string estString = "Eastern Standard Time";
            string aestString = "Australian Eastern Standard Time";
            string istString = "India Standard Time";
            string pstString = "Pacific Standard Time";
            string pdtString = "Pacific Daylight Time";
            string gmtString = "Greenwich Mean Time";
            double bstOffset = 1;
            double cestOffset = 2;
            double cetOffest = 1;
            double estOffset = -4;
            double aestoffest = 10;
            double istOffset = 5;
            double pstOffset = -8;
            double pdtOffset = -7;

            if (utcOffset == bstOffset) bstOffset = utcOffset;
            if (utcOffset == cestOffset) cestOffset = utcOffset;
            if (utcOffset == cetOffest) cetOffest = utcOffset;
            if (utcOffset == estOffset) estOffset = utcOffset;
            if (utcOffset == aestoffest) aestoffest = utcOffset;
            if (utcOffset == istOffset) istOffset = utcOffset;
            if (utcOffset == pstOffset) pstOffset = utcOffset;
            if (utcOffset == pdtOffset) pdtOffset = utcOffset;

            if (DateTime.TryParse(utcTime, out outputTimeParse))
            {
                DateTime bstTimeTemp = outputTimeParse.AddHours(bstOffset);
                DateTime cestTimeTemp = outputTimeParse.AddHours(cestOffset);
                DateTime cetTimeTemp = outputTimeParse.AddHours(cetOffest);
                DateTime estTimeTemp = outputTimeParse.AddHours(estOffset);
                DateTime aestTimeTemp = outputTimeParse.AddHours(aestoffest);
                DateTime istTimeTemp = outputTimeParse.AddHours(istOffset);
                DateTime pstTimeTemp = outputTimeParse.AddHours(pstOffset);
                DateTime pdtTimeTemp = outputTimeParse.AddHours(pdtOffset);


                if (ampm != "am" || ampm != "pm")
                {
                    timeformat = "HH:mm tt";
                    string utcWithOffset = outputTimeParse.AddHours(utcOffset).ToString(timeformat);

                    string bstTime = bstTimeTemp.ToString(timeformat);
                    string cestTime = cestTimeTemp.ToString(timeformat);
                    string cetTime = cetTimeTemp.ToString(timeformat);
                    string estTime = estTimeTemp.ToString(timeformat);
                    string aestTime = aestTimeTemp.ToString(timeformat);
                    string istTime = istTimeTemp.ToString(timeformat);
                    string pstTime = pstTimeTemp.ToString(timeformat);
                    string pdtTime = pdtTimeTemp.ToString(timeformat);
                    string gmtTime = outputTimeParse.ToString(timeformat);



                    var EmbedBuilder = new EmbedBuilder()
                        .WithDescription($"{utcTime} is {utcWithOffset} at UTC{utcOffsetString}.\n({bstTime}) - {bstString}.\n({cestTime}) - {cestString}.\n({cetTime}) - {cetString}.\n({utcTime}) - {utcString}.\n({estTime}) - {estString}.\n({aestTime}) - {aestString}.\n({istTime}) - {istString}.\n({pstTime}) - {pstString}.\n({pdtTime}) - {pdtString}.\n({utcTime}) - {gmtString}.")
                        .WithFooter(footer =>
                        {
                            footer
                            .WithText("!time utc HH:mm offset");
                        });

                    Embed embed = EmbedBuilder.Build();
                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed);
                } else
                {
                    timeformat = "hh:mm tt";
                    string utcWithOffset = outputTimeParse.AddHours(utcOffset).ToString(timeformat, CultureInfo.CreateSpecificCulture("en-US"));
                    string bstTime = bstTimeTemp.ToString(timeformat, CultureInfo.CreateSpecificCulture("en-US"));
                    string cestTime = cestTimeTemp.ToString(timeformat, CultureInfo.CreateSpecificCulture("en-US"));
                    string cetTime = cetTimeTemp.ToString(timeformat, CultureInfo.CreateSpecificCulture("en-US"));
                    string estTime = estTimeTemp.ToString(timeformat, CultureInfo.CreateSpecificCulture("en-US"));
                    string aestTime = aestTimeTemp.ToString(timeformat, CultureInfo.CreateSpecificCulture("en-US"));
                    string istTime = istTimeTemp.ToString(timeformat, CultureInfo.CreateSpecificCulture("en-US"));
                    string pstTime = pstTimeTemp.ToString(timeformat, CultureInfo.CreateSpecificCulture("en-US"));
                    string pdtTime = pdtTimeTemp.ToString(timeformat, CultureInfo.CreateSpecificCulture("en-US"));
                    string gmtTime = outputTimeParse.ToString(timeformat, CultureInfo.CreateSpecificCulture("en-US"));
                    
                    var EmbedBuilder = new EmbedBuilder()
                        .WithDescription($"{utcTime} is {utcWithOffset} at UTC{utcOffsetString}\n({bstTime}) - {bstString}.\n({cestTime}) - {cestString}\n({cetTime}) - {cetString}\n({utcTime}) - {utcString}\n({estTime}) - {estString}\n({aestTime}) - {aestString}\n({istTime}) - {istString}\n({pdtTime}) - {pdtString}\n({gmtTime}) - {gmtString}")
                        .WithFooter(footer =>
                        {
                            footer
                            .WithText("!time utc HH:mm offset am");
                        });
                    Embed embed = EmbedBuilder.Build();
                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed);
                }

            } else
            {
                await ReplyAsync("Invaild time format, needs to like this '13:45 -3' and 24 hours.");
            }

        } // should be fixed now

        [Command("help")]
        public async Task Help(string command = null)
        {
            if(command != null) command.ToLower();
            switch (command)
            {
                case "now":
                    var EmbedBuilder_now = new EmbedBuilder()
                        .WithDescription("[Now]\nNow sends a embed with the current time in different time zones.\nEx. !time now 12hours Eastern Standard Time.\n{Subcommands}\n'12', '12h', '12hour', '12hours', '12-hour', '12-hours', 'am', 'pm' or '24h' - 'Time Zone Id'.")
                        .WithFooter(footer =>
                        {
                            footer
                            .WithText("!time help now");
                        });
                    Embed embed_now = EmbedBuilder_now.Build();

                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed_now);
                    break;

                case "time":
                    var EmbedBuilder_time = new EmbedBuilder()
                        .WithDescription("[Time]\nTime tries to parse the time given (formatted like this 23:38) in the given timezone, and outputs a embed showing what the time is other time zone compared to the given time zone.\nEx. !time time 13:21 cet\n{Subcommands}\n'bst', 'cest', 'cet', 'utc', 'est', 'aest', 'ist', 'pst', 'pdt' or 'gmt' - 'am' or 'pm'.")
                        .WithFooter(footer =>
                        {
                            footer
                            .WithText("!time help time");
                        });
                    Embed embed_time = EmbedBuilder_time.Build();

                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed_time);
                    break;

                case "utc":
                    var EmbedBuilder_utc = new EmbedBuilder()
                        .WithDescription("[UTC]\nUTC tries and parse a given time and offset to find a UTC+x(or -x) time and compares it to other time zones.\nEx. !time utc 13:02 -6 pm\n{Subcommands}\n'am' or 'pm'.")
                        .WithFooter(footer =>
                        {
                            footer
                            .WithText("!time help utc");
                        }); 
                    Embed embed_utc = EmbedBuilder_utc.Build();

                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed_utc);
                    break;

                case "ping":
                    var EmbedBuilder_ping = new EmbedBuilder()
                        .WithDescription("[Ping]\nPong.\nEx. !time ping\n{Subcommands}\nNone.")
                        .WithFooter(footer =>
                        {
                            footer
                            .WithText("!time help Ping");
                        });
                    Embed embed_ping = EmbedBuilder_ping.Build();

                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed_ping);
                    break;

                case "easter egg":
                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                    await ReplyAsync("Not done with easter eggs... not that I would tell if there were... :shushing_face:");
                    break;

                case null:
                    var EmbedBuilder_null = new EmbedBuilder()
                        .WithDescription("Command list\nInfo - All commands has a 12 hour variant, just do am or pm in the end\n- Now (!time now 24h/12h timezoneid - !time now - !time now am Eastern Standard Time)\n- Time (!time time HH:mm tz am/pm - !time time 15:32 cest am)\n- Utc (!time utc HH:mm offset am/pm - !time utc 23:51 -3)\n- Ping - Pong\n Maybe some easter eggs :shushing_face:")
                        .WithFooter(footer =>
                        {
                            footer
                            .WithText("!time help");

                        });
                    Embed embed_null = EmbedBuilder_null.Build();

                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed_null);
                    break;
                default:
                    var EmbedBuilder_help = new EmbedBuilder()
                        .WithDescription("Command list\nInfo - All commands has a 12 hour variant, just do am or pm in the end\n- Now (!time now 24h/12h timezoneid - !time now - !time now am Eastern Standard Time)\n- Time (!time time HH:mm tz am/pm - !time time 15:32 cest am)\n- Utc (!time utc HH:mm offset am/pm - !time utc 23:51 -3)\n- Ping - Pong\n Maybe some easter eggs :shushing_face:")
                        .WithFooter(footer =>
                        {
                            footer
                            .WithText("!time help");

                        });
                    Embed embed_help = EmbedBuilder_help.Build();

                    if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
                    await ReplyAsync(embed: embed_help);
                    break;
            }
        

        }

        [Command("SUPERSECRETINTRODUCTIONCOMMAND")]
        public async Task Intro()
        {
            if (Context.Message.Content.StartsWith("!time ")) await Context.Message.DeleteAsync();
            await ReplyAsync("Hello, Im TimeCalculator, a bot made by @ConfuzzedCat with the help of headpats. When I'm not offline, I will help you with finding out time btween time zones. To start do '!time help'. Also if something is broken send it to @ConfuzzedCat");

        }
    }
}
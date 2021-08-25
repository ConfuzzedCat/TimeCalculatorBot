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
            string timeFormat = "HH:mm tt";
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

            //To add: AEST, IST, AKDT, ARE, PST, GMT! and automatic...



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
                        .WithDescription($"({cestTZString}) - {cestTZString1}.\n({cetTZString}) - {cetTZString1}\n({bstTZString}) - {bstTZString1}\n({localUTCString}) - {localUTCString1}\n({estTZString}) - {estTZString1}")
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

                    var EmbedBuilder = new EmbedBuilder()
                        .WithDescription($"({cestTZString}) - {cestTZString1}.\n({cetTZString}) - {cetTZString1}\n({bstTZString}) - {bstTZString1}\n({localUTCString}) - {localUTCString1}\n({estTZString}) - {estTZString1}")
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
            if (getTimeTZ != null)
            {
                getTimeTZ.ToLower();

            }
            DateTime outputTimeParse;
            string timeFormat_Time;
            if (DateTime.TryParse(getTime, out outputTimeParse))
            {
                timeFormat_Time = "HH:mm tt";
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
                                    .WithText("!time time");
                            });
                                                Embed embed_default = EmbedBuilder_default.Build();

                        await ReplyAsync(embed: embed_default);
                        break;

                }
                if (ampm != null) ampm.ToLower();
                if (ampm == "am" || ampm == "pm")
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

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time), CultureInfo.CreateSpecificCulture("en-US");
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            gmtTime = gmtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

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

                            bstTime = bstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cestTime = cestTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            cetTime = cetTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            estTime = estTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            aestTime = aestTimeTemp.ToString(timeFormat_Time), CultureInfo.CreateSpecificCulture("en-US");
                            istTime = istTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pstTime = pstTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            pdtTime = pdtTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));
                            utcTime = utcTimeTemp.ToString(timeFormat_Time, CultureInfo.CreateSpecificCulture("en-US"));

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
                                        .WithText("!time time");
                                });
                            Embed embed_default = EmbedBuilder_default.Build();

                            await ReplyAsync(embed: embed_default);
                            break;

                    }
                }
            } 
            else
            {
                await ReplyAsync("Invaild time format, needs to like this '13:45' and 24 hours.");
            }
            
             

        }
    }
}

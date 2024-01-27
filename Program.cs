//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows;
//using Telegram.Bot;
//using Telegram.Bot.Types.Enums;
//using Telegram.Bot.Types.ReplyMarkups;

//namespace FireflyTelegramBot

using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{
    private static string token = "6840942352:AAF0mgNVubdlVjlrmXQIug0keEgWGm8Xp1w";

    private static TelegramBotClient BotClient;
    static void Main()
    {
        BotClient = new TelegramBotClient(token);
        runBot(BotClient);
        Console.Read();


    }
    static void runBot(TelegramBotClient botClient)
    {
        KeyboardButton[] row1 =
          {
               new KeyboardButton("پروفایل" + "\U0001F464"),
            new KeyboardButton("دوره های من" + "\U0001F4DA")
            };
        KeyboardButton[] row2 =
          {
               new KeyboardButton("راهنمایی" + "\U00002755"),
            new KeyboardButton("درباره ما" + "\U0001F4A1")
            };
        ReplyKeyboardMarkup mainkeyboardMarkup = new ReplyKeyboardMarkup(row1)
        {
            Keyboard = new KeyboardButton[][]
        {
                row1,
                row2
        }
        };
        int offset = 0;
        while (true)
        {
            Telegram.Bot.Types.Update[] updates = botClient.GetUpdatesAsync(offset).Result;
            foreach (var update in updates)
            {
                offset = update.Id + 1;
                if (update.Message == null)
                    continue;

                string messageText = update.Message.Text.ToLower();
                var from = update.Message.From;
                var chatId = update.Message.Chat.Id;
                switch (messageText)
                {
                    case "/start":
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(from.FirstName + "سلام !");
                            stringBuilder.AppendLine("به پنل مدیریتی خودت خوش آمدی !");
                            botClient.SendTextMessageAsync(chatId, stringBuilder.ToString(), 0, null, null, false, false, null, 0, false, mainkeyboardMarkup);
                            break;
                        }
                    case "/aboutus" or "درباره ما" + "\U0001F4A1":
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine("در Firefly، هدف ما ایجاد یک فضای دوستانه و اشتراک تجارب برنامه‌نویسان ");
                            stringBuilder.AppendLine("است. با ما همراه شوید و به جمع ما بپیوندید تا در دنیای گسترده و جذاب");
                            stringBuilder.AppendLine("رنامه‌نویسی، به یک Firefly تبدیل شوید! 🔥🚀");
                            botClient.SendTextMessageAsync(chatId, stringBuilder.ToString());
                            break;
                        }
                    case "/profile" or "پروفایل" + "\U0001F464":
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine("نام : " + from.FirstName);
                            stringBuilder.AppendLine("نام خانوادگی : " + from.LastName);
                            stringBuilder.AppendLine("نام کاربری : " + from.Username);
                            stringBuilder.AppendLine("امتیاز : " + 0);
                            botClient.SendTextMessageAsync(chatId, stringBuilder.ToString());
                            break;
                        }
                    case "/cources" or "دوره های من" + "\U0001F4DA":
                        {
                            KeyboardButton[] row3 =
                            {
                                             new KeyboardButton(" در حال برگزاری"),
                                           new KeyboardButton("تمام شده")
                                };
                            KeyboardButton[] row4 =
                            {
                                            new KeyboardButton("بازگشت"),
                                };
                            ReplyKeyboardMarkup ContactkeyboardMarkup = new ReplyKeyboardMarkup(row1)
                            {
                                Keyboard = new KeyboardButton[][]
                             {
                                 row3,
                                 row4
                             }
                            };

                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine("شما در دوره ای شرکت نکرده اید ");

                            botClient.SendTextMessageAsync(chatId, stringBuilder.ToString(), 0, null, null, false, false, null, 0, false, ContactkeyboardMarkup);
                            break;
                        }
                    case "/help" or "راهنمایی" + "\U00002755":
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine("دستورات :");
                            stringBuilder.AppendLine("راهنمایی : /help");
                            stringBuilder.AppendLine("پروفایل : /profile");
                            stringBuilder.AppendLine("دوره های من : /cources");
                            stringBuilder.AppendLine("درباره ما : /aboutus");
                            botClient.SendTextMessageAsync(chatId, stringBuilder.ToString());
                            break;
                        }
                    case "/back" or "بازگشت":
                        {
                            botClient.SendTextMessageAsync(chatId, "بازگشت انجام شد", 0, null, null, false, false, null, 0, false, mainkeyboardMarkup);

                            break;
                        }

                }
            }
        }
    }
}




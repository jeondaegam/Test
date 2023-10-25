using CSharpExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Tycoon
{
    public class Tycoon
    {
        public static void Main(String[] args)
        {
            GetTycoonImageAndMenu();


            //Console.OutputEncoding = Encoding.UTF8;
            // Console.WriteLine("체력 -🤍💙💛🖤🖤🖤\U0001f5a4💙💛🧡❤🤍🧡💛💚💙💗" +
            //     "💖💝💘💗💓💕❣🤍❤💛💚💜🤎(❤´艸｀❤)❤🖤♡♥♥♥");
            // Console.WriteLine("[\U0001f5a4]");
            // Console.WriteLine("&#129505"); //129505	1F9E1
            //Console.WriteLine("%s", 🖤);

            bool isRunning = true;

            //Bank bank = new Bank(money, name);
            MiniGames miniGame = new MiniGames();
            int.TryParse(Console.ReadLine(), out int selectedOption);

            while (isRunning)
            {
                //bank.WelcomeBank();
                if (selectedOption == 1)
                {
                    WelcomeBank();
                }
                else if (selectedOption == 2)
                {
                    //WelcomeSuperMarket();
                }
                else if (selectedOption == 3)
                {
                    Console.WriteLine("  -------------------------------------------------------------------------");
                    Console.WriteLine("\t\t1. 가위바위보   2. 묵찌빠   3. 하나빼기");
                    Console.WriteLine("  -------------------------------------------------------------------------");
                    int.TryParse(Console.ReadLine(), out selectedOption);

                    switch (selectedOption)
                    {
                        case 1:
                            miniGame.PlayRockPaperScissors();
                            break;

                        case 2:
                            miniGame.PlayMukJjiPpa();
                            break;
                        case 3:
                            miniGame.PlayTakeOneOut();
                            break;
                    }
                }
            }
        }

        private static void GetTycoonImageAndMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Console.WriteLine("                                              ");
            // Console.WriteLine(",--------.                                    ");
            // Console.WriteLine("'--.  .--',--. ,--.,---. ,---. ,---. ,--,--,  ");
            // Console.WriteLine("   |  |    \\  '  /| .--'| .-. | .-. ||      \\ ");
            // Console.WriteLine("   |  |     \\   ' \\ `--.' '-' ' '-' '|  ||  | ");
            // Console.WriteLine("   `--'   .-'  /   `---' `---' `---' `--''--' ");
            // Console.WriteLine("          `---'                               ");

            Console.WriteLine("\n   .-') _                                                        .-') _      ");
            Console.WriteLine("  (  OO) )                                                      ( OO ) )     ");
            Console.WriteLine("  /     '._  ,--.   ,--.  .-----.  .-'),-----.  .-'),-----. ,--./ ,--,'      ");
            Console.WriteLine("  |'--...__)  \\  `.'  /  '  .--./ ( OO'  .-.  '( OO'  .-.  '|   \\ |  |\\   ");
            Console.WriteLine("  '--.  .--'.-')     /   |  |('-. /   |  | |  |/   |  | |  ||    \\|  | )    ");
            Console.WriteLine("     |  |  (OO  \\   /   /_) |OO  )\\_) |  |\\|  |\\_) |  |\\|  ||  .     |/ ");
            Console.WriteLine("     |  |   |   /  /\\_  ||  |`-'|   \\ |  | |  |  \\ |  | |  ||  |\\    |   ");
            Console.WriteLine("     |  |   `-./  /.__)(_'  '--'\\    `'  '-'  '   `'  '-'  '|  | \\   |     ");
            Console.WriteLine("     `--'     `--'        `-----'      `-----'      `-----' `--'  `--'     \n");

            Console.ResetColor();
            
            Console.WriteLine("  -------------------------------------------------------------------------");
            Console.WriteLine("\t\t1. BANK   2. SUPERMARKET   3. GAMES");
            Console.WriteLine("  -------------------------------------------------------------------------");
            Console.Write("\t\t\t\t");
        }
        

        private static void WelcomeBank()
        {
            // 은행
            int money = 100000;
            String name = "yeoreum";
            Bank bank = new Bank(money, name);
            int selectedOption = bank.ShowStatus();

            if (selectedOption == 1)
            {
                // 1. 입금
                bank.Deposit();
            }
            else if (selectedOption == 2)
            {
                // 2. 출금
                bank.Withdraw();
            }
            else if (selectedOption == 3)
            {
                // 3. 이자계산 메뉴
                selectedOption = bank.ShowInterestMenu();

                if (selectedOption == 1)
                {
                    // 3-1. 단리
                    int date = bank.GetDate();
                    float interestRate = bank.GetInterestRate();
                    bank.AddSimpleInterest(date, interestRate);
                }
                else
                {
                    // 3-2. 복리
                    int date = bank.GetDate();
                    float interestRate = bank.GetInterestRate();
                    bank.CompoundInterest(date, interestRate);
                }

            }
        }
    }
}

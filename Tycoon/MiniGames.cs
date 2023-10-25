using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Tycoon
{
    public class MiniGames
    {
        public static int PcWin = 0;
        public static int PlayerWin = 1;
        public static int Draw = -1;

        // 가위바위보
        private (int, int) RockPaperScissors()
        {
            String[] items = { "가위", "바위", "보" };
            Random random = new Random();

            Console.WriteLine("1.가위 2.바위 3.보");
            int.TryParse(Console.ReadLine(), out int player);
            int pc = random.Next(items.Length);

            switch (player)
            {
                case 1:
                    player = 0;
                    break;
                case 2:
                    player = 1;
                    break;
                case 3:
                    player = 2;
                    break;
            }
            
            Console.WriteLine("PC:{0} YOU:{1}", items[pc], items[player]);

            return (player, pc);
        }
        
        private int WhoWon(int pcItem, int playerItem)
        {
            //items = { "가위", "바위", "보" };

            if (pcItem == (playerItem + 1) % 3)
            {
                Console.WriteLine("패배!");
                return PcWin;
            }
            if (pcItem == playerItem)
            {
                return Draw;
            }
            Console.WriteLine("승리!");
            return PlayerWin;
        }



        public void PlayRockPaperScissors()
        {
            Boolean isPlaying = true;
            int player;
            int pc;
            int score = 0;

            // 무승부면 계속해야하는거아님?
            while (isPlaying)
            {
                (player, pc) = RockPaperScissors();
                {
                    int result = WhoWon(pc, player);
                    if (result == PlayerWin)
                    {
                        score += 100;
                    }
                    else if (result == PcWin)
                    {
                        score -= 100;
                    }
                }
            }
        }
        //WhosWin?
        // private int WhosWin(int player, int pc)
        // {
        //     String[] items = { "가위", "바위", "보" };
        //
        //     if (pc == (player + 1) % 3)
        //     {
        //         // 1 == (0+1)%3 
        //         Console.WriteLine("PC >" + items[pc]);
        //         Console.WriteLine("Player >" + items[player]);
        //         // Console.WriteLine("패배! SCORE <{0}>", score);
        //         Console.WriteLine("패배!");
        //         return PcWin;
        //     }
        //     else if (pc == player)
        //     {
        //         //무승부
        //         Console.WriteLine("PC >" + items[pc]);
        //         Console.WriteLine("Player >" + items[player]);
        //         Console.WriteLine("무승부!");
        //         // Console.WriteLine("무승부! SCORE <{0}>", score);
        //         return Draw;
        //     }
        //     else
        //     {
        //         Console.WriteLine("PC >" + items[pc]);
        //         Console.WriteLine("Player >" + items[player]);
        //         // Console.WriteLine("승리! SCORE <{0}>", score);
        //         Console.WriteLine("승리!");
        //         return PlayerWin;
        //     }
        // }
        
        

        // 하나빼기
        public void PlayTakeOneOut()
        {
            int[] playerItems, pcItems = new int[2];
            Random random = new Random();
            Dictionary<int, String> threeItems = new Dictionary<int, string>();
            threeItems.Add(0, "가위");
            threeItems.Add(1, "바위");
            threeItems.Add(2, "보");

            Console.WriteLine("--- 가위바위보 하나빼기 START ---");

            while (true)
            {
                List<int> randomList = new List<int>();
                randomList.Add(0);
                randomList.Add(1);
                randomList.Add(2);

                // 1. 가위 바위 보 중 둘을 입력받는다.
                Console.WriteLine("------ 두가지를 입력하세요 ------");
                Console.WriteLine("\t0.가위 1.바위 2.보");

                // 유저 - 2 가지 선택
                playerItems = Array.ConvertAll(Console.ReadLine().Split(), card => int.Parse(card));

                // PC - 2 가지 랜덤 선택 (중복 X)
                for (int i = 0; i < 2; i++)
                {
                    int num = random.Next(randomList.Count);
                    pcItems[i] = randomList[num];
                    randomList.RemoveAt(num);
                }

                Console.WriteLine("------------------------------------");
                Console.WriteLine("Player\t:{0},{1}", threeItems[playerItems[0]], threeItems[playerItems[1]]);
                Console.WriteLine("PC\t:{0},{1}", threeItems[pcItems[0]], threeItems[pcItems[1]]);
                Console.WriteLine("------------------------------------");

                // 2. 하나 빼기
                Console.WriteLine("둘중 하나를 선택하세요. 0.{0}, 1.{1}", 
                    threeItems[playerItems[0]], threeItems[playerItems[1]]);
                int.TryParse(Console.ReadLine(), out int playerItem);
                
                playerItem = playerItems[playerItem];
                int pcItem = pcItems[random.Next(pcItems.Length)];
                
                Console.WriteLine("------------------------------------");
                Console.WriteLine("PC\t:{0}", threeItems[pcItem]);
                Console.WriteLine("Player\t:{0}", threeItems[playerItem]);
                Console.WriteLine("------------------------------------");
                
                //가위바위보
                WhoWon(pcItem, playerItem);
            }
        }

        // 묵찌빠
        public void PlayMukJjiPpa()
        {
            String[] items = { "가위", "바위", "보" };
            // String[] mukJjiPpa = { "찌", "묵", "빠" };
            Random random = new Random();
            int pc;
            int player;
            int attackTurn = -1; // 0:pc, 1:player
            int[] scores = new int[2];
            Boolean isPlaying = true;
            
            GetMukJjiPpaImage();
            Console.WriteLine("--------------선공 정하기---------------");

            // 가위바위보 - 선공 정하기 (정해질때까지 반복해야함)
            while (isPlaying)
            {
                (player, pc) = RockPaperScissors();
                Console.WriteLine("----------------------------------");
                Console.WriteLine("PC: {0}, YOU: {1}", items[pc], items[player]);
                int result = WhoWon(player, pc);

                // 플레이어 승리
                if (result == PlayerWin)
                {
                    // 주도권: 플레이어
                    attackTurn = PlayerWin;
                    isPlaying = false;
                    
                    Console.WriteLine("----선공입니다---");
                }
                else if (result == PcWin)
                {
                    // 주도권: PC
                    attackTurn = PcWin;
                    isPlaying = false;
                    Console.WriteLine("----PC선공입니다---");
                }
            }


            Console.WriteLine("--------------묵찌빠 시작-------------");
            isPlaying = true;
            while (isPlaying)
            {
                Console.WriteLine("1.묵 2.찌 3.빠 -1.종료");
                int.TryParse(Console.ReadLine(), out player);
                pc = random.Next(0, items.Length);

                switch (player)
                {
                    case 2:
                        player = 0;
                        break;
                    case 3:
                        player = 2;
                        break;
                    case -1:
                        return;
                }
                
                Console.Clear();
                int result = WhoWon(pc, player);

                if (result == PcWin)
                {
                    // 주도권: pc
                    attackTurn = PcWin;
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("PC CHOICE :");
                    GetGameImage(pc);
                    Console.ResetColor();
                    Console.WriteLine("YOU CHOICE :");
                    GetGameImage(player);
                    
                    Console.WriteLine("---------------상대방 턴 !---------------");
                }
                else if (result == Draw)
                {
                    if (attackTurn == PlayerWin)
                    {
                        scores[PlayerWin] += 100;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("PC CHOICE :");
                        GetGameImage(pc);
                        Console.WriteLine("YOU CHOICE :");
                        GetGameImage(player);
                        Console.ResetColor();
                        
                        Console.WriteLine("\t\t\t+100Point\n\t\t\t\tSCORE:{0}", scores[PlayerWin]);
                        Console.WriteLine("--------------당신 턴입니다!-------------");
                    }
                    else
                    {
                        scores[PlayerWin] -= 100;
                        
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("PC CHOICE :");
                        GetGameImage(pc);
                        Console.ResetColor();
                        Console.WriteLine("YOU CHOICE :");
                        GetGameImage(player);

                        Console.WriteLine("\t\t\t-100point SCORE:{0}", scores[PlayerWin]);
                        Console.WriteLine("---------------상대방 턴 !---------------");
                    }
                }
                else
                {
                    // 주도권 : player
                    attackTurn = PlayerWin;
                    
                    Console.WriteLine("PC CHOICE :");
                    GetGameImage(pc);
                    Console.WriteLine("YOU CHOICE :");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    GetGameImage(player);
                    Console.ResetColor();
                    Console.WriteLine("--------------당신 턴입니다!-------------");
                }
            }
        }



        private void GetGameImage(int num)
        {
            switch (num)
            {
                case 0 :
                    Console.WriteLine("    _______");
                    Console.WriteLine("---'   ____)____");
                    Console.WriteLine("          ______)");
                    Console.WriteLine("       __________)");
                    Console.WriteLine("      (____)");
                    Console.WriteLine("---.__(___)\n");
                    break;
                case 1 :
                    Console.WriteLine("    _______");
                    Console.WriteLine("---'   ____)");
                    Console.WriteLine("      (_____)");
                    Console.WriteLine("      (_____)");
                    Console.WriteLine("      (____)");
                    Console.WriteLine("---.__(___)\n");
                    break;
                case 2 :
                    Console.WriteLine("    _______");
                    Console.WriteLine("---'   ____)____");
                    Console.WriteLine("          ______)");
                    Console.WriteLine("          _______)");
                    Console.WriteLine("         _______)");
                    Console.WriteLine("---.__________)\n");
                    break;
            }
        }

        private void GetGameStartImage()
        {
            Console.Clear();
            Console.WriteLine("\n                                                                                  ");
            Console.WriteLine("   ,----.    ,---. ,--.   ,--,------.     ,---.,--------.,---. ,------.,--------.   ");
            Console.WriteLine("  '  .-./   /  O  \\|   `.'   |  .---'    '   .-'--.  .--/  O  \\|  .--. '--.  .--' ");
            Console.WriteLine("  |  | .---|  .-.  |  |'.'|  |  `--,     `.  `-.  |  | |  .-.  |  '--'.'  |  |      ");
            Console.WriteLine("  '  '--'  |  | |  |  |   |  |  `---.    .-'    | |  | |  | |  |  |\\  \\   |  |    ");
            Console.WriteLine("   `------'`--' `--`--'   `--`------'    `-----'  `--' `--' `--`--' '--'  `--'      ");
            Console.WriteLine("                                                                                  ");
            Console.WriteLine("  ----------------------------------------------------------------------------------\n");
        }

        private void GetMukJjiPpaImage()
        {
            Console.Clear();
            Console.WriteLine("\n  ,--.   ,--.        ,--.        ,--. ,--.,--.,------.                   ");
            Console.WriteLine("  |   `.'   |,--.,--.|  |,-.     |  | `--'`--'|  .--. ' ,---.  ,--,--.     ");
            Console.WriteLine("  |  |'.'|  ||  ||  ||     /,--. |  | ,--.,--.|  '--' || .-. |' ,-.  |     ");
            Console.WriteLine("  |  |   |  |'  ''  '|  \\  \\|  '-'  / |  ||  ||  | --' | '-' '\\ '-'  |  ");
            Console.WriteLine("  `--'   `--' `----' `--'`--'`-----'.-'  /`--'`--'     |  |-'  `--`--'     ");
            Console.WriteLine("                                  '---'              `--'                \n");
        }
        

        // public static void Main(string[] args)
        // {
        //     Boolean isPlaying = true;
        //     MiniGames miniGames = new MiniGames();
        //     int score = 0;
        //     int player;
        //     int pc;
            // Console.WriteLine("1.가위 2.바위 3.보");
            // int.TryParse(Console.ReadLine(), out int player);
            // int pc = random.Next(items.Length);
            // games.MukJjiPpa();
            // (int, int) num = games.PlayRockPaperScissors();

            // games.WhosWin(pc, player, out bool isDraw);

            //무승부면 계속해야하는거아님?
            // while (isPlaying)
            // {
            //     (player, pc) = games.PlayRockPaperScissors();
            //     {
            //         int result = games.WhosWin(pc, player);
            //         if (result == PlayerWin)
            //         {
            //             score += 100;
            //             isPlaying = false;
            //         }
            //         else if (result == PcWin)
            //         {
            //             isPlaying = false;
            //         }
            //     }
            // }

            // 하나빼기 - ㅇ
            // miniGames.TakeOneOut();

            //묵찌빠
            // miniGames.MukJjiPpa();
            // Console.WriteLine("hey");
            // int x = 5;
            // int y = 5;
            // Console.SetCursorPosition(x, y);
            // ConsoleKeyInfo cursor = Console.ReadKey();
            // if (cursor.Key == ConsoleKey.RightArrow)
            // {
            //     Console.SetCursorPosition(++x, y);
            // }
            //
            //
            // // Console.SetCursorPosition(Console.cU);
            // cursor = Console.ReadKey();
            // if (cursor.Key == ConsoleKey.Enter)
            // {
            //     Console.WriteLine("enter");
            // }

        // }
    }
}

// Ascii Art - text: http://patorjk.com/software/taag/#p=display&h=3&f=Soft&t=GAME%20START
// Ascii Art - image file : https://www.ascii-art-generator.org/        https://wepplication.github.io/tools/asciiArtGen/?fontSelector=Coinstak&userInput=%EC%95%84%EC%8A%A4%ED%82%A4

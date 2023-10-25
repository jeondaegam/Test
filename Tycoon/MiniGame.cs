using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tycoon
{
    public class MiniGame
    {
        // 가위바위보
        public void StartRockScissorsPaper()
        {
            String[] items = { "가위", "바위", "보" };
            int score = 0;
            String win = "win";
            String lose = "lose";
            String draw = "draw";
            bool isRunning = true;
            Random random = new Random();
            int pc = 0;

            Console.WriteLine("---가위바위보 START---");

            while (isRunning)
            {
                Console.WriteLine("0.가위 1.바위 2.보 -1.종료");
                int.TryParse(Console.ReadLine(), out int user);
                pc = random.Next(0, items.Length);

                // 프로그램 종료
                if (user == -1)
                {
                    isRunning = false;
                }

                if (pc == (user + 1) % 3)
                {
                    // 1 == (0+1)%3 
                    Console.WriteLine("User >" + items[user]);
                    Console.WriteLine("PC >" + items[pc]);
                    SetResult(lose, score);
                }
                else if (user == pc)
                {
                    //무승부
                    Console.WriteLine("User >" + items[user]);
                    Console.WriteLine("PC >" + items[pc]);
                    SetResult(draw, score);
                }
                else
                {
                    Console.WriteLine("User >" + items[user]);
                    Console.WriteLine("PC >" + items[pc]);
                    score += 100;
                    SetResult(win, score);
                }
            }
        }

        // 묵찌빠
        public void StartMukJiPpa()
        {
            String[] items = { "찌", "묵", "빠" };
            Random random = new Random();
            int pc = 0;
            int user = 0;
            int attackTurn = -1; // 0:pc // 1:user
            int[] scores = new int[2];


            Console.Clear();
            Console.WriteLine("--------------묵찌빠 START---------------");

            while (true)
            {
                Console.WriteLine("0.묵 1.찌 2.빠 -1.종료");
                int.TryParse(Console.ReadLine(), out user);
                pc = random.Next(0, items.Length);

                switch (user)
                {
                    case 0:
                        user = 1;
                        break;
                    case 1:
                        user = 0;
                        break;
                }

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("USER:{0} vs PC:{1}", items[user], items[pc]);

                // user 패배
                if (pc == (user + 1) % 3)
                {
                    // 주도권 변경 -> PC
                    attackTurn = 0;
                    Console.WriteLine("패배!");
                    Console.WriteLine("---------------상대방 턴 !---------------");
                }

                // 무승부
                else if (user == pc)
                {
                    if (attackTurn == -1)
                    {
                        Console.WriteLine("무승부!");
                        continue;
                    }

                    scores[attackTurn] += 100;
                    Console.WriteLine("\t\t\t+100point SCORE:{0}", scores[attackTurn]);
                    //break;
                }
                else
                {
                    // user 승리 
                    // 주도권 변경 -> user
                    attackTurn = 1;
                    Console.WriteLine("승리!");
                    Console.WriteLine("--------------당신 턴입니다!-------------");
                }
            }
        }


        private void RockPaperScissorsTakeOneOut()
        {
            int score = 0;
            Dictionary<int, String> items = new Dictionary<int, string>();
            items.Add(0, "가위");
            items.Add(1, "바위");
            items.Add(2, "보");
            // String[] items = { "가위", "바위", "보" };

            List<int> numberCards = new List<int>();
            numberCards.Add(0);
            numberCards.Add(1);
            numberCards.Add(2);
            int[] playerCards, pcCards = new int[2];
            // int[] pcCards = new int[2];
            Random random = new Random();

            while (true)
            {
                Console.WriteLine("--- 가위바위보 하나빼기 START ---");
                Console.WriteLine("------ 두가지를 입력하세요 ------");
                Console.WriteLine("\t0.가위 1.바위 2.보");

                // 유저 - 카드 2장 입력
                playerCards = Array.ConvertAll(Console.ReadLine().Split(), card => int.Parse(card));

                // PC - 카드 2장 랜덤 선택 (중복 X)
                for (int i = 0; i < 2; i++)
                {
                    int num = random.Next(numberCards.Count);
                    pcCards[i] = numberCards[num];
                    numberCards.RemoveAt(num);
                }

                Console.WriteLine("Player\t:{0},{1}", items[playerCards[0]], items[playerCards[1]]);
                Console.WriteLine("PC\t:{0},{1}", items[pcCards[0]], items[pcCards[1]]);

                // 하나 빼기
                Console.WriteLine("둘중 하나를 선택하세요. 0.{0}, 1.{1}", items[playerCards[0]], items[playerCards[1]]);
                int.TryParse(Console.ReadLine(), out int playerSelected);
                playerSelected = playerCards[playerSelected];
                Console.WriteLine("Player의 선택\t:{0}", items[playerSelected]);

                int pcSelected = random.Next(pcCards.Length);
                pcSelected = pcCards[pcSelected];
                Console.WriteLine("PC의 선택\t:{0}", items[pcSelected]);

                if (pcSelected == (playerSelected + 1) % 3)
                {
                    // 1 == (0+1)%3 
                    Console.WriteLine("PC >" + items[pcSelected]);
                    SetResult("lose", score);
                }
                else if (playerSelected == pcSelected)
                {
                    //무승부
                    Console.WriteLine("PC >" + items[pcSelected]);
                    SetResult("draw", score);
                }
                else
                {
                    Console.WriteLine("PC >" + items[pcSelected]);
                    score += 100;
                    SetResult("win", score);
                }
            }
        }

        private void RockPaperScissorsTakeOneOut2()
        {
            String[] items = { "가위", "바위", "보" };
            List<int> itemsTwo = new List<int>();
            itemsTwo.Add(0);
            itemsTwo.Add(1);
            itemsTwo.Add(2);
            int[] playerSelected = new int[2];
            int[] pcSelected = new int[2];
            int user = 0;
            int score = 0;
            String win = "win";
            String lose = "lose";
            String draw = "draw";
            bool isRunning = true;
            Random random = new Random();
            int randomNum = 0;
            int pc = 0;

            Console.WriteLine("---가위바위보 하나빼기 START---");

            while (isRunning)
            {
                Console.WriteLine("---두가지를 입력하세요---");
                Console.WriteLine("0.가위 1.바위 2.보");

                playerSelected = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));

                Console.WriteLine(playerSelected[0] + "," + playerSelected[1]);
                //int.TryParse(Console.ReadLine(), out int user);
                pc = random.Next(0, items.Length);

                Console.WriteLine("USER\t>{0},{1}", items[playerSelected[0]], items[playerSelected[1]]);

                // PC의 랜덤값
                pcSelected[0] = random.Next(items.Length);
                // 값을 제외 하고 랜덤값을 뽑기
                // pcSelected[1] = random.Next(0, 3 - pcSelected.Count);
                // pcSelected[1] = random.Next(items.Length);

                //while (pcSelected[0] == pcSelected[1])
                //{
                //    pcSelected[1] = random.Next(items.Length);
                //}

                int randomNumsOne = random.Next(itemsTwo.Count);
                int one = itemsTwo[randomNumsOne];
                itemsTwo.RemoveAt(randomNumsOne);

                int randomNumsTwo = random.Next(itemsTwo.Count);
                int two = itemsTwo[randomNumsTwo];

                // for (int i = 0; i < itemsTwo.Count; i++)
                // {
                //     int numOne = random.Next(itemsTwo.Count);
                //     String selectedCard = items[numOne];
                // }


                Console.WriteLine("PC\t> {0}, {1}", one, two);
                //Console.WriteLine("PC:{0},{1}", items[pcSelected[0]], items[pcSelected[1]]);

                //뭘 낼지 선택
                Console.WriteLine("무엇을 낼지 선택 하세요");

                for (int i = 0; i < playerSelected.Length; i++)
                {
                    Console.Write("{0}.{1} ", i, playerSelected[i]);
                }

                int.TryParse(Console.ReadLine(), out int num);
                Console.WriteLine("User 하나빼기  : {0}", items[playerSelected[0]]);
            }
        }

        private void SetResult(String result, int score)
        {
            switch (result)
            {
                case "win":
                    Console.WriteLine("승리! SCORE <{0}>", score);
                    break;

                case "lose":
                    Console.WriteLine("패배! SCORE <{0}>", score);
                    break;

                default:
                    Console.WriteLine("무승부! SCORE <{0}>", score);
                    break;
            }
        }

        private int RockPaperScissors(int playerChoice, int pcChoice, int score)
        {
            String[] items = { "가위", "바위", "보" };

            if (pcChoice == (playerChoice + 1) % 3)
            {
                // 1 == (0+1)%3 
                Console.WriteLine("PC >" + items[pcChoice]);
                Console.WriteLine("패배! SCORE <{0}>", score);
            }
            else if (playerChoice == pcChoice)
            {
                //무승부
                Console.WriteLine("PC >" + items[pcChoice]);
                Console.WriteLine("무승부! SCORE <{0}>", score);
            }
            else
            {
                Console.WriteLine("PC >" + items[pcChoice]);
                score += 100;
                Console.WriteLine("승리! SCORE <{0}>", score);
            }

            return score;
        }

        private void setMessage()
        {
            Console.WriteLine("      ___           ___                                       ___     ");
            Console.WriteLine("     /__/\\         /  /\\                                     /  /\\    ");
            Console.WriteLine("     \\  \\:\\       /  /:/_                                   /  /::\\   ");
            Console.WriteLine("      \\__\\:\\     /  /:/ /\\    ___     ___   ___     ___    /  /:/\\:\\  ");
            Console.WriteLine("  ___ /  /::\\   /  /:/ /:/_  /__/\\   /  /\\ /__/\\   /  /\\  /  /:/  \\:\\ ");
            Console.WriteLine(" /__/\\  /:/\\:\\ /__/:/ /:/ /\\ \\  \\:\\ /  /:/ \\  \\:\\ /  /:/ /__/:/ \\__\\:\\");
            Console.WriteLine(" \\  \\:\\/:/__\\/ \\  \\:\\/:/ /:/  \\  \\:\\  /:/   \\  \\:\\  /:/  \\  \\:\\ /  /:/");
            Console.WriteLine("  \\  \\::/       \\  \\::/ /:/    \\  \\:\\/:/     \\  \\:\\/:/    \\  \\:\\  /:/ ");
            Console.WriteLine("   \\  \\:\\        \\  \\:\\/:/      \\  \\::/       \\  \\::/      \\  \\:\\/:/  ");
            Console.WriteLine("    \\  \\:\\        \\  \\::/        \\__\\/         \\__\\/        \\  \\::/   ");
            Console.WriteLine("     \\__\\/         \\__\\/                                     \\__\\/    ");
        }

        public static void Main(String[] args)
        {
            //int[] results = new int[3];
            //Sum(10, results);
            //Console.WriteLine("모든 수의 합:" + results[0]);
            //Console.WriteLine("짝수의 합:" + results[1]);
            //Console.WriteLine("홀수의 합:" + results[2]);
            MiniGame game = new MiniGame();
            Console.WriteLine("dd");
            // game.RockPaperScissorsTakeOneOut();
            //
            // Ra
            // Console.WriteLine("0.가위 1.바위 2.보 -1.종료");
            // int.TryParse(Console.ReadLine(), out int user);
            // int pc = random.Next(0, items.Length);
            // game.RockPaperScissors(user, pc);
            // game.setMessage();
        }
    }
}
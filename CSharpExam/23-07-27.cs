using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExam
{
    internal class _23_07_25
    {
        static float[] Calculate(float radius, float[] results)
        {
            const float pi = 3.141592f;
            results[0] = pi * radius * radius;
            results[1] = pi * 2 * radius;
            return results;
        }


        // 함수 만들기
        // 1 ~ n 까지의 합
        // 1 ~ n 까지의 모든 짝수의 합
        // 1 ~ n 까지의 모든 홀수의 합
        // 3가지 결과 모두 리턴받기


        static void Sum(int n, int[] result)
        {
            for (int i = 0; i <= n; i++)
            {
                // 모든 수 합
                result[0] = result[0] + i;

                // 짝수 합
                if (i % 2 == 0)
                {
                    result[1] = result[1] + i;
                }
                else
                {
                    result[2] = result[2] + i;
                }
            }
            //Array.ForEach(result, num => Console.WriteLine(num));
        }

        // 여러 값 리턴 하기
        static void Sum(int n, out int sum, out int evenSum, out int oddSum)
        {
            sum = 0;
            evenSum = 0;
            oddSum = 0;
            for (int i = 0; i <= n; i++)
            {
                // 모든 수 합
                sum = +i;

                // 짝수 합
                if (i % 2 == 0)
                {
                    evenSum += i;
                }
                else
                {
                    oddSum += i;
                }
            }
        }

        // 가위바위보
        static void StartRockScissorsPaper()
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
                Console.WriteLine("0.찌 1.묵 2.빠 -1.종료");
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
                    Console.WriteLine("PC >" + items[pc]);
                    SetResult(lose, score);

                }
                else if (user == pc)
                {
                    //무승부
                    Console.WriteLine("PC >" + items[pc]);
                    SetResult(draw, score);
                }
                else
                {
                    Console.WriteLine("PC >" + items[pc]);
                    score += 100;
                    SetResult(win, score);
                }
            }

        }

        // 묵찌빠
        static void StartMukjippa()
        {
            String[] items = { "찌", "묵", "빠" };
            int score = 0;
            String win = "win";
            String lose = "lose";
            String draw = "draw";

            bool isRunning = true;
            Random random = new Random();
            int pc = 0;
            int user = 0;
            bool isUserMainPlayer = false;
            int attackTurn = -1; // 0:pc // 1:user
            int[] scores = new int[2];


            Console.WriteLine("---묵찌빠 START---");

            while (isRunning)
            {
                Console.WriteLine("0.찌 1.묵 2.빠 -1.종료");
                int.TryParse(Console.ReadLine(), out user);
                pc = random.Next(0, items.Length);

                Console.Write("User:{0}, PC:{1}", items[user], items[pc]);


                // user 패배
                if (pc == (user + 1) % 3)
                {
                    // 주도권 변경 -> PC
                    attackTurn = 0;
                    Console.Write(" <PC 승리>\n");
                    Console.WriteLine("--- PC TURN ---");
                }

                else if (user == pc)
                {
                    if (attackTurn == -1)
                    {
                        continue;
                    }
                    //무승부
                    scores[attackTurn] += 100;
                    Console.WriteLine(" <Score:{0}>", scores[attackTurn]);
                    //break;
                }
                else
                {
                    // user 승리 
                    // 주도권 변경 -> user
                    attackTurn = 1;
                    Console.Write(" <승리!>\n");
                    Console.WriteLine("--- USER TURN ---");
                }
            }
        }


        static void SetResult(String result, int score)
        {
            if (result.Equals("win"))
            {
                Console.WriteLine("승리! SCORE <{0}>", score);
            }
            else if (result.Equals("lose"))
            {
                Console.WriteLine("패배! SCORE <{0}>", score);
            }
            else
            {
                Console.WriteLine("무승부! SCORE <{0}>", score);
            }
        }

        public static void Main(String[] args)
        {
            //int[] results = new int[3];
            //Sum(10, results);
            //Console.WriteLine("모든 수의 합:" + results[0]);
            //Console.WriteLine("짝수의 합:" + results[1]);
            //Console.WriteLine("홀수의 합:" + results[2]);

            // Console.WriteLine("---------------------");
            // Console.WriteLine("1.가위바위보 2.묵찌빠");
            // Console.WriteLine("---------------------");
            //
            // int.TryParse(Console.ReadLine(), out int gameType);
            //
            // if (gameType == 1)
            // {
            //     StartRockScissorsPaper();
            // }
            // else
            // {
            //     StartMukjippa();
            // }
            
            Sum(10, out int sum, out int evenSum, out int oddSum);
            Console.WriteLine(oddSum);
            Console.WriteLine(evenSum);
            Console.WriteLine(sum);

        }
    }
}




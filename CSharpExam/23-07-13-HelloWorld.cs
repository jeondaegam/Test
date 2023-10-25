using System;

namespace CSharpExam
{
    internal class HelloWorld
    {
        public static void Main(string[] args)
        {
            //for (int i = 0; i < 10; i++) // 0 = 리터럴
            //{
            //    Console.WriteLine("*****");
            //}

            // 실수 자료형
            float a = 3.0f; // 4byte 실수
            double b = 3.0; // 8byte 실수

            //int k = 3;
            //int m = 5;
            //Console.WriteLine(k < m);

            // [별찍기-2] : 8*5 사각형 만들기
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write('*');
            //    }
            //    Console.WriteLine();

            //}

            // [별찍기-3] : 삼각형 만들기
            //int N;
            //Console.WriteLine("숫자를 입력하세요 .");
            //string StrN = Console.ReadLine(); // input
            //int.TryParse(StrN, out N);

            ////Console.WriteLine(StrN);

            //for (int i = 0; i < N; i++)
            //{
            //    for (int j = 0; j < i + 1; j++)
            //    {
            //        Console.Write('*');
            //    }
            //    Console.WriteLine();
            //}

            bool B = 1 > 0;

            for (; B;)
            {
                int num;
                Console.WriteLine("숫자를 입력하세요 .");
                string str = Console.ReadLine(); // input
                int.TryParse(str, out num);


                // [별찍기 -4] : N층 피라미드 만들기
                // 1층 => (n-1)4개 / 1개 (
                for (int i = 0; i < num; i++)
                {
                    for (int j = 0; j < num - i - 1; j++)
                    {
                        Console.Write(' ');
                    }
                    for (int k = 0; k < (2 * i) + 1; k++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();
                }

                // [별찍기 -5] : 역피라미드 만들기
                // 1층 => 공백 0개 / 별 9개(2*N-1)
                // 2층 => 공백 1개 / 별 7개(2*N-1-2)
                // 3층 => 공백 2개 / 별 5개(2*N-1-2
                // 5층 => 공백 4개 / 별 1개
                //for (int i = 0; i < num; i++)
                //{
                //    for (int j = 0; j < i; j++)
                //    {
                //        Console.Write(' ');
                //    }
                //    for (int k = 0; k < num * 2 - 1 - i * 2; k++)
                //    {
                //        Console.Write("*");
                //    }
                //    Console.WriteLine();
                //}


                //for (int i = num-1; i >= 0; i--)
                //{
                //    for (int j = 0; j < num - i - 1; j++)
                //    {
                //        Console.Write(' ');
                //    }
                //    for (int k = 0; k < i * 2 + 1; k++)
                //    {
                //        Console.Write('*');
                //    }
                //    Console.WriteLine();
                //}

            }
        }
    }
}

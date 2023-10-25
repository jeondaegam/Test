//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSharpExam
//{
//    // 피로도 = 입장할때마다 -1, 체력회복 구매 +1
//    // 수강시간 (n회), 이수학점, 피로도,  과목수강[선택과목+1] = 수강시간을 채우면 [수강완료],
//    // 
//    internal class _23_07_20_Stock
//    {
//        // 원의 둘레 구하기
//        public static float Calculate(float radius)
//        {
//            const float pi = 3.14f;
//            return 2 * pi * radius;
//        }

//        // n의 m제곱 구하기
//        public static int Calc(int n, int m)
//        {
//            int result = 1;
//            for (int i = 0; i < m; i++)
//            {
//                result *= n;
//            }
//            return result;
//        }

//        public static void Main(String[] args)
//        {
//            //float area = Calculate(2.5f);
//            //Console.WriteLine($"원의 넓이는 {area} 입니다.");

//            Console.WriteLine(Calc(2, 3));

//            bool isRunning = true;
//            Random random = new Random();

//            // [1] 주식 시장
//            double myMoney = 100000; // 보유잔액
//            int menuOption = 0; // 메뉴 선택 옵션

//            string[] stockNames = { "MS", "Meta", "Apple" };
//            int[] stockWallet = { 0, 0, 0 }; // 주식 보유 수량
//            double[] stockPrices = { 10000, 10000, 10000 }; // 주식 상승률이 적용된 주가
//            int[] randomPercent = new int[3];
//            //

//            // [2] 대학교
//            // 강의 목록
//            String[] lectures = { "C#", "Unity", "Unreal", "3DsMax" };

//            // 나의 수강내역
//            bool[] myLectures = new bool[4];
//            // 학점
//            int[] myScore = new int[4];
//            Dictionary<string, double> scores = new Dictionary<string, double>();
//            scores.Add("A", 4.0);
//            scores.Add("B", 3.0);
//            scores.Add("C", 2.0);
//            scores.Add("D", 1.0);
//            scores.Add("F", 0.0);



//            while (isRunning)
//            {

//                Console.WriteLine("[1]주식시장 [2] 대학교");
//                int.TryParse(Console.ReadLine(), out menuOption);

//                // [1] 주식시장 ==============================================================
//                if (menuOption == 1)
//                {
//                    // 주가 상승률적용
//                    //for (int i = 0; i < stockPrices.Length; i++)
//                    //{
//                    //    // 변동폭
//                    //    randomPercent[i] = random.Next(-50, 101);
//                    //    // 주가에 변동폭 적용
//                    //    stockPrices[i] = stockPrices[i] + (stockPrices[i] * randomPercent[i] / 100f);
//                    //}

//                    //Console.WriteLine("===========================================");
//                    //Console.WriteLine("이름       주가       변동폭       보유수량");
//                    //Console.WriteLine("===========================================");
//                    //for (int j = 0; j < stockNames.Length; j++)
//                    //{
//                    //    Console.WriteLine("{0}       {1}         {2}%          {3}", stockNames[j], stockPrices[j], randomPercent[j], stockWallet[j]);
//                    //}
//                    //Console.WriteLine("===========================================");
//                    //Console.WriteLine("MyMoney : {0}", myMoney);
//                    menuOption = ViewStockList();



//                    if (menuOption == 1)  // 1 - 매수
//                    {
//                        // 매수할 종목 입력받기
//                        Console.WriteLine("[1]MicroSoft [2]Meta [3]Apple");
//                        int.TryParse(Console.ReadLine(), out int stockName);

//                        // 수량 입력받기
//                        Console.WriteLine("매수할 수량을 입력하세요.");
//                        int.TryParse(Console.ReadLine(), out int count);
//                        Console.WriteLine("===========================================");

//                        // 매수가격 계산 = 주가 * 수량
//                        int purchase = (int)(stockPrices[stockName - 1] * count);
//                        Console.WriteLine("매수 가격 : " + purchase);

//                        // 보유 금액 변경
//                        Console.WriteLine("잔액 : " + myMoney);
//                        Console.WriteLine("===========================================");
//                        if (myMoney > purchase)
//                        {
//                            myMoney -= purchase;
//                            stockWallet[stockName - 1] += count;
//                            Console.WriteLine("{0}주 구매완료. 잔액:{1}", count, myMoney);
//                            Console.WriteLine("===========================================");
//                        }
//                        else
//                        {
//                            Console.WriteLine("잔액이 부족합니다.");
//                        }

//                        GetStock();


//                    }
//                    else if (menuOption == 2)  // 2 - 매도
//                    {
//                        // 매도할 종목 번호 입력받기
//                        Console.WriteLine("[1]MicroSoft [2]Meta [3]Apple");
//                        int.TryParse(Console.ReadLine(), out int stockName);

//                        // 수량 입력받기
//                        Console.WriteLine("매도할 수량을 입력하세요.");
//                        int.TryParse(Console.ReadLine(), out int count);

//                        // 매도가격 = 주가 * 수량
//                        int sellPrice = (int)stockPrices[menuOption - 1] * count;

//                        // 보유 수량 체크
//                        if (stockWallet[stockName - 1] > count)
//                        {
//                            // 매도 완료 = 보유 금액 변경
//                            myMoney += sellPrice;
//                            stockWallet[menuOption - 1] -= count;
//                            Console.WriteLine("{0}주 매도완료. 잔액: {1}", count, myMoney);
//                        }
//                        else
//                        {
//                            Console.WriteLine("매도 수량이 부족합니다.");
//                        }

//                    }

//                }
//                // [2] 대학교 ==============================================================
//                else if (menuOption == 2)
//                {
//                    Console.WriteLine("============================강의목록============================");
//                    for (int i = 0; i < lectures.Length; i++)
//                    {
//                        Console.WriteLine("[" + (i + 1) + "] " + lectures[i]);
//                    }
//                    Console.WriteLine("================================================================");
//                    Console.WriteLine("[1]수강신청 [2]수강내역보기 [3]학점 계산기");
//                    Console.WriteLine("================================================================");

//                    // 옵션 입력받기
//                    int.TryParse(Console.ReadLine(), out menuOption);

//                    // 1. 수강신청
//                    if (menuOption == 1)
//                    {
//                        Console.Write("과목을 선택하세요 > ");
//                        int.TryParse(Console.ReadLine(), out int lectureOption);

//                        myLectures[lectureOption - 1] = true;
//                        Console.WriteLine("< {0} > 수강신청완료 .", lectures[lectureOption - 1]);
//                        Console.WriteLine("================================================================");
//                    }
//                    // 2. 수강 내역 보기
//                    else if (menuOption == 2)
//                    {
//                        for (int i = 0; i < lectures.Length; i++)
//                        {
//                            if (myLectures[i])
//                            {
//                                Console.WriteLine("- " + lectures[i]);
//                            }
//                        }
//                        Console.WriteLine("================================================================");
//                    }
//                    // 3. 학점 계산기
//                    else if (menuOption == 3)
//                    {
//                        double everageScore = 0;
//                        int lectureCount = 0;
//                        // 강의목록 개수만큼 학점 입력받음 
//                        for (int i = 0; i < myLectures.Length; i++)
//                        {
//                            if (myLectures[i])
//                            {
//                                lectureCount++;
//                                Console.Write("<" + lectures[i] + ">" + "과목의 학점을 입력하세요 > ");
//                                String score = Console.ReadLine();
//                                everageScore += scores[score];
//                            }
//                        }
//                        // 평점계산
//                        everageScore = everageScore / lectureCount;
//                        Console.WriteLine("총평점 : {0}", everageScore);

//                    }

//                }

//            }

//        }
//    }
//}

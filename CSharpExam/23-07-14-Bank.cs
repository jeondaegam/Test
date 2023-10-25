using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExam
{
    internal class Condition
    {
        static int money = 10000;
        static int price = 0;
        static bool isRunning = true;
        static float cash = money;

        // 입금
        public static void deposit()
        {
            Console.WriteLine("입금하실 금액을 입력하세요. 현재잔액: " + money);
            int.TryParse(Console.ReadLine(), out int price);
            money += price;
            cash = money;
            Console.WriteLine("입금완료되었습니다. 현재잔액: " + money);
        }

        // 출금
        public static void withdraw()
        {
            Console.WriteLine("출금하실 금액을 입력하세요. 현재잔액: " + money);
            int.TryParse(Console.ReadLine(), out int price);
            if (price > money)
            {
                Console.WriteLine("잔액이 부족합니다. " + money);
            }
            else
            {
                money -= price;
                cash = money;
                Console.WriteLine("출금완료되었습니다. 현재잔액: " + money);
            }
        }

        public static void Main(string[] args)
        {
            //Bank bank = new Bank();
            //bank.Deposit();

            while (isRunning)
            {
                int option = 0;
                Console.WriteLine("옵션을 선택하세요. [1]: 상점, [2]: 은행 [-1]: 프로그램 종료");
                string str = "";
                int.TryParse(Console.ReadLine(), out option);

                // 프로그램 종료
                if (option == -1)
                {
                    isRunning = false;
                }

                // 1. 상점
                else if (option == 1)
                {
                    //금액 입력받기
                    Console.WriteLine("상품가격을 입력하세요 .");
                    string strPrice = Console.ReadLine();
                    int.TryParse(strPrice, out price);
                    if (price <= 0)
                    {
                        //1. 물건 가격이 0원보다 작음
                        Console.WriteLine("물건금액을 확인하세요. :" + money);
                    }
                    else if (money >= price)
                    {
                        // 2. 정상구매
                        money -= price;
                        cash = money;
                        Console.WriteLine("구매했습니다. 남은잔액: " + money);
                    }
                    else
                    {   // 3. 잔액 부족
                        Console.WriteLine("금액이 부족합니다. 남은잔액: " + money);
                    }
                }
                else
                {
                    int cashOption = 0;
                    Console.WriteLine("[1]입금, [2]출금, [3]이자계산 및 반영");
                    string strCashOptions = Console.ReadLine();
                    int.TryParse(strCashOptions, out cashOption);
                    if (cashOption == 1)
                    {
                        // 1. 입금
                        deposit();
                    }
                    else if (cashOption == 2)
                    {
                        // 2. 출금
                        withdraw();

                    }
                    else if (cashOption == 3)
                    {
                        // 3. 이자계산
                        //단리 = 원금 (1+기간*이율), 복리 = 원금*(1+이율)^기간
                        Console.WriteLine("[1]단리계산, [2]복리계산");
                        int.TryParse(Console.ReadLine(), out cashOption);

                        Console.WriteLine("기간을 입력하세요(단위:일)");
                        int date = 0;
                        int.TryParse(Console.ReadLine(), out date);

                        Console.WriteLine("이자율을 입력하세요.");
                        float interestRate = 0;
                        float.TryParse(Console.ReadLine(), out interestRate);

                        if (cashOption == 1)
                        {
                            //1. 단리 = 원금 (1+기간*이율)
                            cash = cash * (1 + date * interestRate);
                        }
                        else
                        {
                            // 2. 복리 = 원금*(1+이율)^기간
                            float addCash = cash * (1 + interestRate);
                            for (int i = 0; i < date; i++)
                            {
                                cash += cash * addCash;
                            }

                        }
                        Console.WriteLine("이자가 반영되었습니다. 잔액: " + money);

                    }

                }




            }


        }
    }
}

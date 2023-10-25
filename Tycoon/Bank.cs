using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExam
{
    public class Bank
    {
        private int myMoney; // 소지금
        private String name; // 사용자 이름
        private float cash; // 


        public Bank(int myMoney, String name)
        {
            this.myMoney = myMoney;
            this.name = name;
            this.cash = myMoney;
        }


        // 출금
        //public void Withdraw(int x)
        //{
        //    string A = "돈이 부족해서 인출할 수 없습니다.";
        //    string C = myMoney.ToString();
        //    string B = A + myMoney; // 자동으로 string으로 형변환 해줌

        //    if (myMoney < x || x <= 0)
        //    {
        //        Console.WriteLine($"인출할 수 없습니다. {myMoney}");
        //        return;
        //    }
        //    myMoney = myMoney - x;
        //}

        // 리턴값 여러개 받기 - out 
        //public void div(int a, int b, out int result, out int result2)
        //{
        //    result = a / b;
        //    result2 = a % b;
        //}

        // Tuple
        //public (String name, int age, String grade) MultiReturn()
        //{
        //    String name = "yeoreum";
        //    int age = 2;
        //    String grade = "A";
        //    return (name, age, grade);
        //}


        // 은행 메인 화면
        internal int ShowStatus()
        {
            Console.Write("[1]입금, [2]출금, [3]이자계산 및 반영\n>");
            int.TryParse(Console.ReadLine(), out int option);
            DrawLine();
            return option;
        }


        // 1. 입급
        internal void Deposit()
        {
            Console.Write("입금하실 금액을 입력하세요.\n현재잔액: " + myMoney + "\n>");
            int.TryParse(Console.ReadLine(), out int depositMoney);
            DrawLine();

            if (depositMoney < 0) return;

            myMoney += depositMoney;
            Console.WriteLine("입금완료되었습니다. \n현재잔액: " + myMoney);
            DrawLine();
        }


        // 2. 출금
        internal void Withdraw()
        {
            Console.Write("출금하실 금액을 입력하세요.\n현재잔액: " + myMoney + "\n>");
            int.TryParse(Console.ReadLine(), out int withdrawMoney);
            DrawLine();

            if (myMoney > withdrawMoney)
            {
                myMoney -= withdrawMoney;
                Console.WriteLine("출금완료되었습니다.\n현재잔액: " + myMoney);
                DrawLine();
            }
            else
            {
                Console.WriteLine("잔액이 부족합니다. " + myMoney);
            }
        }


        // 3. 이자 계산 메뉴 - 단리 or 복리
        internal int ShowInterestMenu()
        {
            Console.WriteLine("[1]단리계산, [2]복리계산");
            int.TryParse(Console.ReadLine(), out int menuOption);
            return menuOption;
        }


        // 3-1. 단리 계산
        internal void AddSimpleInterest(int date, float interestRate)
        {
            // 일단위 이자계산 : 원금x연이율x일수/365.
            //myMoney = (int)(myMoney * (1 + date * interestRate));
            // 단리
            float interest = (myMoney * interestRate * date / 365);
            // 원금에 단리 적용
            myMoney += (int)interest;
            Console.WriteLine("단리 <{0}원> 적용이 완료되었습니다." +
                "\n현재잔액: {1}",interest, myMoney);
            DrawLine();
        }


        // 3-2. 복리계산
        internal void CompoundInterest(int date, float interestRate)
        {
            // 투자원금 * (1 + 이자율)^기간
            float addCash = myMoney * (1 + interestRate);
            float sum = 0;
            for (int i = 0; i < date; i++)
            {
                sum += myMoney * addCash;
            }
            myMoney = (int)sum;
            Console.WriteLine("복리 적용이 완료되었습니다.\n현재잔액: " + myMoney);
            DrawLine();
        }


        // 이자 계산 - 기간 입력받기
        internal int GetDate()
        {
            Console.WriteLine("기간을 입력하세요(단위:일)");
            int.TryParse(Console.ReadLine(), out int date);
            return date;
        }


        // 이자 계산 - 이자율 입력받기
        internal float GetInterestRate()
        {
            Console.WriteLine("이자율을 입력하세요.");
            float.TryParse(Console.ReadLine(), out float interestRate);
            DrawLine();
            return interestRate;
        }

        private void DrawLine()
        {
            Console.WriteLine("=====================================");
        }

        internal void WelcomeBank()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tycoon
{
    internal class Stock
    {
        //int.TryParse(Console.ReadLine(), out int menuOption);

        private double myMoney = 100000; // 보유잔액
        private int selectedOption = 0; // 메뉴 선택 옵션
        private string[] stockNames = { "MS", "Meta", "Apple" };
        private int[] stockWallet = { 0, 0, 0 }; // 주식 보유 수량
        private double[] stockPrices = { 10000, 10000, 10000 };  // 상승률이 적용된 주가
        int[] randomPercent = new int[3];
        Random random;



        // 주식변동폭
        public int ViewStockList()
        {
            // 주가 상승률적용
            for (int i = 0; i < stockPrices.Length; i++)
            {
                // 변동폭
                randomPercent[i] = random.Next(-50, 101);
                // 주가에 변동폭 적용
                stockPrices[i] = stockPrices[i] + (stockPrices[i] * randomPercent[i] / 100f);
            }

            Console.WriteLine("===========================================");
            Console.WriteLine("이름       주가       변동폭       보유수량");
            Console.WriteLine("===========================================");
            for (int j = 0; j < stockNames.Length; j++)
            {
                Console.WriteLine("{0}       {1}         {2}%          {3}", stockNames[j], stockPrices[j], randomPercent[j], stockWallet[j]);
            }
            Console.WriteLine("===========================================");
            Console.WriteLine("MyMoney : {0}", myMoney);

            Console.WriteLine("[1]매수 [2]매도");
            int.TryParse(Console.ReadLine(), out int selectedOption);

            return selectedOption;
        }


        public void GetRandomPercent()
        {

        }




    }
}

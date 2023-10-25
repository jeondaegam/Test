using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tycoon
{
    internal class Market
    {
        private int myMoney;
        private Dictionary<String, int> itemList = new Dictionary<string, int>();

        public Market(int money)
        {
            myMoney = money;
            itemList.Add("itemA", 2800);
            itemList.Add("itemB", 59000);
            itemList.Add("itemC", 400);
            itemList.Add("itemD", 8900);

        }


        // 1. 상품 리스트 출력
        public void ShowMarket()
        {
            DrawLine();
            //foreach(KeyValuePair<String, int> item in itemList)
            //{
            //    Console.WriteLine("-" + item.Key);
            //}
            // ElementAt - Dictionary 요소를 가져온다
            for (int i = 0; i < itemList.Count; i++)
            {
                KeyValuePair<String, int> entry = itemList.ElementAt(i);
                Console.WriteLine("-[{0}] {1}", i + 1, entry.Value);
            }
            DrawLine();
            Console.WriteLine("[1]구매");
        }
        // 2. 상품 구매
        public void Purchase()
        {
            //
        }
        

        private void DrawLine()
        {
            Console.WriteLine("=====================================");
        }

    }
}

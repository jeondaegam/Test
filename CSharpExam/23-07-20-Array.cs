using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExam
{
    internal class _23_07_20
    {
        public static void Main(string[] args)
        {
            int number = 1;
            float[] array2 = { 1, 2, 3 };
            //array2 = {1,2,3}; // {} 중괄호를 사용하는 건 초기화이므로 최초 1번만 가능  
            int[] nums = new int[2];

            Console.WriteLine(number);
            Console.WriteLine(array2[0]);
            Console.WriteLine(array2[number]);

            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine(array2[i]);
            }

            //배열로 입력받기 
            int.TryParse(Console.ReadLine(), out nums[0]);
            Console.WriteLine(nums[0]);


        }


    }
}

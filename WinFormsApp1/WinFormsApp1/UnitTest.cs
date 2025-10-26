using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1 
{
    public class UnitTest 
    {
        public static void Test1()
        {
            List<int> list = new List<int>()
            {
                11, 8, 21, 7, 5, 12, 21, 17
            };

            Dump(list);
            Dump(MyQuickSort(list));
        } 

        public static void Test()
        {
            List<int> list = new List<int>()
            {
                11, 8, 21, 7, 5, 12, 21, 17
            };

            Dump(list);
            Dump(MyQuickSort(list));
        } 

        public static void Test3()
        {
            List<int> list = new List<int>()
            {
                11, 8, 21, 7, 5, 12, 21, 17
            };

            Dump(list);
            Dump(MyQuickSort(list));
        } 

        public static void Test4()
        {
            List<int> list = new List<int>()
            {
                11, 8, 21, 7, 5, 12, 21, 17
            };

            Dump(list);
            Dump(MyQuickSort(list));
        } 

        public static void Test5()
        {
            List<int> list = new List<int>()
            {
                11, 8, 21, 7, 5, 12, 21, 17
            };

            Dump(list);
            Dump(MyQuickSort(list));
        } 

        static void Dump(List<int> list)
        {
            string dumpStr = "[";

            for(int i = 0; i < list.Count; i++)    
            {
                dumpStr += list[i].ToString();
                if(i < list.Count - 1) dumpStr += ", ";
            }

            dumpStr += "]";
            Console.WriteLine(dumpStr);
        }

        static List<int> MyQuickSort(List<int> list) 
        {
            if(list.Count <= 1) return list;

            List<int> rightList  = new List<int>();
            List<int> leftList   = new List<int>();
            int       pivot      = list[0];

            for(int i = 1; i < list.Count; i++)
            {
                if (list[i] <= pivot)
                {
                    leftList.Add(list[i]);    
                }
                else
                {
                    rightList.Add(list[i]);
                }
            }

            List<int> sortedRight = MyQuickSort(rightList);
            List<int> sortedLeft  = MyQuickSort(leftList);
            List<int> sortedList  = new List<int>();             

            foreach(int i in sortedLeft)
            {
                sortedList.Add(i);
            }

            sortedList.Add(pivot);

            foreach(int i in sortedRight)
            {
                sortedList.Add(i);
            }

            return sortedList;
        }
    }
}

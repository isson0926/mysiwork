using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {

    internal class Program 
    {
        #region 
        static void Main(string[] args) 
        {
            List<Tuple<string, string>> cols = CreateCols       
            (
                "col1", "val1"
               ,"col2", "val2"
               ,"col3", "val3"
               ,"col4", "val4"
            );

            for(int i = 0; i < cols.Count; i++)
            {
                string col_1 = cols[i].Item1;
                string col_2 = cols[i].Item2;

                Console.WriteLine(col_1 + " : " + col_2);
            }
        }
        #endregion

       public static List<Tuple<string, string>> CreateCols(params string[] columns)
       {
           var result = new List<Tuple<string, string>>();

           for (int i = 0; i < columns.Length - 1; i += 2)
           {
               result.Add(Tuple.Create(columns[i], columns[i + 1]));
           }

           return result;
       }
    }
}

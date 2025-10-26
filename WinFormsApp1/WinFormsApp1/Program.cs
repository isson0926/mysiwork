namespace WinFormsApp1
{
    internal static class Program
    {
		static void RunWinForm() 
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
		}

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            RunWinForm();
        }

        #region test ok
        static void Dump(List<int> list)
        {
            string dumpStr = "[";

            // test    
            for(int i = 0; i < list.Count; i++)    
            {
                dumpStr += list[i].ToString();
                if(i < list.Count - 1) dumpStr += ", ";
            }

            dumpStr += "]";
            Console.WriteLine(dumpStr);
        }
        #endregion

        static void RunUnitTest() {
		}
    }
}

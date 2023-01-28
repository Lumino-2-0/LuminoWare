/*





db        db    db   .88b  d88.   d888888b   d8b   db    .d88b.             d8888b.    .d8b.    d8b   db   .d8888.    .d88b.    .88b  d88. 
88        88    88   88'YbdP`88     `88'     888o  88   .8P  Y8.            88  `8D   d8' `8b   888o  88   88'  YP   .8P  Y8.   88'YbdP`88 
88        88    88   88  88  88      88      88V8o 88   88    88            88oobY'   88ooo88   88V8o 88   `8bo.     88    88   88  88  88 
88        88    88   88  88  88      88      88 V8o88   88    88   C8888D   88`8b     88~~~88   88 V8o88     `Y8b.   88    88   88  88  88 
88booo.   88b  d88   88  88  88     .88.     88  V888   `8b  d8'            88 `88.   88   88   88  V888   db   8D   `8b  d8'   88  88  88 
Y88888P   ~Y8888P'   YP  YP  YP   Y888888P   VP   V8P    `Y88P'             88   YD   YP   YP   VP   V8P   `8888Y'    `Y88P'    YP  YP  YP 
     __ __             __     
    /\ \\ \          /'__`\   
    \ \ \\ \        /\ \/\ \  
     \ \ \\ \_      \ \ \ \ \ 
      \ \__ ,__\ __  \ \ \_\ \
       \/_/\_\_//\_\  \ \____/
          \/_/  \/_/   \/___/ 
                                  




*/
using System;
using System.Windows.Forms;


namespace Lumino_ransom
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]



        static void Main()
        {
            try
            {
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (System.UnauthorizedAccessException) { }

        }

    }
}

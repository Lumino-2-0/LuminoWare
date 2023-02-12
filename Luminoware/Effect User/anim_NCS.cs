/*
    


    _                    _            _       _           _           _  _  _           _           _          _  _  _  _                                                   _  _  _  _                 _              _           _          _  _  _  _           _  _  _  _         _           _    
   (_)                  (_)          (_)     (_) _     _ (_)         (_)(_)(_)         (_) _       (_)       _(_)(_)(_)(_)_                                                (_)(_)(_)(_) _            _(_)_           (_) _       (_)       _(_)(_)(_)(_)_       _(_)(_)(_)(_)_      (_) _     _ (_)   
   (_)                  (_)          (_)     (_)(_)   (_)(_)            (_)            (_)(_)_     (_)      (_)          (_)                                               (_)         (_)         _(_) (_)_         (_)(_)_     (_)      (_)          (_)     (_)          (_)     (_)(_)   (_)(_)   
   (_)                  (_)          (_)     (_) (_)_(_) (_)            (_)            (_)  (_)_   (_)      (_)          (_)                                               (_) _  _  _ (_)       _(_)     (_)_       (_)  (_)_   (_)      (_)_  _  _  _        (_)          (_)     (_) (_)_(_) (_)   
   (_)                  (_)          (_)     (_)   (_)   (_)            (_)            (_)    (_)_ (_)      (_)          (_)                                               (_)(_)(_)(_)         (_) _  _  _ (_)      (_)    (_)_ (_)        (_)(_)(_)(_)_      (_)          (_)     (_)   (_)   (_)   
   (_)                  (_)          (_)     (_)         (_)            (_)            (_)      (_)(_)      (_)          (_)                                               (_)   (_) _          (_)(_)(_)(_)(_)      (_)      (_)(_)       _           (_)     (_)          (_)     (_)         (_)   
   (_) _  _  _  _       (_)_  _  _  _(_)     (_)         (_)          _ (_) _          (_)         (_)      (_)_  _  _  _(_)                                               (_)      (_) _       (_)         (_)      (_)         (_)      (_)_  _  _  _(_)     (_)_  _  _  _(_)     (_)         (_)   
   (_)(_)(_)(_)(_)        (_)(_)(_)(_)       (_)         (_)         (_)(_)(_)         (_)         (_)        (_)(_)(_)(_)                                                 (_)         (_)      (_)         (_)      (_)         (_)        (_)(_)(_)(_)         (_)(_)(_)(_)       (_)         (_)   
     __ __             __     
    /\ \\ \          /'__`\   
    \ \ \\ \        /\ \/\ \  
     \ \ \\ \_      \ \ \ \ \ 
      \ \__ ,__\ __  \ \ \_\ \
       \/_/\_\_//\_\  \ \____/
          \/_/  \/_/   \/___/ 




                                                                                                                                                                                                                                                                                             
*/
//                                 /*\|---------------------------------------------------------------------------------------------------------------|\*/
using System;                      /*\|                                     Librairie de base (System + Windows.Forms)                                |\*/
using System.Windows.Forms;        /*\|                                                                                                               |\*/
//                                 /*\|---------------------------------------------------------------------------------------------------------------|\*/


// Namespace animANDNCS
namespace animANDNCS
{
    // Classe Anim_NCS
    internal class Anim_NCS
    {
        
        public void Del_NCS_Ani() // Fonction qui va faire l'animation avec les Del/Leds Numlock-Capslock-Scroll (NCS)
        {
            SendKeys.Send("{NUMLOCK}");                                 /*\----------------------------------------------------------------------------------------------------\*/
            Console.Beep(125, 200);                                    /*\                                                                                                      \*/
            SendKeys.Send("{NUMLOCK}");                               /*\           L'animation N°1 fait les instructions suivantes :                                            \*/
            System.Threading.Thread.Sleep(500);                      /*\                                                                                                          \*/
            SendKeys.Send("{CAPSLOCK}");                            /*\            1: Allume le Numlock, le Capslock et le Scrolllock pendant 200ms puis s'éteignent               \*/
            Console.Beep(500, 200);                                /*\             1Bis: Pour chaque Del/Led, il y a un bip de 200ms de plus en plus aigu (125Hz, 500Hz, 1000Hz) .  \*/
            SendKeys.Send("{CAPSLOCK}");                          /*\                                                                                                                \*/
            System.Threading.Thread.Sleep(500);                  /*\               2: Il fait le contraire : les Dels s'allume à l'envers : Scrool, Capslock et Numlock               \*/
            SendKeys.Send("{SCROLLLOCK}");                      /*\                2Bis: Pour chaque Del/Led, il y a un bip de 200ms de plus en plus grave (1000Hz, 500Hz, 125Hz).     \*/
            Console.Beep(1000, 200);                           /*\                                                                                                                      \*/
            SendKeys.Send("{SCROLLLOCK}");                    /*\                  3: Pour finir, il répète ses actions à l'opposer                                                      \*/
            //##################################             /*\                                                                                                                          \*/
            System.Threading.Thread.Sleep(1000);            /*\                                                                                                                           \*/
            SendKeys.Send("{SCROLLLOCK}");                  /*\                                                                                                                           \*/
            Console.Beep(1000, 200);                         /*\                                                                                                                         \*/
            SendKeys.Send("{SCROLLLOCK}");                    /*\                    INFO : Si vous n'avez pas compris, tester juste l'animation, c'est plus facile ;)                  \*/
            System.Threading.Thread.Sleep(500);                /*\                                                                                                                     \*/
            SendKeys.Send("{CAPSLOCK}");                        /*\___________________________________________________________________________________________________________________\*/
            Console.Beep(500, 200);
            SendKeys.Send("{CAPSLOCK}");
            System.Threading.Thread.Sleep(500);
            SendKeys.Send("{NUMLOCK}");
            Console.Beep(125, 200);
            SendKeys.Send("{NUMLOCK}");
            //##################################
            System.Threading.Thread.Sleep(2000);
            SendKeys.Send("{SCROLLLOCK}");
            Console.Beep(1000, 200);
            SendKeys.Send("{SCROLLLOCK}");
            System.Threading.Thread.Sleep(500);
            SendKeys.Send("{CAPSLOCK}");
            Console.Beep(500, 200);
            SendKeys.Send("{CAPSLOCK}");
            System.Threading.Thread.Sleep(500);
            SendKeys.Send("{NUMLOCK}");
            Console.Beep(125, 200);
            SendKeys.Send("{NUMLOCK}");
            //##################################
            System.Threading.Thread.Sleep(1000);
            SendKeys.Send("{NUMLOCK}");
            Console.Beep(125, 200);
            SendKeys.Send("{NUMLOCK}");
            System.Threading.Thread.Sleep(500);
            SendKeys.Send("{CAPSLOCK}");
            Console.Beep(500, 200);
            SendKeys.Send("{CAPSLOCK}");
            System.Threading.Thread.Sleep(500);
            SendKeys.Send("{SCROLLLOCK}");
            Console.Beep(1000, 200);
            SendKeys.Send("{SCROLLLOCK}");
        }
        
        

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        
        public void Del_NCS_Ani2() // Fonction qui va faire la même animation que la N°1 mais plus rapidement
        {
            SendKeys.Send("{NUMLOCK}");                     /*\----------------------------------------------------------------------------------------------------\*/
            Console.Beep(125, 200);                         /*\                                                                                                    \*/
            SendKeys.Send("{NUMLOCK}");                     /*\                     L'animation N°2 est juste plus rapide que la N°1.                              \*/
            System.Threading.Thread.Sleep(100);             /*\                                                                                                    \*/
            SendKeys.Send("{CAPSLOCK}");                    /*\----------------------------------------------------------------------------------------------------\*/
            Console.Beep(500, 200);
            SendKeys.Send("{CAPSLOCK}");
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("{SCROLLLOCK}");
            Console.Beep(1000, 200);
            SendKeys.Send("{SCROLLLOCK}");
            System.Threading.Thread.Sleep(500);
            SendKeys.Send("{SCROLLLOCK}");
            Console.Beep(1000, 200);
            SendKeys.Send("{SCROLLLOCK}");
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("{CAPSLOCK}");
            Console.Beep(500, 200);
            SendKeys.Send("{CAPSLOCK}");
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("{NUMLOCK}");
            Console.Beep(125, 200);
            SendKeys.Send("{NUMLOCK}");
            System.Threading.Thread.Sleep(500);
            SendKeys.Send("{SCROLLLOCK}");
            Console.Beep(1000, 200);
            SendKeys.Send("{SCROLLLOCK}");
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("{CAPSLOCK}");
            Console.Beep(500, 200);
            SendKeys.Send("{CAPSLOCK}");
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("{NUMLOCK}");
            Console.Beep(125, 200);
            SendKeys.Send("{NUMLOCK}");
            System.Threading.Thread.Sleep(500);
            SendKeys.Send("{NUMLOCK}");
            Console.Beep(125, 200);
            SendKeys.Send("{NUMLOCK}");
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("{CAPSLOCK}");
            Console.Beep(500, 200);
            SendKeys.Send("{CAPSLOCK}");
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("{SCROLLLOCK}");
            Console.Beep(1000, 200);
            SendKeys.Send("{SCROLLLOCK}");
        }


    }
}

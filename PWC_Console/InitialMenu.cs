using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PWC_Console
{
    public class InitialMenu
    {
        private readonly IFinalMenu _finalMenu;

        public InitialMenu(IFinalMenu finalMenu)
        {
            _finalMenu = finalMenu;
        }

        public void ManageMenu()
        {
            Display();                                                                              // affiche les options 
            var reponse = Console.ReadLine().ToUpper();

            while (!reponse.ToUpper().Equals("Q"))
            {
                if (reponse.ToUpper().Equals("C"))
                {
                    LaunchFinalmenu();
                }
                Display();
                reponse = Console.ReadLine();
            }
            Quit();
        }


        #region manageMenuMethods
        public void Display()
        {
            Console.WriteLine("Voulez-vous effectuer des calculs ou quitter l’application ? ");
            Console.WriteLine("Veuillez entrer 'C' pour les calculs ou 'Q' pour quitter");
        }

        public void Quit()
        {
            Console.WriteLine("Merci et à bientôt.");
            Thread.Sleep(4000);
            Environment.Exit(0);
        }

        public void LaunchFinalmenu()
        {
            _finalMenu.Manage();
        }

        #endregion manageMenuMethods
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWC_Console
{
    public class FinalMenu : IFinalMenu
    {
        private readonly IFinalMenuService _finalMenuService;

        public FinalMenu(IFinalMenuService finalMenuService)
        {
            _finalMenuService = finalMenuService;
        }

        public void Manage()
        {
            Display();
            var reponse = Console.ReadLine().ToUpper();

            while (!reponse.ToUpper().Equals("P"))
            {
                switch (reponse)
                {
                    case "LINQ":
                        _finalMenuService.Linq();
                        break;
                    case "LAMBDA":
                        Console.WriteLine(reponse);
                        break;
                    case "SQL":
                        _finalMenuService.Sql();
                        break;
                    case "FIBO":
                        _finalMenuService.Fibo();
                        break;
                }
                Display();
                reponse = Console.ReadLine().ToUpper();
            }
        }

        public void Display()
        {
            Console.WriteLine("Merci de sélectionner l'une des cinq options");
            Console.WriteLine("Linq     => affichage de propriétaire de compte et montant total des comptes");
            Console.WriteLine("Lambda   => affichage de propriétaire de compte et le nombre de comptes");
            Console.WriteLine("Sql      => affichage des status des écritures");
            Console.WriteLine("Fibo     => affichage si une valeur est dans la suite de Fibonacci");
            Console.WriteLine("P        => retour au choix précédent");
        }
    }
}

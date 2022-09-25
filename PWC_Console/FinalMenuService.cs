using Microsoft.Data.Sqlite;
using PWC_Console.Model;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PWC_Console
{
    public class FinalMenuService : IFinalMenuService
    {
        private readonly PWCContext _pWcContext;

        public FinalMenuService(PWCContext pWcContext)
        {
            _pWcContext = pWcContext;
        }

        PWCContext context = new PWCContext();

        public void Fibo()
        {
            Console.WriteLine("Veuillez entrer une valeur pour effectuer un test de Fibonacci.");

            try
            {

                var choix = int.Parse(Console.ReadLine());

                int a = 0, b = 1, c = 0;

                while (c < choix)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
                Console.WriteLine();
                Console.WriteLine();
                if (c == choix)
                    Console.WriteLine($"Votre nombre {choix} appartient à la suite de Fibonacci");
                else
                    Console.WriteLine($"Votre nombre {choix} n'appartient pas à la suite de Fibonacci");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                if (e.Message.Equals("Value was either too large or too small for an Int32."))
                {
                    Console.WriteLine("Le nombre saisi ne peut dépasser 2 147 483 647");
                    Console.WriteLine();
                }
                else if (e.Message.Equals("Input string was not in a correct format."))
                {
                    Console.WriteLine("Le nombre saisi n'est pas au bon format");
                    Console.WriteLine();
                }
                else
                {
                    throw;
                }
            }
        }

        public void Lamba()
        {
            Console.WriteLine("Lambda : En Lambda Expression écrire pour chaque écriture son nom et le nombre de comptes qu’elle impacte");
        }

        public void Linq()
        {
            var test = context.Ledger;
        }

        public void P()
        {
            Console.WriteLine("P : Retour aux choix précédents");
        }

        public void Sql()
        {
            using (var connection = new SqliteConnection("Data Source=BaseTest.db"))
            {
                Batteries.Init();
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"SELECT 
    EntryId,
    Entry.Name,
    Sum(Amount) Total,
    CASE WHEN Sum(Amount) < 0 THEN 'KO.D'
         WHEN Sum(Amount) > 0 THEN 'KO.U'
    ELSE 'OK' END as Statut
FROM
    Ledger
    inner join Entry on
        Ledger.EntryId = Entry.Id
Group By
    Ledger.EntryId";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entryId = reader.GetString(0);
                        var entryName = reader.GetString(1);
                        var total = reader.GetString(2);
                        var status = reader.GetString(3);
                        Console.WriteLine($"écriture {entryName} : {status} ({total})");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
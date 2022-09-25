using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PWC_Console.Model;

namespace PWC_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IHost host = BuildConfig(args);

            // initialisation du initialmenu pour acceder à toutes les autres ID
            var initialMenu = ActivatorUtilities.CreateInstance<InitialMenu>(host.Services);

            StartPWC(initialMenu);
        }

        /// <summary>
        /// creation des injections de dependances
        /// </summary
        private static IHost BuildConfig(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<IFinalMenuService, FinalMenuService>()
                            .AddTransient<IFinalMenu, FinalMenu>()
                            .AddTransient<InitialMenu>()
                            .AddDbContext<PWCContext>()
                        ).Build();

            return host;
        }

        /// <summary>
        /// lancement du menu de base
        /// </summary>
        public static void StartPWC(InitialMenu initialMenu)
        {
            initialMenu.ManageMenu();
        }
    }
}

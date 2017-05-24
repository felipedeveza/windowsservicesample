using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            // Verifica se o usuário passou parametros.
            if (Environment.UserInteractive)
            {
                var parametro = string.Concat(args);
                switch (parametro)
                {
                    // Caso o parametro seja "--install", instala o serviço.
                    case "--install":
                        ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });
                        return;

                    // Caso o parametro seja "--unistall", desinstala o serviço.
                    case "--uninstall":
                        ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
                        return;
                }
            }

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Scheduler() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}

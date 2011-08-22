﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VDS.RDF.Utilities.Data.Sql.Clients.Cmd
{
    class Program
    {
        private static Dictionary<String, ManagementAction> _modes = new Dictionary<string, ManagementAction>();

        static void Main(string[] args)
        {
            try
            {
                //Load the available modes
                Type target = typeof(ManagementAction);
                foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (target.IsAssignableFrom(t) && !target.Equals(t))
                    {
                        ManagementAction action = Activator.CreateInstance(t) as ManagementAction;
                        if (action != null)
                        {
                            _modes.Add(action.Name, action);
                        }
                    }
                }

                if (args.Length == 0)
                {
                    ShowUsage();
                }
                else
                {
                    String mode = args[0];

                    if (_modes.ContainsKey(mode))
                    {
                        ManagementAction action = _modes[mode];
                        if (args.Length - 1 >= action.MinimumArguments)
                        {
                            action.Run(args);
                        }
                        else
                        {
                            Console.Error.WriteLine("Too few arguments for '" + action.Name + "' mode, see following usage message for details...");
                            action.ShowUsage();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unexpected Error");
                do {
                    Console.Error.WriteLine(ex.Message);
                    Console.Error.WriteLine(ex.StackTrace);
                    ex = ex.InnerException;
                } while (ex != null);
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine("rdfSqlStorages");
            Console.WriteLine("=============");
            Console.WriteLine();
            Console.WriteLine("Provides command line management of SQL based stores supported by dotNetRDF");
            Console.WriteLine();
            Console.WriteLine("Usage is rdfSqlStorage mode [options]");
            Console.WriteLine();
            Console.WriteLine("Available Modes");
            Console.WriteLine("---------------");
            Console.WriteLine();
            foreach (ManagementAction action in _modes.Values)
            {
                Console.WriteLine(action.Name + " " + action.Description);
            }
            Console.WriteLine();
            Console.WriteLine("To see options for a specific mode type rdfSqlStorage mode -help");
        }
    }
}

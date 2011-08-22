﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDS.RDF.Utilities.Data.Sql.Clients.Cmd
{
    public abstract class ManagementAction
    {
        public ManagementAction(String name, String descrip)
        {
            this.Name = name;
            this.Description = descrip;
        }

        public ManagementAction(String name)
            : this(name, String.Empty) { }

        public String Name
        {
            get;
            private set;
        }

        public String Description
        {
            get;
            private set;
        }

        public abstract int MinimumArguments
        {
            get;
        }

        public abstract void ShowUsage();

        public abstract void Run(String[] args);
    }
}

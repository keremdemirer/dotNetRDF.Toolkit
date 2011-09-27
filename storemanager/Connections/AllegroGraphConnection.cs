﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDS.RDF.Utilities.StoreManager.Connections
{
    public class AllegroGraphConnectionDefinition
        : BaseServerConnectionDefinition
    {
        public AllegroGraphConnectionDefinition()
            : base("Allegro Graph", "Connect to Franz AllegroGraph, Version 3.x and 4.x are supported") { }

        [Connection(DisplayName="Catalog ID", AllowEmptyString=true, IsRequired=true, Type=ConnectionSettingType.String, NotRequiredIf="UseRootCatalog")]
        public String CatalogID
        {
            get;
            set;
        }

        [Connection(DisplayName="Use Root Catalog", Type=ConnectionSettingType.Boolean)]
        public bool UseRootCatalog
        {
            get;
            set;
        }

        [Connection(DisplayName="Store ID", AllowEmptyString=false, IsRequired=true, Type=ConnectionSettingType.String)]
        public String StoreID
        {
            get;
            set;
        }

        [Connection(DisplayName="Username", IsRequired=false, Type=ConnectionSettingType.String)]
        public String Username
        {
            get;
            set;
        }

        [Connection(DisplayName="Password", IsRequired=false, Type=ConnectionSettingType.Password)]
        public String Password
        {
            get;
            set;
        }

        protected override VDS.RDF.Storage.IGenericIOManager OpenConnectionInternal()
        {
            throw new NotImplementedException();
        }
    }
}

﻿
using System;
using System.Configuration;

namespace SoftvConfiguration
{
    public class EncuestaElement : ConfigurationElement
    {
        /// <summary>
        /// Gets assembly name for Encuesta class
        /// </summary>
        [ConfigurationProperty("Assembly")]
        public String Assembly
        {
            get
            {
                string assembly = (string)base["Assembly"];
                assembly = String.IsNullOrEmpty(assembly) ?
                SoftvSettings.Settings.Assembly :
                (string)base["Assembly"];
                return assembly;
            }
        }

        /// <summary>
        /// Gets class name for Encuesta
        ///</summary>
        [ConfigurationProperty("DataClassEncuesta", DefaultValue = "Softv.DAO.EncuestaData")]
        public String DataClass
        {
            get { return (string)base["DataClassEncuesta"]; }
        }

        /// <summary>
        /// Gets connection string for database Encuesta access
        ///</summary>
        [ConfigurationProperty("ConnectionString")]
        public String ConnectionString
        {
            get
            {
                string connectionString = (string)base["ConnectionString"];
                connectionString = String.IsNullOrEmpty(connectionString) ? SoftvSettings.Settings.ConnectionString : (string)base["ConnectionString"];
                return connectionString;
            }
        }
    }
}


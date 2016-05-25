﻿
using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Remoting;
using Softv.Entities;
using SoftvConfiguration;
using Globals;

namespace Softv.Providers
{
    /// <summary>
    /// Class                   : Softv.Providers.COLONIAProvider
    /// Generated by            : Class Generator (c) 2014
    /// Description             : COLONIA Provider
    /// File                    : COLONIAProvider.cs
    /// Creation date           : 20/05/2016
    /// Creation time           : 06:40 p. m.
    /// </summary>
    public abstract class COLONIAProvider : Globals.DataAccess
    {

        /// <summary>
        /// Instance of COLONIA from DB
        /// </summary>
        private static COLONIAProvider _Instance = null;

        private static ObjectHandle obj;
        /// <summary>
        /// Generates a COLONIA instance
        /// </summary>
        public static COLONIAProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    obj = Activator.CreateInstance(
                    SoftvSettings.Settings.COLONIA.Assembly,
                    SoftvSettings.Settings.COLONIA.DataClass);
                    _Instance = (COLONIAProvider)obj.Unwrap();
                }
                return _Instance;
            }
        }

        /// <summary>
        /// Provider's default constructor
        /// </summary>
        public COLONIAProvider()
        {
        }
        /// <summary>
        /// Abstract method to add COLONIA
        ///  /summary>
        /// <param name="COLONIA"></param>
        /// <returns></returns>
        public abstract int AddCOLONIA(COLONIAEntity entity_COLONIA);

        /// <summary>
        /// Abstract method to delete COLONIA
        /// </summary>
        public abstract int DeleteCOLONIA(int? Clv_Colonia);

        /// <summary>
        /// Abstract method to update COLONIA
        /// </summary>
        public abstract int EditCOLONIA(COLONIAEntity entity_COLONIA);

        /// <summary>
        /// Abstract method to get all COLONIA
        /// </summary>
        public abstract List<COLONIAEntity> GetCOLONIA();

        /// <summary>
        /// Abstract method to get all COLONIA List<int> lid
        /// </summary>
        public abstract List<COLONIAEntity> GetCOLONIA(List<int> lid);

        /// <summary>
        /// Abstract method to get by id
        /// </summary>
        public abstract COLONIAEntity GetCOLONIAById(int? Clv_Colonia);


        public abstract List<COLONIAEntity> GetCOLONIAByIdColonia(int? Clv_Colonia);


        public abstract List<COLONIAEntity> GetCOLONIAByClv_Colonia(int? Clv_Colonia);



        /// <summary>
        ///Get COLONIA
        ///</summary>
        public abstract SoftvList<COLONIAEntity> GetPagedList(int pageIndex, int pageSize);

        /// <summary>
        ///Get COLONIA
        ///</summary>
        public abstract SoftvList<COLONIAEntity> GetPagedList(int pageIndex, int pageSize, String xml);

        /// <summary>
        /// Converts data from reader to entity
        /// </summary>
        protected virtual COLONIAEntity GetCOLONIAFromReader(IDataReader reader)
        {
            COLONIAEntity entity_COLONIA = null;
            try
            {
                entity_COLONIA = new COLONIAEntity();
                entity_COLONIA.Clv_Colonia = (int?)(GetFromReader(reader, "Clv_Colonia"));
                entity_COLONIA.Nombre = (String)(GetFromReader(reader, "Nombre", IsString: true));

            }
            catch (Exception ex)
            {
                throw new Exception("Error converting COLONIA data to entity", ex);
            }
            return entity_COLONIA;
        }

    }

    #region Customs Methods

    #endregion
}

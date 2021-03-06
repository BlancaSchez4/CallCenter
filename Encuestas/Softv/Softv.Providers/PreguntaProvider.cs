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
    /// Class                   : Softv.Providers.PreguntaProvider
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Pregunta Provider
    /// File                    : PreguntaProvider.cs
    /// Creation date           : 27/04/2016
    /// Creation time           : 05:16 p. m.
    /// </summary>
    public abstract class PreguntaProvider : Globals.DataAccess
    {

        /// <summary>
        /// Instance of Pregunta from DB
        /// </summary>
        private static PreguntaProvider _Instance = null;

        private static ObjectHandle obj;
        /// <summary>
        /// Generates a Pregunta instance
        /// </summary>
        public static PreguntaProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    obj = Activator.CreateInstance(
                    SoftvSettings.Settings.Pregunta.Assembly,
                    SoftvSettings.Settings.Pregunta.DataClass);
                    _Instance = (PreguntaProvider)obj.Unwrap();
                }
                return _Instance;
            }
        }

        /// <summary>
        /// Provider's default constructor
        /// </summary>
        public PreguntaProvider()
        {
        }
        /// <summary>
        /// Abstract method to add Pregunta
        ///  /summary>
        /// <param name="Pregunta"></param>
        /// <returns></returns>
        public abstract int AddPregunta(PreguntaEntity entity_Pregunta);

        /// <summary>
        /// Abstract method to delete Pregunta
        /// </summary>
        public abstract int DeletePregunta(int? IdPregunta);

        /// <summary>
        /// Abstract method to update Pregunta
        /// </summary>
        public abstract int EditPregunta(PreguntaEntity entity_Pregunta);

        /// <summary>
        /// Abstract method to get all Pregunta
        /// </summary>
        public abstract List<PreguntaEntity> GetPregunta();

        /// <summary>
        /// Abstract method to get all Pregunta List<int> lid
        /// </summary>
        public abstract List<PreguntaEntity> GetPregunta(List<int> lid);

        /// <summary>
        /// Abstract method to get by id
        /// </summary>
        public abstract PreguntaEntity GetPreguntaById(int? IdPregunta);


        public abstract List<PreguntaEntity> GetPreguntaByIdTipoPregunta(int? IdTipoPregunta);

        public abstract List<PreguntaEntity> GetPreguntaByIdPregunta(int? IdPregunta);




        /// <summary>
        ///Get Pregunta
        ///</summary>
        public abstract SoftvList<PreguntaEntity> GetPagedList(int pageIndex, int pageSize);

        /// <summary>
        ///Get Pregunta
        ///</summary>
        public abstract SoftvList<PreguntaEntity> GetPagedList(int pageIndex, int pageSize, String xml);

        /// <summary>
        /// Converts data from reader to entity
        /// </summary>
        protected virtual PreguntaEntity GetPreguntaFromReader(IDataReader reader)
        {
            PreguntaEntity entity_Pregunta = null;
            try
            {
                entity_Pregunta = new PreguntaEntity();
                entity_Pregunta.IdPregunta = (int?)(GetFromReader(reader, "IdPregunta"));
                entity_Pregunta.Pregunta = (String)(GetFromReader(reader, "Pregunta", IsString: true));
                entity_Pregunta.IdTipoPregunta = (int?)(GetFromReader(reader, "IdTipoPregunta"));
                entity_Pregunta.Cerrada = (bool?)(GetFromReader(reader, "Cerrada"));
                entity_Pregunta.OpcMultiple = (bool?)(GetFromReader(reader, "OpcMultiple"));
                entity_Pregunta.Abierta = (bool?)(GetFromReader(reader, "Abierta"));



            }
            catch (Exception ex)
            {
                throw new Exception("Error converting Pregunta data to entity", ex);
            }
            return entity_Pregunta;
        }

    }

    #region Customs Methods

    #endregion
}


﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Linq;
using Softv.Providers;
using Softv.Entities;
using Globals;

/// <summary>
/// Class                   : Softv.BAL.Client.cs
/// Generated by            : Class Generator (c) 2014
/// Description             : RelEncuestaPreguntaResBussines
/// File                    : RelEncuestaPreguntaResBussines.cs
/// Creation date           : 20/05/2016
/// Creation time           : 06:38 p. m.
///</summary>
namespace Softv.BAL
{

    [DataObject]
    [Serializable]
    public class RelEncuestaPreguntaRes
    {

        #region Constructors
        public RelEncuestaPreguntaRes() { }
        #endregion

        /// <summary>
        ///Adds RelEncuestaPreguntaRes
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int Add(RelEncuestaPreguntaResEntity objRelEncuestaPreguntaRes)
        {
            int result = ProviderSoftv.RelEncuestaPreguntaRes.AddRelEncuestaPreguntaRes(objRelEncuestaPreguntaRes);
            return result;
        }

        /// <summary>
        ///Delete RelEncuestaPreguntaRes
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static int Delete(int? Id)
        {
            int resultado = ProviderSoftv.RelEncuestaPreguntaRes.DeleteRelEncuestaPreguntaRes(Id);
            return resultado;
        }

        /// <summary>
        ///Update RelEncuestaPreguntaRes
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Edit(RelEncuestaPreguntaResEntity objRelEncuestaPreguntaRes)
        {
            int result = ProviderSoftv.RelEncuestaPreguntaRes.EditRelEncuestaPreguntaRes(objRelEncuestaPreguntaRes);
            return result;
        }

        /// <summary>
        ///Get RelEncuestaPreguntaRes
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<RelEncuestaPreguntaResEntity> GetAll()
        {
            List<RelEncuestaPreguntaResEntity> entities = new List<RelEncuestaPreguntaResEntity>();
            entities = ProviderSoftv.RelEncuestaPreguntaRes.GetRelEncuestaPreguntaRes();

            List<EncuestaEntity> lEncuesta = ProviderSoftv.Encuesta.GetEncuesta(entities.Where(x => x.IdEncuesta.HasValue).Select(x => x.IdEncuesta.Value).ToList());
            lEncuesta.ForEach(XEncuesta => entities.Where(x => x.IdEncuesta.HasValue).Where(x => x.IdEncuesta == XEncuesta.IdEncuesta).ToList().ForEach(y => y.Encuesta = XEncuesta));

            List<PreguntaEntity> lPregunta = ProviderSoftv.Pregunta.GetPregunta(entities.Where(x => x.IdPregunta.HasValue).Select(x => x.IdPregunta.Value).ToList());
            lPregunta.ForEach(XPregunta => entities.Where(x => x.IdPregunta.HasValue).Where(x => x.IdPregunta == XPregunta.IdPregunta).ToList().ForEach(y => y.Pregunta = XPregunta));

            List<ResOpcMultsEntity> lResOpcMults = ProviderSoftv.ResOpcMults.GetResOpcMults(entities.Where(x => x.Id_ResOpcMult.HasValue).Select(x => x.Id_ResOpcMult.Value).ToList());
            lResOpcMults.ForEach(XResOpcMults => entities.Where(x => x.Id_ResOpcMult.HasValue).Where(x => x.Id_ResOpcMult == XResOpcMults.Id_ResOpcMult).ToList().ForEach(y => y.ResOpcMults = XResOpcMults));

            return entities ?? new List<RelEncuestaPreguntaResEntity>();
        }

        /// <summary>
        ///Get RelEncuestaPreguntaRes List<lid>
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<RelEncuestaPreguntaResEntity> GetAll(List<int> lid)
        {
            List<RelEncuestaPreguntaResEntity> entities = new List<RelEncuestaPreguntaResEntity>();
            entities = ProviderSoftv.RelEncuestaPreguntaRes.GetRelEncuestaPreguntaRes(lid);
            return entities ?? new List<RelEncuestaPreguntaResEntity>();
        }

        /// <summary>
        ///Get RelEncuestaPreguntaRes By Id
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static RelEncuestaPreguntaResEntity GetOne(int? Id)
        {
            RelEncuestaPreguntaResEntity result = ProviderSoftv.RelEncuestaPreguntaRes.GetRelEncuestaPreguntaResById(Id);

            if (result.IdEncuesta != null)
                result.Encuesta = ProviderSoftv.Encuesta.GetEncuestaById(result.IdEncuesta);

            if (result.IdPregunta != null)
                result.Pregunta = ProviderSoftv.Pregunta.GetPreguntaById(result.IdPregunta);

            if (result.Id_ResOpcMult != null)
                result.ResOpcMults = ProviderSoftv.ResOpcMults.GetResOpcMultsById(result.Id_ResOpcMult);

            return result;
        }

        /// <summary>
        ///Get RelEncuestaPreguntaRes By Id
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static RelEncuestaPreguntaResEntity GetOneDeep(int? Id)
        {
            RelEncuestaPreguntaResEntity result = ProviderSoftv.RelEncuestaPreguntaRes.GetRelEncuestaPreguntaResById(Id);

            if (result.IdEncuesta != null)
                result.Encuesta = ProviderSoftv.Encuesta.GetEncuestaById(result.IdEncuesta);

            if (result.IdPregunta != null)
                result.Pregunta = ProviderSoftv.Pregunta.GetPreguntaById(result.IdPregunta);

            if (result.Id_ResOpcMult != null)
                result.ResOpcMults = ProviderSoftv.ResOpcMults.GetResOpcMultsById(result.Id_ResOpcMult);

            return result;
        }

        public static List<RelEncuestaPreguntaResEntity> GetRelEncuestaPreguntaResByIdEncuesta(int? IdEncuesta)
        {
            List<RelEncuestaPreguntaResEntity> entities = new List<RelEncuestaPreguntaResEntity>();
            entities = ProviderSoftv.RelEncuestaPreguntaRes.GetRelEncuestaPreguntaResByIdEncuesta(IdEncuesta);
            return entities ?? new List<RelEncuestaPreguntaResEntity>();
        }

        public static List<RelEncuestaPreguntaResEntity> GetRelEncuestaPreguntaResByIdPregunta(int? IdPregunta)
        {
            List<RelEncuestaPreguntaResEntity> entities = new List<RelEncuestaPreguntaResEntity>();
            entities = ProviderSoftv.RelEncuestaPreguntaRes.GetRelEncuestaPreguntaResByIdPregunta(IdPregunta);
            return entities ?? new List<RelEncuestaPreguntaResEntity>();
        }

        public static List<RelEncuestaPreguntaResEntity> GetRelEncuestaPreguntaResById_ResOpcMult(int? Id_ResOpcMult)
        {
            List<RelEncuestaPreguntaResEntity> entities = new List<RelEncuestaPreguntaResEntity>();
            entities = ProviderSoftv.RelEncuestaPreguntaRes.GetRelEncuestaPreguntaResById_ResOpcMult(Id_ResOpcMult);
            return entities ?? new List<RelEncuestaPreguntaResEntity>();
        }



        /// <summary>
        ///Get RelEncuestaPreguntaRes
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static SoftvList<RelEncuestaPreguntaResEntity> GetPagedList(int pageIndex, int pageSize)
        {
            SoftvList<RelEncuestaPreguntaResEntity> entities = new SoftvList<RelEncuestaPreguntaResEntity>();
            entities = ProviderSoftv.RelEncuestaPreguntaRes.GetPagedList(pageIndex, pageSize);

            List<EncuestaEntity> lEncuesta = ProviderSoftv.Encuesta.GetEncuesta(entities.Where(x => x.IdEncuesta.HasValue).Select(x => x.IdEncuesta.Value).Distinct().ToList());
            lEncuesta.ForEach(XEncuesta => entities.Where(x => x.IdEncuesta.HasValue).Where(x => x.IdEncuesta == XEncuesta.IdEncuesta).ToList().ForEach(y => y.Encuesta = XEncuesta));

            List<PreguntaEntity> lPregunta = ProviderSoftv.Pregunta.GetPregunta(entities.Where(x => x.IdPregunta.HasValue).Select(x => x.IdPregunta.Value).Distinct().ToList());
            lPregunta.ForEach(XPregunta => entities.Where(x => x.IdPregunta.HasValue).Where(x => x.IdPregunta == XPregunta.IdPregunta).ToList().ForEach(y => y.Pregunta = XPregunta));

            List<ResOpcMultsEntity> lResOpcMults = ProviderSoftv.ResOpcMults.GetResOpcMults(entities.Where(x => x.Id_ResOpcMult.HasValue).Select(x => x.Id_ResOpcMult.Value).Distinct().ToList());
            lResOpcMults.ForEach(XResOpcMults => entities.Where(x => x.Id_ResOpcMult.HasValue).Where(x => x.Id_ResOpcMult == XResOpcMults.Id_ResOpcMult).ToList().ForEach(y => y.ResOpcMults = XResOpcMults));

            return entities ?? new SoftvList<RelEncuestaPreguntaResEntity>();
        }

        /// <summary>
        ///Get RelEncuestaPreguntaRes
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static SoftvList<RelEncuestaPreguntaResEntity> GetPagedList(int pageIndex, int pageSize, String xml)
        {
            SoftvList<RelEncuestaPreguntaResEntity> entities = new SoftvList<RelEncuestaPreguntaResEntity>();
            entities = ProviderSoftv.RelEncuestaPreguntaRes.GetPagedList(pageIndex, pageSize, xml);

            List<EncuestaEntity> lEncuesta = ProviderSoftv.Encuesta.GetEncuesta(entities.Where(x => x.IdEncuesta.HasValue).Select(x => x.IdEncuesta.Value).Distinct().ToList());
            lEncuesta.ForEach(XEncuesta => entities.Where(x => x.IdEncuesta.HasValue).Where(x => x.IdEncuesta == XEncuesta.IdEncuesta).ToList().ForEach(y => y.Encuesta = XEncuesta));

            List<PreguntaEntity> lPregunta = ProviderSoftv.Pregunta.GetPregunta(entities.Where(x => x.IdPregunta.HasValue).Select(x => x.IdPregunta.Value).Distinct().ToList());
            lPregunta.ForEach(XPregunta => entities.Where(x => x.IdPregunta.HasValue).Where(x => x.IdPregunta == XPregunta.IdPregunta).ToList().ForEach(y => y.Pregunta = XPregunta));

            List<ResOpcMultsEntity> lResOpcMults = ProviderSoftv.ResOpcMults.GetResOpcMults(entities.Where(x => x.Id_ResOpcMult.HasValue).Select(x => x.Id_ResOpcMult.Value).Distinct().ToList());
            lResOpcMults.ForEach(XResOpcMults => entities.Where(x => x.Id_ResOpcMult.HasValue).Where(x => x.Id_ResOpcMult == XResOpcMults.Id_ResOpcMult).ToList().ForEach(y => y.ResOpcMults = XResOpcMults));

            return entities ?? new SoftvList<RelEncuestaPreguntaResEntity>();
        }


    }




    #region Customs Methods

    #endregion
}

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
/// Description             : EncuestaBussines
/// File                    : EncuestaBussines.cs
/// Creation date           : 29/04/2016
/// Creation time           : 05:28 p. m.
///</summary>
namespace Softv.BAL
{

    [DataObject]
    [Serializable]
    public class Encuesta
    {

        #region Constructors
        public Encuesta() { }
        #endregion

        /// <summary>
        ///Adds Encuesta
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int Add(string data)
        {



            int result = ProviderSoftv.Encuesta.AddEncuesta(data);

            return result;
        }

        /// <summary>
        ///Delete Encuesta
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static int Delete(int? IdEncuesta)
        {
            int resultado = ProviderSoftv.Encuesta.DeleteEncuesta(IdEncuesta);
            return resultado;
        }

        /// <summary>
        ///Update Encuesta
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Edit(string data)
        {
            int result = ProviderSoftv.Encuesta.EditEncuesta(data);
            return result;
        }

        /// <summary>
        ///Get Encuesta
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<EncuestaEntity> GetAll()
        {
            List<EncuestaEntity> entities = new List<EncuestaEntity>();
            entities = ProviderSoftv.Encuesta.GetEncuesta();

            List<UsuarioEntity> lUsuario = ProviderSoftv.Usuario.GetUsuario(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).ToList());
            lUsuario.ForEach(XUsuario => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XUsuario.IdUsuario).ToList().ForEach(y => y.Usuario = XUsuario));

            List<RelPreguntaEncuestasEntity> lRelPreguntaEncuestas = ProviderSoftv.RelPreguntaEncuestas.GetRelPreguntaEncuestas(entities.Where(x => x.IdEncuesta.HasValue).Select(x => x.IdEncuesta.Value).ToList());
            lRelPreguntaEncuestas.ForEach(XRelPreguntaEncuestas => entities.Where(x => x.IdEncuesta.HasValue).Where(x => x.IdEncuesta == XRelPreguntaEncuestas.IdEncuesta).ToList().ForEach(y => y.RelPreguntaEncuestas = XRelPreguntaEncuestas));

            List<RelEncuestaClientesEntity> lRelEncuestaClientes = ProviderSoftv.RelEncuestaClientes.GetRelEncuestaClientes(entities.Where(x => x.IdEncuesta.HasValue).Select(x => x.IdEncuesta.Value).ToList());
            lRelEncuestaClientes.ForEach(XRelEncuestaClientes => entities.Where(x => x.IdEncuesta.HasValue).Where(x => x.IdEncuesta == XRelEncuestaClientes.IdEncuesta).ToList().ForEach(y => y.RelEncuestaClientes = XRelEncuestaClientes));

            return entities ?? new List<EncuestaEntity>();
        }

        /// <summary>
        ///Get Encuesta List<lid>
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<EncuestaEntity> GetAll(List<int> lid)
        {
            List<EncuestaEntity> entities = new List<EncuestaEntity>();
            entities = ProviderSoftv.Encuesta.GetEncuesta(lid);
            return entities ?? new List<EncuestaEntity>();
        }

        /// <summary>
        ///Get Encuesta By Id
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static EncuestaEntity GetOne(int? IdEncuesta)
        {
            EncuestaEntity result = ProviderSoftv.Encuesta.GetEncuestaById(IdEncuesta);

            if (result.IdUsuario != null)
                result.Usuario = ProviderSoftv.Usuario.GetUsuarioById(result.IdUsuario);

            if (result.IdEncuesta != null)
                result.RelPreguntaEncuestas = ProviderSoftv.RelPreguntaEncuestas.GetRelPreguntaEncuestasById(result.IdEncuesta);

            if (result.IdEncuesta != null)
                result.RelEncuestaClientes = ProviderSoftv.RelEncuestaClientes.GetRelEncuestaClientesById(result.IdEncuesta);

            return result;
        }

        /// <summary>
        ///Get Encuesta By Id
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static EncuestaEntity GetOneDeep(int? IdEncuesta)
        {
            EncuestaEntity result = ProviderSoftv.Encuesta.GetEncuestaById(IdEncuesta);

            if (result.IdUsuario != null)
                result.Usuario = ProviderSoftv.Usuario.GetUsuarioById(result.IdUsuario);

            if (result.IdEncuesta != null)
                result.RelPreguntaEncuestas = ProviderSoftv.RelPreguntaEncuestas.GetRelPreguntaEncuestasById(result.IdEncuesta);

            if (result.IdEncuesta != null)
                result.RelEncuestaClientes = ProviderSoftv.RelEncuestaClientes.GetRelEncuestaClientesById(result.IdEncuesta);

            return result;
        }

        public static List<EncuestaEntity> GetEncuestaByIdUsuario(int? IdUsuario)
        {
            List<EncuestaEntity> entities = new List<EncuestaEntity>();
            entities = ProviderSoftv.Encuesta.GetEncuestaByIdUsuario(IdUsuario);
            return entities ?? new List<EncuestaEntity>();
        }

        public static List<EncuestaEntity> GetEncuestaByIdEncuesta(int? IdEncuesta)
        {
            List<EncuestaEntity> entities = new List<EncuestaEntity>();
            entities = ProviderSoftv.Encuesta.GetEncuestaByIdEncuesta(IdEncuesta);
            return entities ?? new List<EncuestaEntity>();
        }




        /// <summary>
        ///Get Encuesta
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static SoftvList<EncuestaEntity> GetPagedList(int pageIndex, int pageSize)
        {
            SoftvList<EncuestaEntity> entities = new SoftvList<EncuestaEntity>();
            entities = ProviderSoftv.Encuesta.GetPagedList(pageIndex, pageSize);

            List<UsuarioEntity> lUsuario = ProviderSoftv.Usuario.GetUsuario(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).Distinct().ToList());
            lUsuario.ForEach(XUsuario => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XUsuario.IdUsuario).ToList().ForEach(y => y.Usuario = XUsuario));

            List<RelPreguntaEncuestasEntity> lRelPreguntaEncuestas = ProviderSoftv.RelPreguntaEncuestas.GetRelPreguntaEncuestas(entities.Where(x => x.IdEncuesta.HasValue).Select(x => x.IdEncuesta.Value).Distinct().ToList());
            lRelPreguntaEncuestas.ForEach(XRelPreguntaEncuestas => entities.Where(x => x.IdEncuesta.HasValue).Where(x => x.IdEncuesta == XRelPreguntaEncuestas.IdEncuesta).ToList().ForEach(y => y.RelPreguntaEncuestas = XRelPreguntaEncuestas));

            List<RelEncuestaClientesEntity> lRelEncuestaClientes = ProviderSoftv.RelEncuestaClientes.GetRelEncuestaClientes(entities.Where(x => x.IdEncuesta.HasValue).Select(x => x.IdEncuesta.Value).Distinct().ToList());
            lRelEncuestaClientes.ForEach(XRelEncuestaClientes => entities.Where(x => x.IdEncuesta.HasValue).Where(x => x.IdEncuesta == XRelEncuestaClientes.IdEncuesta).ToList().ForEach(y => y.RelEncuestaClientes = XRelEncuestaClientes));

            return entities ?? new SoftvList<EncuestaEntity>();
        }

        /// <summary>
        ///Get Encuesta
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static SoftvList<EncuestaEntity> GetPagedList(int pageIndex, int pageSize, String xml)
        {
            SoftvList<EncuestaEntity> entities = new SoftvList<EncuestaEntity>();
            entities = ProviderSoftv.Encuesta.GetPagedList(pageIndex, pageSize, xml);

            List<UsuarioEntity> lUsuario = ProviderSoftv.Usuario.GetUsuario(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).Distinct().ToList());
            lUsuario.ForEach(XUsuario => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XUsuario.IdUsuario).ToList().ForEach(y => y.Usuario = XUsuario));

            List<RelPreguntaEncuestasEntity> lRelPreguntaEncuestas = ProviderSoftv.RelPreguntaEncuestas.GetRelPreguntaEncuestas(entities.Where(x => x.IdEncuesta.HasValue).Select(x => x.IdEncuesta.Value).Distinct().ToList());
            lRelPreguntaEncuestas.ForEach(XRelPreguntaEncuestas => entities.Where(x => x.IdEncuesta.HasValue).Where(x => x.IdEncuesta == XRelPreguntaEncuestas.IdEncuesta).ToList().ForEach(y => y.RelPreguntaEncuestas = XRelPreguntaEncuestas));

            List<RelEncuestaClientesEntity> lRelEncuestaClientes = ProviderSoftv.RelEncuestaClientes.GetRelEncuestaClientes(entities.Where(x => x.IdEncuesta.HasValue).Select(x => x.IdEncuesta.Value).Distinct().ToList());
            lRelEncuestaClientes.ForEach(XRelEncuestaClientes => entities.Where(x => x.IdEncuesta.HasValue).Where(x => x.IdEncuesta == XRelEncuestaClientes.IdEncuesta).ToList().ForEach(y => y.RelEncuestaClientes = XRelEncuestaClientes));

            return entities ?? new SoftvList<EncuestaEntity>();
        }









        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int AddEncuestaRel(String xml)
        {
            int result = ProviderSoftv.Encuesta.AddEncuestaRel(xml);
            return result;
        }












    }

    #region Customs Methods

    #endregion
}

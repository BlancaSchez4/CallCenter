﻿
using SoftvMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Softv.Entities;
using Globals;

namespace SoftvMVC.Controllers
{
    /// <summary>
    /// Class                   : SoftvMVC.Controllers.ConexionController.cs
    /// Generated by            : Class Generator (c) 2015
    /// Description             : ConexionController
    /// File                    : ConexionController.cs
    /// Creation date           : 04/05/2016
    /// Creation time           : 01:21 p. m.
    ///</summary>
    public partial class ConexionController : BaseController, IDisposable
    {
        private SoftvService.ConexionClient proxy = null;


        public ConexionController()
        {

            proxy = new SoftvService.ConexionClient();

        }

        new public void Dispose()
        {
            if (proxy != null)
            {
                if (proxy.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxy.Close();
                }
            }

        }

        public ActionResult Index(int? page, int? pageSize)
        
        {

            List<ConexionEntity> conexiones =proxy.GetConexionList();
            ViewData["Conexiones"] = conexiones;
            return View();
        }

        public ActionResult AddConexion(ConexionEntity conexion)
        {
            int result= proxy.AddConexion(conexion);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public string DameConexion(int idConexion ){

           ConexionEntity Conexion= proxy.GetConexionList().Where(y=>y.IdConexion==idConexion).First();
            
           string con = "Data Source=" + Conexion.Servidor + ";Initial Catalog="+Conexion.BaseDeDatos+";User ID="+Conexion.Usuario+";Password="+Conexion.Password+"; ";
            return con;
        }

        public ActionResult ListaConexiones()
        {
            var lista=proxy.GetConexionList().Select(o => new { o.IdConexion, o.Plaza });
            return Json(lista,JsonRequestBehavior.AllowGet);

        }



     

    
     
        //Nuevas funciones 

        public ActionResult GetList(string data, int draw, int start, int length)
        {

            DataTableData dataTableData = new DataTableData();
            dataTableData.draw = draw;
            dataTableData.recordsTotal = 0;
            int recordsFiltered = 0;
            dataTableData.data = FiltrarContenido(ref recordsFiltered, start, length);
            dataTableData.recordsFiltered = recordsFiltered;

            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }

        private List<ConexionEntity> FiltrarContenido(ref int recordFiltered, int start, int length)
        {

            List<ConexionEntity> lista = proxy.GetConexionList();
            recordFiltered = lista.Count;
            int rango = start + length;
            return lista.Skip(start).Take(length).ToList();
        }


        public class DataTableData
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<ConexionEntity> data { get; set; }
        }

    }

}


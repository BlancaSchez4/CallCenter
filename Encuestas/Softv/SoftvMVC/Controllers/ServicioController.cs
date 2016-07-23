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
using System.Data.SqlClient;


namespace SoftvMVC.Controllers
{
    /// <summary>
    /// Class                   : SoftvMVC.Controllers.ServicioController.cs
    /// Generated by            : Class Generator (c) 2015
    /// Description             : ServicioController
    /// File                    : ServicioController.cs
    /// Creation date           : 14/06/2016
    /// Creation time           : 11:09 a. m.
    ///</summary>
    public partial class ServicioController : BaseController, IDisposable
    {
        private SoftvService.ServicioClient proxy = null;

        public ServicioController()
        {
            proxy = new SoftvService.ServicioClient();

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
            PermisosAcceso("Servicio");
            ViewData["Title"] = "Servicio";
            ViewData["Message"] = "Servicio";
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            int pageNumber = (page ?? 1);
            SoftvList<ServicioEntity> listResult = proxy.GetServicioPagedListXml(pageNumber, pSize, SerializeTool.Serialize<ServicioEntity>(new ServicioEntity()));


            CheckNotify();
            ViewBag.CustomScriptsDefault = BuildScriptsDefault("Servicio");
            return View(new StaticPagedList<ServicioEntity>(listResult.ToList(), pageNumber, pSize, listResult.totalCount));
        }

        public ActionResult Details(int id = 0)
        {
            ServicioEntity objServicio = proxy.GetServicio(id);
            if (objServicio == null)
            {
                return HttpNotFound();
            }
            return PartialView(objServicio);
        }

        public ActionResult Create()
        {
            PermisosAccesoDeniedCreate("Servicio");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();

            return View();
        }

        [HttpPost]
        public ActionResult Create(ServicioEntity objServicio)
        {
            if (ModelState.IsValid)
            {

                objServicio.BaseRemoteIp = RemoteIp;
                objServicio.BaseIdUser = LoggedUserName;
                int result = proxy.AddServicio(objServicio);
                if (result == -1)
                {

                    AssingMessageScript("El Servicio ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objServicio);
                }
                if (result > 0)
                {
                    AssingMessageScript("Se dio de alta el Servicio en el sistema.", "success", "Éxito", true);
                    return RedirectToAction("Index");
                }

            }
            return View(objServicio);
        }

        public ActionResult Edit(int id = 0)
        {
            PermisosAccesoDeniedEdit("Servicio");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();
            ServicioEntity objServicio = proxy.GetServicio(id);

            if (objServicio == null)
            {
                return HttpNotFound();
            }
            return View(objServicio);
        }

        //
        // POST: /Servicio/Edit/5
        [HttpPost]
        public ActionResult Edit(ServicioEntity objServicio)
        {
            if (ModelState.IsValid)
            {
                objServicio.BaseRemoteIp = RemoteIp;
                objServicio.BaseIdUser = LoggedUserName;
                int result = proxy.UpdateServicio(objServicio);
                if (result == -1)
                {
                    ServicioEntity objServicioOld = proxy.GetServicio(objServicio.Clv_Servicio);

                    AssingMessageScript("El Servicio ya existe en el sistema, .", "error", "Error", true);
                    CheckNotify();
                    return View(objServicio);
                }
                if (result > 0)
                {
                    AssingMessageScript("El Servicio se modifico en el sistema.", "success", "Éxito", true);
                    CheckNotify();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(objServicio);
        }

        public ActionResult QuickIndex(int? page, int? pageSize, int? Clv_TipSer, String Descripcion, String Clv_Txt, bool? AplicanCom, bool? Sale_en_Cartera, Decimal? Precio, bool? Genera_Orden, bool? Es_Principal, int? Clv_Trabajo)
        {
            int pageNumber = (page ?? 1);
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            SoftvList<ServicioEntity> listResult = null;
            List<ServicioEntity> listServicio = new List<ServicioEntity>();
            ServicioEntity objServicio = new ServicioEntity();
            ServicioEntity objGetServicio = new ServicioEntity();


            if ((Clv_TipSer != null))
            {
                objServicio.Clv_TipSer = Clv_TipSer;
            }

            if ((Descripcion != null && Descripcion.ToString() != ""))
            {
                objServicio.Descripcion = Descripcion;
            }

            if ((Clv_Txt != null && Clv_Txt.ToString() != ""))
            {
                objServicio.Clv_Txt = Clv_Txt;
            }

            if ((AplicanCom != null))
            {
                objServicio.AplicanCom = AplicanCom;
            }

            if ((Sale_en_Cartera != null))
            {
                objServicio.Sale_en_Cartera = Sale_en_Cartera;
            }

            if ((Precio != null))
            {
                objServicio.Precio = Precio;
            }

            if ((Genera_Orden != null))
            {
                objServicio.Genera_Orden = Genera_Orden;
            }

            if ((Es_Principal != null))
            {
                objServicio.Es_Principal = Es_Principal;
            }

            if ((Clv_Trabajo != null))
            {
                objServicio.Clv_Trabajo = Clv_Trabajo;
            }

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            listResult = proxy.GetServicioPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objServicio));
            if (listResult.Count == 0)
            {
                int tempPageNumber = (int)(listResult.totalCount / pSize);
                pageNumber = (int)(listResult.totalCount / pSize) == 0 ? 1 : tempPageNumber;
                listResult = proxy.GetServicioPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objServicio));
            }
            listResult.ToList().ForEach(x => listServicio.Add(x));

            var ServicioAsIPagedList = new StaticPagedList<ServicioEntity>(listServicio, pageNumber, pSize, listResult.totalCount);
            if (ServicioAsIPagedList.Count > 0)
            {
                return PartialView(ServicioAsIPagedList);
            }
            else
            {
                var result = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "No se encontraron registros con los criterios de búsqueda ingresados." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            int result = proxy.DeleteServicio(RemoteIp, LoggedUserName, id);
            if (result > 0)
            {
                var resultOk = new { tipomsj = "success", titulomsj = "Aviso", Success = "True", Message = "Registro de Servicio Eliminado." };
                return Json(resultOk, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var resultNg = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "El Registro de Servicio No puede ser Eliminado validar dependencias." };
                return Json(resultNg, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetServicioCable()
        {

                                //select * from Servicios where Clv_TipSer =1 and Sale_en_Cartera =1 and Es_Principal =1
            return Json(proxy.GetServicioList().Where(o => o.Clv_TipSer == 1 && o.Sale_en_Cartera == true && o.Es_Principal == true), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetServicioBasico()
        {

            //select * from Servicios where Clv_TipSer =2 and Sale_en_Cartera =1 and Es_Principal =1
            return Json(proxy.GetServicioList().Where(o => o.Clv_TipSer == 2 && o.Sale_en_Cartera == true && o.Es_Principal == true), JsonRequestBehavior.AllowGet);
        }

    }

}

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
    /// Class                   : SoftvMVC.Controllers.DatoFiscalController.cs
    /// Generated by            : Class Generator (c) 2015
    /// Description             : DatoFiscalController
    /// File                    : DatoFiscalController.cs
    /// Creation date           : 04/05/2016
    /// Creation time           : 01:31 p. m.
    ///</summary>
    public partial class DatoFiscalController : BaseController, IDisposable
    {
        private SoftvService.DatoFiscalClient proxy = null;

        public DatoFiscalController()
        {

            proxy = new SoftvService.DatoFiscalClient();

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
            PermisosAcceso("DatoFiscal");
            ViewData["Title"] = "DatoFiscal";
            ViewData["Message"] = "DatoFiscal";
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            int pageNumber = (page ?? 1);
            SoftvList<DatoFiscalEntity> listResult = proxy.GetDatoFiscalPagedListXml(pageNumber, pSize, SerializeTool.Serialize<DatoFiscalEntity>(new DatoFiscalEntity()));


            CheckNotify();
            ViewBag.CustomScriptsDefault = BuildScriptsDefault("DatoFiscal");
            return View(new StaticPagedList<DatoFiscalEntity>(listResult.ToList(), pageNumber, pSize, listResult.totalCount));
        }

        public ActionResult Details(int id = 0)
        {
            DatoFiscalEntity objDatoFiscal = proxy.GetDatoFiscal(id);
            if (objDatoFiscal == null)
            {
                return HttpNotFound();
            }
            return PartialView(objDatoFiscal);
        }

        public ActionResult Create()
        {
            PermisosAccesoDeniedCreate("DatoFiscal");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();

            return View();
        }

        [HttpPost]
        public ActionResult Create(DatoFiscalEntity objDatoFiscal)
        {
            if (ModelState.IsValid)
            {

                objDatoFiscal.BaseRemoteIp = RemoteIp;
                objDatoFiscal.BaseIdUser = LoggedUserName;
                int result = proxy.AddDatoFiscal(objDatoFiscal);
                if (result == -1)
                {

                    AssingMessageScript("El DatoFiscal ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objDatoFiscal);
                }
                if (result > 0)
                {
                    AssingMessageScript("Se dio de alta el DatoFiscal en el sistema.", "success", "Éxito", true);
                    return RedirectToAction("Index");
                }

            }
            return View(objDatoFiscal);
        }

        public ActionResult Edit(int id = 0)
        {
            PermisosAccesoDeniedEdit("DatoFiscal");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();
            DatoFiscalEntity objDatoFiscal = proxy.GetDatoFiscal(id);

            if (objDatoFiscal == null)
            {
                return HttpNotFound();
            }
            return View(objDatoFiscal);
        }

        //
        // POST: /DatoFiscal/Edit/5
        [HttpPost]
        public ActionResult Edit(DatoFiscalEntity objDatoFiscal)
        {
            if (ModelState.IsValid)
            {
                objDatoFiscal.BaseRemoteIp = RemoteIp;
                objDatoFiscal.BaseIdUser = LoggedUserName;
                int result = proxy.UpdateDatoFiscal(objDatoFiscal);
                if (result == -1)
                {
                    DatoFiscalEntity objDatoFiscalOld = proxy.GetDatoFiscal(objDatoFiscal.Contrato);

                    AssingMessageScript("El DatoFiscal ya existe en el sistema, .", "error", "Error", true);
                    CheckNotify();
                    return View(objDatoFiscal);
                }
                if (result > 0)
                {
                    AssingMessageScript("El DatoFiscal se modifico en el sistema.", "success", "Éxito", true);
                    CheckNotify();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(objDatoFiscal);
        }

        public ActionResult QuickIndex(int? page, int? pageSize, long? Contrato, byte? IVADESGLOSADO, String RAZON_SOCIAL, String RFC, String CALLE_RS, String NUMERO_RS, String ENTRECALLES, String COLONIA_RS, String CIUDAD_RS, String ESTADO_RS, String CP_RS, String TELEFONO_RS, String FAX_RS, char TIPO, Decimal? IDENTIFICADOR, String CURP, int? id_asociado)
        {
            int pageNumber = (page ?? 1);
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            SoftvList<DatoFiscalEntity> listResult = null;
            List<DatoFiscalEntity> listDatoFiscal = new List<DatoFiscalEntity>();
            DatoFiscalEntity objDatoFiscal = new DatoFiscalEntity();
            DatoFiscalEntity objGetDatoFiscal = new DatoFiscalEntity();


            if ((Contrato != null))
            {
                objDatoFiscal.Contrato = Contrato;
            }

            if ((IVADESGLOSADO != null))
            {
                objDatoFiscal.IVADESGLOSADO = IVADESGLOSADO;
            }

            if ((RAZON_SOCIAL != null && RAZON_SOCIAL.ToString() != ""))
            {
                objDatoFiscal.RAZON_SOCIAL = RAZON_SOCIAL;
            }

            if ((RFC != null && RFC.ToString() != ""))
            {
                objDatoFiscal.RFC = RFC;
            }

            if ((CALLE_RS != null && CALLE_RS.ToString() != ""))
            {
                objDatoFiscal.CALLE_RS = CALLE_RS;
            }

            if ((NUMERO_RS != null && NUMERO_RS.ToString() != ""))
            {
                objDatoFiscal.NUMERO_RS = NUMERO_RS;
            }

            if ((ENTRECALLES != null && ENTRECALLES.ToString() != ""))
            {
                objDatoFiscal.ENTRECALLES = ENTRECALLES;
            }

            if ((COLONIA_RS != null && COLONIA_RS.ToString() != ""))
            {
                objDatoFiscal.COLONIA_RS = COLONIA_RS;
            }

            if ((CIUDAD_RS != null && CIUDAD_RS.ToString() != ""))
            {
                objDatoFiscal.CIUDAD_RS = CIUDAD_RS;
            }

            if ((ESTADO_RS != null && ESTADO_RS.ToString() != ""))
            {
                objDatoFiscal.ESTADO_RS = ESTADO_RS;
            }

            if ((CP_RS != null && CP_RS.ToString() != ""))
            {
                objDatoFiscal.CP_RS = CP_RS;
            }

            if ((TELEFONO_RS != null && TELEFONO_RS.ToString() != ""))
            {
                objDatoFiscal.TELEFONO_RS = TELEFONO_RS;
            }

            if ((FAX_RS != null && FAX_RS.ToString() != ""))
            {
                objDatoFiscal.FAX_RS = FAX_RS;
            }


            if ((IDENTIFICADOR != null))
            {
                objDatoFiscal.IDENTIFICADOR = IDENTIFICADOR;
            }

            if ((CURP != null && CURP.ToString() != ""))
            {
                objDatoFiscal.CURP = CURP;
            }

            if ((id_asociado != null))
            {
                objDatoFiscal.id_asociado = id_asociado;
            }

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            listResult = proxy.GetDatoFiscalPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objDatoFiscal));
            if (listResult.Count == 0)
            {
                int tempPageNumber = (int)(listResult.totalCount / pSize);
                pageNumber = (int)(listResult.totalCount / pSize) == 0 ? 1 : tempPageNumber;
                listResult = proxy.GetDatoFiscalPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objDatoFiscal));
            }
            listResult.ToList().ForEach(x => listDatoFiscal.Add(x));

            var DatoFiscalAsIPagedList = new StaticPagedList<DatoFiscalEntity>(listDatoFiscal, pageNumber, pSize, listResult.totalCount);
            if (DatoFiscalAsIPagedList.Count > 0)
            {
                return PartialView(DatoFiscalAsIPagedList);
            }
            else
            {
                var result = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "No se encontraron registros con los criterios de búsqueda ingresados." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            int result = proxy.DeleteDatoFiscal(RemoteIp, LoggedUserName, id);
            if (result > 0)
            {
                var resultOk = new { tipomsj = "success", titulomsj = "Aviso", Success = "True", Message = "Registro de DatoFiscal Eliminado." };
                return Json(resultOk, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var resultNg = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "El Registro de DatoFiscal No puede ser Eliminado validar dependencias." };
                return Json(resultNg, JsonRequestBehavior.AllowGet);
            }
        }


    }

}


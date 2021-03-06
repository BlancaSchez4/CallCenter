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
    /// Class                   : SoftvMVC.Controllers.UsuarioController.cs
    /// Generated by            : Class Generator (c) 2014
    /// Description             : UsuarioController
    /// File                    : UsuarioController.cs
    /// Creation date           : 19/09/2015
    /// Creation time           : 03:46 p. m.
    ///</summary>
    public partial class UsuarioController : BaseController, IDisposable
    {
        private SoftvService.UsuarioClient proxy = null;

        private SoftvService.RoleClient proxyRole = null;

        private SoftvService.PermisoClient proxyPermiso = null;

        private SoftvService.ModuleClient proxyModule = null;

        public UsuarioController()
        {
            proxy = new SoftvService.UsuarioClient();

            proxyRole = new SoftvService.RoleClient();

            proxyPermiso = new SoftvService.PermisoClient();

            proxyModule = new SoftvService.ModuleClient();

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

            proxyRole = new SoftvService.RoleClient();
            if (proxyRole != null)
            {
                if (proxyRole.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyRole.Close();
                }
            }

            proxyPermiso = new SoftvService.PermisoClient();
            if (proxyPermiso != null)
            {
                if (proxyPermiso.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyPermiso.Close();
                }
            }

            if (proxyModule != null)
            {
                if (proxyModule.State != System.ServiceModel.CommunicationState.Closed)
                {
                    proxyModule.Close();
                }
            }

        }

        public ActionResult Index(int? page, int? pageSize)
        {
            PermisosAcceso("Usuario");            
            ViewData["Roles"] = proxyRole.GetRoleList();
            CheckNotify();
            ViewBag.CustomScriptsDefault = BuildScriptsDefault("Usuario");
            return View();
        }

        public ActionResult Details(int id = 0)
        {
            UsuarioEntity objUsuario = proxy.GetUsuario(id);
            if (objUsuario == null)
            {
                return HttpNotFound();
            }
            return PartialView(objUsuario);
        }

        public ActionResult Create()
        {
            PermisosAccesoDeniedCreate("Usuario");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();

            ViewBag.VBRole = new SelectList(proxyRole.GetRoleList().Where(x => x.Estado == true).OrderBy(x => x.Nombre.Trim()).ToList(), "IdRol", "Nombre");

            return View();
        }

        [HttpPost]
        public ActionResult Create(UsuarioEntity objUsuario)
        {
            if (ModelState.IsValid)
            {
                objUsuario.Estado = true;
                objUsuario.BaseRemoteIp = RemoteIp;
                objUsuario.BaseIdUser = LoggedUserName;
                //int result = proxy.AddUsuario(objUsuario);
                int result;

                try
                {
                    result = proxy.AddUsuario(objUsuario);
                }
                catch (Exception ex)
                {
                    ViewBag.VBRole = new SelectList(proxyRole.GetRoleList().Where(x => x.Estado == true).OrderBy(x => x.Nombre.Trim()).ToList(), "IdRol", "Nombre", objUsuario.IdRol);
                    AssingMessageScript(ex.Message, "error", "Error", true);
                    CheckNotify();
                    return View(objUsuario);
                }


                if (result == -1)
                {

                    ViewBag.VBRole = new SelectList(proxyRole.GetRoleList().Where(x => x.Estado == true).OrderBy(x => x.Nombre.Trim()).ToList(), "IdRol", "Nombre", objUsuario.IdRol);

                    AssingMessageScript("El Usuario '" + objUsuario.Usuario + "' ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objUsuario);
                }
                if (result > 0)
                {
                    AssingMessageScript("Se dio de alta el Usuario '" + objUsuario.Usuario + "' en el sistema.", "success", "Éxito", true);
                    return RedirectToAction("Index");
                }

            }
            return View(objUsuario);
        }

        public ActionResult Edit(int id = 0)
        {
            PermisosAccesoDeniedEdit("Usuario");
            ViewBag.CustomScriptsPageValid = BuildScriptPageValid();
            UsuarioEntity objUsuario = proxy.GetUsuario(id);

            ViewBag.VBRole = new SelectList(proxyRole.GetRoleList().Where(x => x.Estado == true || x.IdRol == objUsuario.IdRol).OrderBy(x => x.Nombre.Trim()).ToList(), "IdRol", "Nombre", objUsuario.IdRol);

            if (objUsuario == null)
            {
                return HttpNotFound();
            }
            return View(objUsuario);
        }

        //
        // POST: /Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioEntity objUsuario)
        {
            if (ModelState.IsValid)
            {
                objUsuario.BaseRemoteIp = RemoteIp;
                objUsuario.BaseIdUser = LoggedUserName;
                //int result = proxy.UpdateUsuario(objUsuario);
                int result;

                try
                {
                    result = proxy.UpdateUsuario(objUsuario);
                }
                catch (Exception ex)
                {
                    UsuarioEntity objUsuarioOld = proxy.GetUsuario(objUsuario.IdUsuario);
                    ViewBag.VBRole = new SelectList(proxyRole.GetRoleList().Where(x => x.Estado == true || x.IdRol == objUsuario.IdRol).OrderBy(x => x.Nombre.Trim()).ToList(), "IdRol", "Nombre", objUsuario.IdRol);
                    AssingMessageScript(ex.Message, "error", "Error", true);
                    CheckNotify();
                    return View(objUsuario);
                }

                if (result == -1)
                {
                    UsuarioEntity objUsuarioOld = proxy.GetUsuario(objUsuario.IdUsuario);
                    ViewBag.VBRole = new SelectList(proxyRole.GetRoleList().Where(x => x.Estado == true || x.IdRol == objUsuario.IdRol).OrderBy(x => x.Nombre.Trim()).ToList(), "IdRol", "Nombre", objUsuario.IdRol);
                    AssingMessageScript("El Usuario '" + objUsuario.Usuario + "' ya existe en el sistema.", "error", "Error", true);
                    CheckNotify();
                    return View(objUsuario);
                }
                if (result > 0)
                {
                    AssingMessageScript("El Usuario '" + objUsuario.Usuario + "' se modifico en el sistema.", "success", "Éxito", true);
                    CheckNotify();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(objUsuario);
        }



        public JsonResult Delete(int id)
        {
            proxy.DeleteUsuario(id);

            String mensaje = "{mensaje:'Se ha eliminado el Usuario'}";
            return Json(mensaje, JsonRequestBehavior.AllowGet);
        }


        public ActionResult QuickIndex(int? page, int? pageSize, String Nombre, String Email, String Usuario, String Password, int? IdRol, int? IdGerencia, int? IdDepartamento, int? id, int? estado, bool? cambioestado)
        {
            int pageNumber = (page ?? 1);
            int pSize = pageSize ?? SoftvMVC.Properties.Settings.Default.pagnum;
            SoftvList<UsuarioEntity> listResult = null;
            List<UsuarioEntity> listUsuario = new List<UsuarioEntity>();
            UsuarioEntity objUsuario = new UsuarioEntity();
            UsuarioEntity objGetUsuario = new UsuarioEntity();

            if (cambioestado == true)
            {
                if (id == 1)
                {
                    var result = new { tipomsj = "error", titulomsj = "Aviso", Success = "False", Message = "No es Posible eliminar este Usuario por que es Requerido para el sistema" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                if (id != null)
                {
                    objGetUsuario = proxy.GetUsuario(id);
                    if (objGetUsuario != null)
                    {
                        objGetUsuario.BaseRemoteIp = RemoteIp;
                        objGetUsuario.BaseIdUser = LoggedUserName;

                        try
                        {
                            proxy.ChangeStateUsuario(objGetUsuario, objGetUsuario.Estado == true ? false : true);
                        }
                        catch (Exception ex)
                        {
                            AssingMessageScript(ex.Message, "error", "Error", true);
                            CheckNotify();
                        }

                        var result = new { tipomsj = "error", titulomsj = "Aviso", Success = "True", Message = "se cambio" };
                    }
                    else
                    {
                        var result = new { tipomsj = "error", titulomsj = "Aviso", Success = "False", Message = "error" };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var result = new { tipomsj = "error", titulomsj = "Aviso", Success = "False", Message = "Null id" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

                listUsuario.Clear();
            }

            if (validateString(Nombre))
                objUsuario.Nombre = Nombre;

            if (validateString(Email))
                objUsuario.Email = Email;

            if (validateString(Usuario))
                objUsuario.Usuario = Usuario;

            if (validateString(Password))
                objUsuario.Password = Password;

            if ((IdRol != null))
            {
                objUsuario.IdRol = IdRol;
            }

            if (estado.HasValue)
                if (estado.Value == 1)
                    objUsuario.Estado = true;
                else if (estado.Value == 0)
                    objUsuario.Estado = false;


            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            listResult = proxy.GetUsuarioPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objUsuario));
            if (listResult.Count == 0)
            {
                int tempPageNumber = (int)(listResult.totalCount / pSize);
                pageNumber = (int)(listResult.totalCount / pSize) == 0 ? 1 : tempPageNumber;
                listResult = proxy.GetUsuarioPagedListXml(pageNumber, pSize, Globals.SerializeTool.Serialize(objUsuario));
            }
            listResult.ToList().ForEach(x => listUsuario.Add(x));

            var UsuarioAsIPagedList = new StaticPagedList<UsuarioEntity>(listUsuario, pageNumber, pSize, listResult.totalCount);
            if (UsuarioAsIPagedList.Count > 0 || cambioestado == true)
            {
                return PartialView(UsuarioAsIPagedList);
            }
            else
            {
                var result = new { tipomsj = "warning", titulomsj = "Aviso", Success = "False", Message = "No se encontraron registros con los criterios de búsqueda ingresados." };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
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

        private List<UsuarioEntity> FiltrarContenido(ref int recordFiltered, int start, int length)
        {

            List<UsuarioEntity> lista = proxy.GetUsuarioList();
            recordFiltered = lista.Count;
            int rango = start + length;
            return lista.Skip(start).Take(length).ToList();
        }

        public class DataTableData
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<UsuarioEntity> data { get; set; }
        }

    }

}


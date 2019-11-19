using Falabella.Models;
using Falabella.Models.ViewModels.Cliente;
using Falabella.Models.ViewModels.TipoDocumento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Falabella.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente       
        public ActionResult Index()
        {
            List<ListClienteViewModels> lst;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Dic_Cliente
                       select new ListClienteViewModels
                       {
                           idCliente = d.cli_IdCliente_PK,
                           idTipoDocumento = d.Fal_Dic_TipoDocumento.tid_IdTipoDocumento_PK,
                           nombre = d.cli_Nombre,
                           documento = d.cli_Documento
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            //Consulta los datos de la tabla Tipo Documento
            List<ListTipoDocumentoViewModels> lst = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Dic_TipoDocumento
                       select new ListTipoDocumentoViewModels
                       {
                           idTipoDocumento = d.tid_IdTipoDocumento_PK,
                           nombre = d.tid_Nombre
                       }).ToList();
            }      

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idTipoDocumento.ToString(),
                    Selected = false
                };
            });
            
            ViewBag.items = items;
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ClienteViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FalabellaEntities db = new FalabellaEntities())
                    {
                        var oCliente= new Fal_Dic_Cliente();
                        oCliente.cli_IdUsuario_FK = 2;
                        oCliente.cli_IdTipoDocumento_FK = model.idTipoDocumento;
                        oCliente.cli_Nombre = model.nombre;
                        oCliente.cli_Documento = model.documento;
                        oCliente.cli_FechaNacimiento = model.fechaNacimiento;
                        oCliente.cli_FechaRegistro = DateTime.Now;

                        db.Fal_Dic_Cliente.Add(oCliente);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/");
                }
                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int idCliente)
        {
            ClienteViewModels model = new ClienteViewModels();
            using (FalabellaEntities db = new FalabellaEntities())
            {
                var oCliente = db.Fal_Dic_Cliente.Find(idCliente);
                model.idTipoDocumento = oCliente.cli_IdTipoDocumento_FK;
                model.nombre = oCliente.cli_Nombre;
                model.documento = oCliente.cli_Documento;
                model.fechaNacimiento = Convert.ToDateTime(oCliente.cli_FechaNacimiento);
            }


            //Consulta los datos de la tabla Tipo Documento
            List<ListTipoDocumentoViewModels> lst = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Dic_TipoDocumento
                       select new ListTipoDocumentoViewModels
                       {
                           idTipoDocumento = d.tid_IdTipoDocumento_PK,
                           nombre = d.tid_Nombre
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idTipoDocumento.ToString(),
                    Selected = false
                };
            });                        

            ViewBag.items = items;

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ClienteViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FalabellaEntities db = new FalabellaEntities())
                    {
                        var oCliente = db.Fal_Dic_Cliente.Find(model.idCliente);
                        oCliente.cli_IdTipoDocumento_FK = model.idTipoDocumento;
                        oCliente.cli_Nombre = model.nombre;
                        oCliente.cli_Documento = model.documento;
                        oCliente.cli_FechaNacimiento = model.fechaNacimiento;

                        db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/");
                }
                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
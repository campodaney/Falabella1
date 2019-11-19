using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falabella.Models;
using Falabella.Models.ViewModels.Compania;

namespace Falabella.Controllers
{
    public class CompaniaController : Controller
    {
        // GET: Compania
        public ActionResult Index()
        {
            List<ListCompaniaViewModels> lst;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Dic_Compania
                       select new ListCompaniaViewModels
                       {
                           idCompania = d.com_IdCompania_PK,
                           nombre = d.com_Nombre,
                           personaContacto = d.com_PersonaContacto,
                           telefonoContacto = d.com_TelefonoContacto,
                           nit = d.com_Nit
                       }).ToList();
            }
            return View(lst);
        }
       
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(CompaniaViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FalabellaEntities db = new FalabellaEntities())
                    {
                        var oCompania = new Fal_Dic_Compania();
                        oCompania.com_Nombre = model.nombre;
                        oCompania.com_IdUsuario_FK = 1;
                        oCompania.com_PersonaContacto = model.personaContacto;
                        oCompania.com_TelefonoContacto = model.telefonoContacto;
                        oCompania.com_Nit = model.nit;
                        oCompania.com_FechaRegistro = DateTime.Now;

                        db.Fal_Dic_Compania.Add(oCompania);
                        db.SaveChanges();
                    }
                    return Redirect("~/Compania/");
                }
                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        
        public ActionResult Editar(int idCompania)
        {
            CompaniaViewModels model = new CompaniaViewModels();
            using (FalabellaEntities db = new FalabellaEntities())
            {
                var oCompania = db.Fal_Dic_Compania.Find(idCompania);
                model.nombre = oCompania.com_Nombre;
                model.personaContacto = oCompania.com_PersonaContacto;
                model.telefonoContacto = oCompania.com_TelefonoContacto;
                model.nit = oCompania.com_Nit;
                model.idCompania = oCompania.com_IdCompania_PK;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(CompaniaViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FalabellaEntities db = new FalabellaEntities())
                    {
                        var oCompania = db.Fal_Dic_Compania.Find(model.idCompania);
                        oCompania.com_Nombre = model.nombre;
                        oCompania.com_PersonaContacto = model.personaContacto;
                        oCompania.com_TelefonoContacto = model.telefonoContacto;
                        oCompania.com_Nit = model.nit;

                        db.Entry(oCompania).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Compania/");
                }
                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int idCompania)
        {
            CompaniaViewModels model = new CompaniaViewModels();
            using (FalabellaEntities db = new FalabellaEntities())
            {
                var oCompania = db.Fal_Dic_Compania.Find(idCompania);
                db.Fal_Dic_Compania.Remove(oCompania);
                db.SaveChanges();
            }

            return Redirect("~/Compania/");
        }
    }
}
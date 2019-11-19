using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falabella.Models;
using Falabella.Models.ViewModels.Compania;
using Falabella.Models.ViewModels.CompaniaProducto;
using Falabella.Models.ViewModels.Producto;

namespace Falabella.Controllers
{
    public class CompaniaProductoController : Controller
    {        
        // GET: CompaniaProducto
        public ActionResult Index()
        {
            List<ListCompaniaProductoViewModels> lst;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Tra_CompaniaProducto
                       select new ListCompaniaProductoViewModels
                       {
                           idCompaniaProducto = d.cop_IdCompaniaProducto_PK,
                           compania = d.Fal_Dic_Compania.com_Nombre,
                           producto = d.Fal_Dic_Producto.prd_Nombre,
                           estado = d.cop_Estado
                       }).ToList();
            }
            
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            //Consulta los datos de la tabla Compañias
            List<ListCompaniaViewModels> lst = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                 lst = (from d in db.Fal_Dic_Compania
                    select new ListCompaniaViewModels
                    {
                        idCompania = d.com_IdCompania_PK,
                        nombre = d.com_Nombre
                    }).ToList();
            
            }

            List<ListProductoViewModels> lstProd = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lstProd = (from d in db.Fal_Dic_Producto
                       select new ListProductoViewModels
                       {
                           idProducto = d.prd_IdProducto_PK,
                           nombre = d.prd_Nombre
                       }).ToList();

            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idCompania.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> itemsPro = lstProd.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idProducto.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            ViewBag.itemsPro = itemsPro;
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(CompaniaProductoViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FalabellaEntities db = new FalabellaEntities())
                    {
                        var oCompaniaProd = new Fal_Tra_CompaniaProducto();
                        oCompaniaProd.cop_IdCompania_FK = model.idCompania;
                        oCompaniaProd.cop_IdProducto_FK = model.idProducto;
                        oCompaniaProd.cop_IdUsuario_FK = 1;
                        oCompaniaProd.cop_Estado = model.estado;                       
                        oCompaniaProd.cop_FechaRegistro = DateTime.Now;

                        db.Fal_Tra_CompaniaProducto.Add(oCompaniaProd);
                        db.SaveChanges();
                    }
                    return Redirect("~/CompaniaProducto/");
                }
                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int idCompaniaProducto)
        {
            CompaniaProductoViewModels model = new CompaniaProductoViewModels();
            using (FalabellaEntities db = new FalabellaEntities())
            {
                var oCompaProducto = db.Fal_Tra_CompaniaProducto.Find(idCompaniaProducto);
                model.idCompania = oCompaProducto.cop_IdCompania_FK;
                model.idProducto = oCompaProducto.cop_IdProducto_FK;
                model.estado = oCompaProducto.cop_Estado;
            }

            //Consulta los datos de la tabla Compañias
            List<ListCompaniaViewModels> lst = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Dic_Compania
                       select new ListCompaniaViewModels
                       {
                           idCompania = d.com_IdCompania_PK,
                           nombre = d.com_Nombre
                       }).ToList();

            }

            List<ListProductoViewModels> lstProd = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lstProd = (from d in db.Fal_Dic_Producto
                           select new ListProductoViewModels
                           {
                               idProducto = d.prd_IdProducto_PK,
                               nombre = d.prd_Nombre
                           }).ToList();

            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idCompania.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> itemsPro = lstProd.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idProducto.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            ViewBag.itemsPro = itemsPro;

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(CompaniaProductoViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FalabellaEntities db = new FalabellaEntities())
                    {
                        var oCompaProducto = db.Fal_Tra_CompaniaProducto.Find(model.idCompaniaProducto);
                        oCompaProducto.cop_IdCompania_FK = model.idCompania;
                        oCompaProducto.cop_IdProducto_FK = model.idProducto;
                        oCompaProducto.cop_Estado = model.estado;

                        db.Entry(oCompaProducto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/CompaniaProducto/");
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
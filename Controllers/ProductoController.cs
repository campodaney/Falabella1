using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falabella.Models;
using Falabella.Models.ViewModels.Producto;

namespace Falabella.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ListProductoViewModels> lst;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Dic_Producto
                       select new ListProductoViewModels
                       {
                           idProducto = d.prd_IdProducto_PK,
                           nombre = d.prd_Nombre,
                           estado = d.prd_EstadoProducto
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProductoViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FalabellaEntities db = new FalabellaEntities())
                    {
                        var oProducto = new Fal_Dic_Producto();                        
                        oProducto.prd_IdUsuario_FK = 1;
                        oProducto.prd_Nombre = model.nombre;
                        oProducto.prd_EstadoProducto = model.estado;                      
                        oProducto.prd_FechaRegistro = DateTime.Now;

                        db.Fal_Dic_Producto.Add(oProducto);
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/");
                }
                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public ActionResult Editar(int idProducto)
        {
            ProductoViewModels model = new ProductoViewModels();
            using (FalabellaEntities db = new FalabellaEntities())
            {
                var oProducto = db.Fal_Dic_Producto.Find(idProducto);
                model.nombre = oProducto.prd_Nombre;
                model.estado = oProducto.prd_EstadoProducto;               
                model.idProducto = oProducto.prd_IdProducto_PK;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ProductoViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FalabellaEntities db = new FalabellaEntities())
                    {
                        var oProducto = db.Fal_Dic_Producto.Find(model.idProducto);
                        oProducto.prd_Nombre = model.nombre;
                        oProducto.prd_EstadoProducto = model.estado;                       

                        db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/");
                }
                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int idProducto)
        {
            ProductoViewModels model = new ProductoViewModels();
            using (FalabellaEntities db = new FalabellaEntities())
            {
                var oProducto = db.Fal_Dic_Producto.Find(idProducto);
                db.Fal_Dic_Producto.Remove(oProducto);
                db.SaveChanges();
            }

            return Redirect("~/Producto/");
        }
    }
}
using Falabella.Models;
using Falabella.Models.ViewModels.Cliente;
using Falabella.Models.ViewModels.Compania;
using Falabella.Models.ViewModels.CompaniaProducto;
using Falabella.Models.ViewModels.Producto;
using Falabella.Models.ViewModels.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Falabella.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        public ActionResult Index()
        {
            List<ListVentaViewModels> lst;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Tra_Venta
                       select new ListVentaViewModels
                       {
                           idVenta = d.ven_IdVenta_PK,
                           cliente = d.Fal_Dic_Cliente.cli_Nombre,
                           compania = d.Fal_Tra_CompaniaProducto.Fal_Dic_Compania.com_Nombre,
                           producto = d.Fal_Tra_CompaniaProducto.Fal_Dic_Producto.prd_Nombre,
                           cantidad = Convert.ToInt32(d.ven_Cantidad),
                           valor = Convert.ToInt32(d.ven_Valor),
                           observacion = d.ven_Observacion,
                           fechaRegistro = d.ven_FechaRegistro
                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {
            //Consulta los datos de la tabla Cliente
            List<ListClienteViewModels> lst = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Dic_Cliente
                       select new ListClienteViewModels
                       {
                           idCliente = d.cli_IdCliente_PK,
                           nombre = d.cli_Nombre
                       }).ToList();
            }

            //Consulta los datos de la tabla Compañias
            List<ListCompaniaViewModels> lstC = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lstC = (from d in db.Fal_Dic_Compania
                       select new ListCompaniaViewModels
                       {
                           idCompania = d.com_IdCompania_PK,
                           nombre = d.com_Nombre
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idCliente.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> itemsC = lstC.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idCompania.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            ViewBag.itemsPro = itemsC;
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(VentaViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FalabellaEntities db = new FalabellaEntities())
                    {
                        var oVenta= new Fal_Tra_Venta();
                        oVenta.ven_IdCompaniaProducto_FK = model.idCompaniaProducto;
                        oVenta.ven_IdCliente_FK = model.idCliente;
                        oVenta.ven_IdUsuario_FK = 2;
                        oVenta.ven_Cantidad = model.cantidad;
                        oVenta.ven_Valor = model.valor;
                        oVenta.ven_Observacion = model.observacion;
                        oVenta.ven_FechaRegistro = DateTime.Now;

                        db.Fal_Tra_Venta.Add(oVenta);
                        db.SaveChanges();
                    }
                    return Redirect("~/Venta/");
                }
                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int idVenta)
        {
            VentaViewModels model = new VentaViewModels();
            using (FalabellaEntities db = new FalabellaEntities())
            {
                var oVenta = db.Fal_Tra_Venta.Find(idVenta);
                model.idCliente = oVenta.ven_IdCliente_FK;
                model.idCompaniaProducto = oVenta.ven_IdCompaniaProducto_FK;
                model.cantidad = Convert.ToInt32(oVenta.ven_Cantidad);
                model.valor = Convert.ToInt32(oVenta.ven_Valor);
                model.observacion = oVenta.ven_Observacion;
            }

            //Consulta los datos de la tabla Cliente
            List<ListClienteViewModels> lst = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Dic_Cliente
                       select new ListClienteViewModels
                       {
                           idCliente = d.cli_IdCliente_PK,
                           nombre = d.cli_Nombre
                       }).ToList();
            }

            //Consulta los datos de la tabla Compañias
            List<ListCompaniaViewModels> lstC = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lstC = (from d in db.Fal_Dic_Compania
                        select new ListCompaniaViewModels
                        {
                            idCompania = d.com_IdCompania_PK,
                            nombre = d.com_Nombre
                        }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idCliente.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> itemsC = lstC.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombre.ToString(),
                    Value = d.idCompania.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            ViewBag.itemsPro = itemsC;

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(VentaViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FalabellaEntities db = new FalabellaEntities())
                    {
                        var oVenta = db.Fal_Tra_Venta.Find(model.idVenta);
                        oVenta.ven_IdCompaniaProducto_FK = model.idCompaniaProducto;
                        oVenta.ven_Cantidad = model.cantidad;
                        oVenta.ven_Valor = model.valor;
                        oVenta.ven_Observacion = model.observacion;

                        db.Entry(oVenta).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Venta/");
                }
                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult GetProducto(int idCompania)
        {
            //Consulta los datos de la tabla Producto
            List<ListCompaniaProductoViewModels> lst = null;
            using (FalabellaEntities db = new FalabellaEntities())
            {
                lst = (from d in db.Fal_Tra_CompaniaProducto 
                       where d.cop_IdCompania_FK == idCompania
                       select new ListCompaniaProductoViewModels
                       {
                           idProducto = d.cop_IdCompaniaProducto_PK,
                           nombre = d.Fal_Dic_Producto.prd_Nombre
                       }).ToList();
            }
            return View();
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
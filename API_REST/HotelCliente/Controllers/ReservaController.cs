using DataTables.Mvc;
using HotelCliente.ConsumeApi;
using HotelCliente.Entidades;
using HotelCliente.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelCliente.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult Details(int id)
        {
            ApiRequest obj = new ApiRequest();

            var result = obj.GetReservaId(id);

            return View();
        }

        public ActionResult Crear()
        {
            ApiRequest obj = new ApiRequest();

            var lt = obj.GetSede();
            List<string> FormaPago = new List<string>();
            FormaPago.Add("Efectivo");
            FormaPago.Add("Tarjeta Credito");
            FormaPago.Add("Cheque");

            ViewBag.FormaPago = new SelectList(FormaPago, "value");

            ViewBag.TipoSede = new SelectList(lt, "Id", "Nombre");

            return View();
        }

        [HttpPost]
        public ActionResult Crear(FormCollection collection)
        {
            ApiRequest obj = new ApiRequest();
            var Reserva = collection;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");

            var NewReserva = new Reserva()
            {
                Cantidad_personas = int.Parse(collection["Cantidad_personas"].ToString()),
                Cedula_Cliente = int.Parse(collection["Cedula_Cliente"].ToString()),
                Fecha = DateTime.Parse(collection["Fecha"].ToString()),
                Cod_Sede = int.Parse(collection["Id"].ToString()),
                Cod_Pago = collection["value"].ToString()
            };

            obj.PostReserva(NewReserva);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult consultaReserva(JQueryDataTableParamModel param)
        {
            ApiRequest obj = new ApiRequest();

            var result = obj.GetReserva();


            var jsonResult = Json(new
            {
                draw = param.draw,
                data = result,
                recordsTotal = result.Count,
                recordsFiltered = result.Count
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}
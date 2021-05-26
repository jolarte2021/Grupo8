using HotelCliente.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace HotelCliente.ConsumeApi
{
    public class ApiRequest
    {
        private static string baseURL = ConfigurationManager.AppSettings["urlApi"];
        private static ApiRequest instance = null;
        public static ApiRequest Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiRequest();
                }

                return instance;
            }
        }

        public List<Reserva> GetReserva()
        {
            try
            {
                var Reserva = new List<Reserva>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:
                    var response = client.GetAsync("api/Reservas").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Reserva = JsonConvert.DeserializeObject<List<Reserva>>(response.Content.ReadAsStringAsync().Result).Select(s => new Entidades.Reserva
                        {
                            Cod_Reserva = s.Cod_Reserva,
                            Cantidad_personas = s.Cantidad_personas,
                            Cedula_Cliente = s.Cedula_Cliente,
                            Cod_Pago = s.Cod_Pago,
                            Cod_Sede = s.Cod_Sede,
                            FechaMuestra = s.Fecha.ToString("MMMM dd, yyyy"),
                            NombreSede = s.ObjSede.Nombre
                        }).ToList();


                    }
                    return Reserva;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Reserva> GetReservaId(int id)
        {
            try
            {
                var Reserva = new List<Reserva>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:
                    var response = client.GetAsync("api/Reservas/"+ id).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Reserva = JsonConvert.DeserializeObject<List<Reserva>>(response.Content.ReadAsStringAsync().Result).Select(s => new Entidades.Reserva
                        {
                            Cod_Reserva = s.Cod_Reserva,
                            Cantidad_personas = s.Cantidad_personas,
                            Cedula_Cliente = s.Cedula_Cliente,
                            Cod_Pago = s.Cod_Pago,
                            Cod_Sede = s.Cod_Sede,
                            Fecha = s.Fecha
                        }).ToList();


                    }
                    return Reserva;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Sede> GetSede()
        {
            try
            {
                var Sedes = new List<Sede>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:
                    var response = client.GetAsync("api/sedes").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Sedes = JsonConvert.DeserializeObject<List<Sede>>(response.Content.ReadAsStringAsync().Result).Select(s => new Entidades.Sede
                        {
                            Ciudad = s.Ciudad,
                            Direccion = s.Direccion,
                            Id = s.Id,
                            Nombre = s.Nombre,
                            Pais =s.Pais,
                            Telefono = s.Telefono
                        }).ToList();


                    }
                    return Sedes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int PostReserva(Reserva obj)
        {
            try
            {
                var myContent = JsonConvert.SerializeObject(obj);
                var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:
                    var response = client.PostAsync("api/Reservas", stringContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
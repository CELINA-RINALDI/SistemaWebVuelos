using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Data
{
    public class VueloInitializer : DropCreateDatabaseAlways<VueloDbContext>
    {
        protected override void Seed(VueloDbContext context)
        {
            var vuelos = new List<Vuelo>
            {
               new Vuelo {
                  Origen = "Buenos Aires",
                  Destino = "Madrid",
                  Fecha = Convert.ToDateTime(2000/1/1),
                  Matricula = "123"
               },
               new Vuelo {
                  Origen = "Buenos Aires",
                  Destino = "Londres",
                  Fecha = Convert.ToDateTime(2020/1/1),
                  Matricula = "111"
               },
               new Vuelo {
                  Origen = "Buenos Aires",
                  Destino = "Miami",
                  Fecha = Convert.ToDateTime(2004/1/1),
                  Matricula = "125"
               },
               new Vuelo {
                  Origen = "Buenos Aires",
                  Destino = "Paris",
                  Fecha = Convert.ToDateTime(2021/1/1),
                  Matricula = "105"
               }

            };
            vuelos.ForEach(s => context.Vuelos.Add(s));

            context.SaveChanges();


        }

    }
}
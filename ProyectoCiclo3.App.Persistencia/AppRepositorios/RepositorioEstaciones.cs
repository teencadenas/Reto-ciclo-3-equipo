using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEstaciones
    {
        List<Estaciones> estaciones;
 
    public RepositorioEstaciones()
        {
            estaciones= new List<Estaciones>()
            {
		        new Estaciones{id=1,nombre="Calle 26",direccion="Calle 26",coord_x= 300,coord_y= 234,tipo= "Ruta facil"},
                new Estaciones{id=2,nombre="Calle 57",direccion="Calle 56 ",coord_x= 789,coord_y= 123,tipo= "Ruta facil"},
                new Estaciones{id=3,nombre="Av Jimenez",direccion="Carrera 9",coord_x= 123,coord_y= 123,tipo= "Ruta Facil"}
 
            };
        }
 
        public IEnumerable<Estaciones> GetAll()
        {
            return estaciones;
        }
 
        public Estaciones GetEstacionWithId(int id){
            return estaciones.SingleOrDefault(b => b.id == id);
        }

        public Estaciones Update(Estaciones newEstacion){
            var Estacion= estaciones.SingleOrDefault(b => b.id == newEstacion.id);
            if(Estacion != null){
                Estacion.id = newEstacion.id;
                Estacion.nombre = newEstacion.nombre;
                Estacion.direccion = newEstacion.direccion;
                Estacion.coord_x = newEstacion.coord_x;
                Estacion.coord_y = newEstacion.coord_y;
                Estacion.tipo = newEstacion.tipo;
            }
        return Estacion;
        }

        public Estaciones Create(Estaciones newEstacion)
        {
           if(estaciones.Count > 0){
           newEstacion.id=estaciones.Max(r => r.id) +1; 
            }else{
               newEstacion.id = 1; 
            }
           estaciones.Add(newEstacion);
           return newEstacion;
        }

        public Estaciones Delete(int id)
        {
        var bus= estaciones.SingleOrDefault(b => b.id == id);
        estaciones.Remove(bus);
        return bus;
        }


    }
}
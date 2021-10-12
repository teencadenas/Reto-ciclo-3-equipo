using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEstaciones
    {

        private readonly AppContext _appContext = new AppContext(); 

        public IEnumerable<Estaciones> GetAll()
        {
            return _appContext.Estaciones;
        }
 
        public Estaciones GetEstacionWithId(int id){
            return _appContext.Estaciones.Find(id);
        }

        public Estaciones Update(Estaciones newEstacion){
            var Estacion= _appContext.Estaciones.Find(newEstacion.id);
            if(Estacion != null){
                Estacion.nombre = newEstacion.nombre;
                Estacion.direccion = newEstacion.direccion;
                Estacion.coord_x = newEstacion.coord_x;
                Estacion.coord_y = newEstacion.coord_y;
                Estacion.tipo = newEstacion.tipo;
                _appContext.SaveChanges();
            }
        return Estacion;
        }

        public Estaciones Create(Estaciones newEstacion)
        {
           var addEstacion = _appContext.Estaciones.Add(newEstacion);
            _appContext.SaveChanges();
            return addEstacion.Entity;

        }

        public void Delete(int id)
        {
        var estacion = _appContext.Estaciones.Find(id);
        if (estacion == null)
            return;
        _appContext.Estaciones.Remove(estacion);
        _appContext.SaveChanges();
        }

    }
}
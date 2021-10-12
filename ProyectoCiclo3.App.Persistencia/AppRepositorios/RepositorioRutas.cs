using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioRutas
    {

        private readonly AppContext _appContext = new AppContext(); 

        public IEnumerable<Rutas> GetAll()
        {
            return _appContext.Rutas;
        }
 
        public Rutas GetRutaWithId(int id){
            return _appContext.Rutas.Find(id);;
        }

        public Rutas Update(Rutas newRuta){
            var ruta= _appContext.Rutas.Find(newRuta.id);
            if(ruta != null){
                ruta.origen= newRuta.origen;
                ruta.destino= newRuta.destino;
                ruta.tiempo_estimado = newRuta.tiempo_estimado;
                _appContext.SaveChanges();
            }
        return ruta;
        }

        public Rutas Create(Rutas newRuta)
        {
           var addRutas = _appContext.Rutas.Add(newRuta);
            _appContext.SaveChanges();
            return addRutas.Entity;

        }

        public void Delete(int id)
        {
        var ruta = _appContext.Rutas.Find(id);
        if (ruta == null)
            return;
        _appContext.Rutas.Remove(ruta);
        _appContext.SaveChanges();
        }

    }
}
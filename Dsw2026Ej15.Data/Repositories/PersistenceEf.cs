using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Dsw2026Ej15.Domain;

namespace Dsw2026Ej15.Data.Repositories
{
    public class PersistenceEf : IPersistence
    {
        // Asegúrate de que use el contexto real de Carlos: Dsw2026Ej15DbContext
        private readonly Dsw2026Ej15DbContext _context;

        // El constructor también debe recibir Dsw2026Ej15DbContext
        public PersistenceEf(Dsw2026Ej15DbContext context)
        {
            _context = context;
        }

        public void Guardar<T>(T entidad) where T : class
        {
            _context.Set<T>().Add(entidad);
            _context.SaveChanges();
        }

        public T ObtenerPorId<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }
    }
}



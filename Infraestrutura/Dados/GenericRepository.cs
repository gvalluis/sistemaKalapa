using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Dados
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntidade
    {
        private ContextoLoja _contexto;

        public GenericRepository(ContextoLoja contexto)
        {
            _contexto = contexto;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _contexto.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _contexto.Set<T>().ToListAsync();
        }
    }
}
using System.Threading.Tasks;
using Core.Entidades;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntidade
    {
         Task<T> GetByIdAsync(int id);
         Task<IReadOnlyList<T>> ListAllAsync();
    }
}
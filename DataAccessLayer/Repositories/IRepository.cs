using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> ReadAsync(string location);
    }
}

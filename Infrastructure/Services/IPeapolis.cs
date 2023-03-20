using BusinessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IPeapolis
    {
        Task<List<Peapolis>> GetAll();
    }
}

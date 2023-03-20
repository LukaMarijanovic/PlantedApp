using BusinessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Log;
using BusinessLayer.Helpers;

namespace Infrastructure.Services.ServiceImplementation
{
    public class FruitstarService : IFruitstar
    {
        private readonly IFruitstarRepository _fruitstarRepository;
        public FruitstarService(IFruitstarRepository fruitstarRepository)
        {
            _fruitstarRepository = fruitstarRepository;
        }

        public async Task<List<Fruitstar>> GetAll()
        {
            IEnumerable<Fruitstar> fruitstars = new List<Fruitstar>();
            try
            {
                fruitstars = await _fruitstarRepository.ReadAsync(Helpers.GetFilePath("~/JsonlFiles/fruitstar.json"));
            }
            catch (Exception ex)
            {
                LogFactory.GetLogger().Error("Get all Fruitstar " + ex.Message + Environment.NewLine + ex.StackTrace);
            }

            return fruitstars.ToList();
        }
    }
}

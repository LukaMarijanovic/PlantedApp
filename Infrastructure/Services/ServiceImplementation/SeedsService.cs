using BusinessLayer.Helpers;
using BusinessLayer.Models;
using DataAccessLayer.Repositories;
using Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services.ServiceImplementation
{
    public class SeedsService : ISeeds
    { 
        private readonly ISeedsRepository _seedsRepository;

        public SeedsService(ISeedsRepository seedsRepository)
        {
            _seedsRepository = seedsRepository;
        }

        public async Task<List<Seeds>> GetAll()
        {
            IEnumerable<Seeds> seeds = new List<Seeds>();

            try
            {
                seeds = await _seedsRepository.ReadAsync(Helpers.GetFilePath("~/JsonlFiles/seeds.json"));
            }
            catch (Exception ex)
            {
                LogFactory.GetLogger().Error("Get all Seeds " + ex.Message + Environment.NewLine + ex.StackTrace);                
            }

            return seeds.ToList();
        }
    }
}

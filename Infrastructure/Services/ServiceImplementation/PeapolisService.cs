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
    public class PeapolisService : IPeapolis
    {
        private readonly IPeapolisRepository _peapolisRepository;
        public PeapolisService(IPeapolisRepository peapolisRepository)
        {
            _peapolisRepository = peapolisRepository;
        }

        public async Task<List<Peapolis>> GetAll()
        {
            IEnumerable<Peapolis> peapolis = new List<Peapolis>();
            try
            {
                peapolis = await _peapolisRepository.ReadAsync(Helpers.GetFilePath("~/JsonlFiles/peapolis.json"));
            }
            catch (Exception ex)
            {
                LogFactory.GetLogger().Error("Get all Peapolis " + ex.Message + Environment.NewLine + ex.StackTrace);
            }           
            return peapolis.ToList();
        }

    }
}

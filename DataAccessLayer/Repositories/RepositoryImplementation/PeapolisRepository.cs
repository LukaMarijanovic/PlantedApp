using BusinessLayer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RepositoryImplementation
{
    public class PeapolisRepository : IPeapolisRepository
    {
        public async Task<IEnumerable<Peapolis>> ReadAsync(string location)
        {
            List<Peapolis> list = new List<Peapolis>();
            using (StreamReader r = new StreamReader(location))
            {
                while (!r.EndOfStream)
                {
                    string line = await r.ReadLineAsync();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        list.Add(JsonConvert.DeserializeObject<Peapolis>(line));
                    }
                }
            }
            return list;
        }
    }
}

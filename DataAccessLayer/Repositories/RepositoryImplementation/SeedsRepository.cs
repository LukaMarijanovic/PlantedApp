using BusinessLayer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RepositoryImplementation
{
    public class SeedsRepository : ISeedsRepository
    {
        public async Task<IEnumerable<Seeds>> ReadAsync(string location)
        {
            List<Seeds> list = new List<Seeds>();
            using (StreamReader r = new StreamReader(location))
            {
                while (!r.EndOfStream)
                {
                    string line = await r.ReadLineAsync();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        list.Add(JsonConvert.DeserializeObject<Seeds>(line));
                    }
                }
            }
            return list;
        }
    }
}

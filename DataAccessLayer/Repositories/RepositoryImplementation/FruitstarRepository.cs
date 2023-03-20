using BusinessLayer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RepositoryImplementation
{
    public class FruitstarRepository : IFruitstarRepository
    {
        public async Task<IEnumerable<Fruitstar>> ReadAsync(string location)
        {
            List<Fruitstar> list = new List<Fruitstar>();
            using (StreamReader r = new StreamReader(location))
            {
                while (!r.EndOfStream)
                {
                    string line = await r.ReadLineAsync();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        list.Add(JsonConvert.DeserializeObject<Fruitstar>(line));
                    }
                }
            }
            return list;
        }
    }
}

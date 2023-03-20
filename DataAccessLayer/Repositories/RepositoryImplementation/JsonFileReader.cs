using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.RepositoryImplementation
{
    public class JsonFileReader<T> : IRepository<T> where T : class
    {
        public async Task<IEnumerable<T>> ReadAsync(string location)
        {
            List<T> list = new List<T>();
            using (StreamReader r = new StreamReader(location))
            {
                while (!r.EndOfStream)
                {
                    string line = await r.ReadLineAsync();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        list.Add(JsonConvert.DeserializeObject<T>(line));                      
                    }
                }
            }
            return list;
        }
    }
}

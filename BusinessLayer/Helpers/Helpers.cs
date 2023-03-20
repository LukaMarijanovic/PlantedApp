using BusinessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.Helpers
{
    public static class Helpers
    {
        public static string GetFilePath(string filePath)
        {
            var context = HttpContext.Current;
            if (context == null) return filePath;
            return HttpContext.Current.Server.MapPath(filePath);
        }

        public static List<ZipCode> MergeZipCodes(Community community)
        {
            List<ZipCode> zipCodes = new List<ZipCode>();

            var zipCodesPeapolis = community.PeapolisCollection.GroupBy(x => x.Address.Zip).Select(x => new ZipCode { Code = x.Key.ToString(), Count = x.Count() }).ToList();
            var zipCodesFruitstar = community.FruitstarCollection.GroupBy(x => x.Address.Zip).Select(x => new ZipCode { Code = x.Key.ToString(), Count = x.Count() }).ToList();
            var zipCodesSeeds = community.SeedsCollection.GroupBy(x => x.PostCode).Select(x => new ZipCode { Code = x.Key, Count = x.Count() }).ToList();
            var concatZipCodes = zipCodesPeapolis.Concat(zipCodesFruitstar).Concat(zipCodesSeeds);

             zipCodes = concatZipCodes
            .GroupBy(x => x.Code)
            .Select(g => new ZipCode { Code = g.Key, Count = g.Sum(p => p.Count) })
            .ToList();

            return zipCodes;
        }
    }
}

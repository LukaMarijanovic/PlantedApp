using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Models
{
    public class Community
    {
        public List<Peapolis> PeapolisCollection { get; set; }
        public List<Seeds> SeedsCollection { get; set; }
        public List<Fruitstar> FruitstarCollection { get; set; }

        public List<ZipCode> GetPeapolisZipCodes()
        {
            if(PeapolisCollection == null || !PeapolisCollection.Any()) return new List<ZipCode>();

            return PeapolisCollection
                                    .GroupBy(x => x.Address.Zip)
                                    .Select(g => new ZipCode { Code = g.Key.ToString(), Count = g.Count() })
                                    .ToList();
        }

        public List<ZipCode> GetSeedsZipCodes()
        {
            if (SeedsCollection == null || !SeedsCollection.Any()) return new List<ZipCode>();

            return SeedsCollection
                                .GroupBy(x => x.PostCode)
                                .Select(g => new ZipCode { Code = g.Key, Count = g.Count() })
                                .ToList();
        }

        public List<ZipCode> GetFruitstarZipCodes()
        {
            if (FruitstarCollection == null || !FruitstarCollection.Any()) return new List<ZipCode>();
            return FruitstarCollection
                                     .GroupBy(x => x.Address.Zip)
                                     .Select(g => new ZipCode { Code = g.Key.ToString(), Count = g.Count() })
                                     .ToList();
        }

        public List<ZipCode> GetCommunityZipCodes()
        {
            List<ZipCode> zipCodes = new List<ZipCode>();
            zipCodes.AddRange(GetPeapolisZipCodes());
            zipCodes.AddRange(GetSeedsZipCodes());
            zipCodes.AddRange(GetFruitstarZipCodes());
            return zipCodes
            .GroupBy(x => x.Code)
            .Select(g => new ZipCode { Code = g.Key, Count = g.Sum(p => p.Count) })
            .ToList();
        }

        //TODO:
        //Create this function
        //private IEnumerable<T> GetZipCodes(Func<T, object> predicate)
        //{
        //    return zipCodes
        //    .GroupBy(x => x.Code)
        //    .Select(g => new ZipCode { Code = g.Key, Count = g.Sum(p => p.Count) })
        //    .ToList();
        //}

    }
}

using System.Runtime.Serialization;

namespace BusinessLayer.Models
{
    [DataContract(Name = "peapolis")]
    public class Peapolis : BaseCommunityMember
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        public Address Address { get; set; }

    }
}

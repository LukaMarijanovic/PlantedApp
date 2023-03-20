using System.Runtime.Serialization;

namespace BusinessLayer.Models
{
    [DataContract(Name = "seeds")]
    public class Seeds : BaseCommunityMember
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "street")]
        public string Street { get; set; }

        [DataMember(Name = "postcode")]
        public string PostCode { get; set; }
        
    }
}

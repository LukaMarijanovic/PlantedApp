using System.Runtime.Serialization;

namespace BusinessLayer.Models
{
    [DataContract(Name = "fruitstar")]
    public class Fruitstar : BaseCommunityMember
    {
        [DataMember(Name = "uuid")]
        public string Id { get; set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "address")]
        public Address Address { get; set; }
    }
}

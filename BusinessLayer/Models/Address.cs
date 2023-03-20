using System.Runtime.Serialization;

namespace BusinessLayer.Models
{
    [DataContract(Name = "address")]
    public class Address
    {
        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "street")]
        public string Street { get; set; }

        [DataMember(Name = "house_number")]
        public int HouseNumber { get; set; }

        [DataMember(Name = "zip")]
        public int Zip { get; set; }
    }
}

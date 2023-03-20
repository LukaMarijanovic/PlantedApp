using System;
using System.Runtime.Serialization;

namespace BusinessLayer.Models
{
    [DataContract]
    public class BaseCommunityMember
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "last_login")]
        public DateTime? LastLogin { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [DataMember(Name = "deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}

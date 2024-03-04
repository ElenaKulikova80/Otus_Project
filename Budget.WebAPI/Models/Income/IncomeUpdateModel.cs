using System.Runtime.Serialization;

namespace Budget.WebAPI.DTO.Income
{
    [DataContract]
    public class IncomeUpdateModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "money")]
        public double Money { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }
    }
}

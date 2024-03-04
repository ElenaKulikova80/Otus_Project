using System.Runtime.Serialization;

namespace Budget.WebAPI.DTO.Income
{
    [DataContract]
    public class IncomeInputModel
    {
        [DataMember(Name = "money")]
        public double Money { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }
    }
}

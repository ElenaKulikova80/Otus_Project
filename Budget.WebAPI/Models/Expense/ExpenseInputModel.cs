using System.Runtime.Serialization;

namespace Budget.WebAPI.DTO
{
    [DataContract]
    public class ExpenseInputModel
    {
        [DataMember(Name = "userid")]
        public int UserID { get; set; }

        [DataMember(Name = "money")]
        public double Money { get; set; }

        [DataMember(Name = "categoryid")]
        public int CategoryID { get; set; }

        
        [DataMember(Name = "comment")]
        public string? Comment { get; set; }
    }
}

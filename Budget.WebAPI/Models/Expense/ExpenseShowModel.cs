using System.Runtime.Serialization;

namespace Budget.WebAPI.DTO
{
    [DataContract]
    public class ExpenseShowModel
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

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

using System.Runtime.Serialization;

namespace Budget.WebAPI.DTO.Category;

[DataContract]
public class CategoryShowModel
{
    [DataMember(Name = "id")]
    public int ID { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }
}

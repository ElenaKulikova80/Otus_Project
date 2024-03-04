using System.Runtime.Serialization;

namespace Budget.WebAPI.DTO.Category;

[DataContract]
public class CategoryInputModel
{
    [DataMember(Name = "name")]
    public string Name { get; set; }
}

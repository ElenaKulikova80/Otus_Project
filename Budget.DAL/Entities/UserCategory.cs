namespace Budget.DAL.Entities;

public class UserCategory : BasicItem
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public double Share { get; set; }
}

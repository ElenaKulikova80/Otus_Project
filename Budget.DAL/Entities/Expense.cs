namespace Budget.DAL.Entities;

public class Expense : BasicItem
{
    public int UserId { get; set; }
    public User User { get; set; }
    public double Money { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string? Comment { get; set; }
}

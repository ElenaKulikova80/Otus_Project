namespace Budget.DAL.Entities;

public class Income : BasicItem
{
    public int UserId { get; set; }
    public User User { get; set; }
    public double Money { get; set; }
    public string? Comment { get; set; }
}

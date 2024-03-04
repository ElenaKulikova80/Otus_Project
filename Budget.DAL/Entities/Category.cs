namespace Budget.DAL.Entities;

public class Category : BasicItem
{
    public string Name { get; set; } 
    public ICollection<Expense> Expansies { get; set; }
    public ICollection<UserCategory> UserCategoryPct { get; set; }
}

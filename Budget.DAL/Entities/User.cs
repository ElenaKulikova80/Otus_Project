namespace Budget.DAL.Entities;

public class User : BasicItem
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public Guid IdentityUserID { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<Expense> Expansies { get; set; }
    public ICollection<UserCategory> UserCategoryPct { get; set; }
    public ICollection<Income> Incomies { get; set; }
}

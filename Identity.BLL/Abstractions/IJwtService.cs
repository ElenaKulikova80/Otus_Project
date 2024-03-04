namespace Identity.BLL.Abstractions
{
  public interface IJwtService
  {
    string GetJwtSecurityTokenAsync(string UserName);
  }
}

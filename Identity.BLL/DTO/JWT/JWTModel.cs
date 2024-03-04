namespace Identity.BLL.DTO.JWT;
public class JwtModel
{
  public string SecretKey { get; set; }
  public string Issuer { get; set; }
  public string Audience { get; set; }

}


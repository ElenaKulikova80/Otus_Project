using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Identity.BLL.Abstractions;
using Identity.WebAPI.Models;
using Identity.WebAPI.RabbitMq;

namespace Identity.WebAPI;

[Route("api/v1/account")]
public class AccountController : Controller
{
  private UserManager<ApplicationUser> _userManager { get; set; }
  private SignInManager<ApplicationUser> _signInManager { get; set; }
  private IMapper _mapper { get; set; }
  private IJwtService _jwtService { get;set; }
  private readonly IRabbitMqProducer _messageProducer;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>signInManager,IMapper mapper, IJwtService jwtService, IRabbitMqProducer messageProducer)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _jwtService = jwtService;
        _messageProducer = messageProducer;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Index([FromBody]ApplicationUserRegisterModel input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        else
        {
            var user = _mapper.Map<ApplicationUser>(input);

            var result = await _userManager.CreateAsync(user, input.Password);
            if (result.Succeeded)
            {
                _messageProducer.SendMessage(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
    
    [HttpPost]
    [Route("signin")]
    public async Task<IActionResult> SignIn([FromBody]ApplicationUserAuthenticationModel authinput)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        else
        {
            var user = _mapper.Map<ApplicationUser>(authinput);
            var username = await _userManager.FindByNameAsync(user.UserName);
            var result = await _signInManager.PasswordSignInAsync(username, authinput.Password, false, false); 

            if (result.Succeeded)
            {
                
                return Ok(_jwtService.GetJwtSecurityTokenAsync(user.UserName));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

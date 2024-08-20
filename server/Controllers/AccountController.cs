namespace insta_cult.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly CultMembersService _cultMembersService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, CultMembersService cultMembersService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _cultMembersService = cultMembersService;
  }

  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("cultMembers")]
  public async Task<ActionResult<List<JoinedCult>>> GetMyJoinedCults()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<JoinedCult> joinedCults = _cultMembersService.GetMyJoinedCults(userInfo.Id);
      return Ok(joinedCults);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}

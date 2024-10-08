namespace insta_cult.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CultMembersController : ControllerBase
{
  private readonly Auth0Provider _auth0Provider;
  private readonly CultMembersService _cultMembersService;

  public CultMembersController(Auth0Provider auth0Provider, CultMembersService cultMembersService)
  {
    _auth0Provider = auth0Provider;
    _cultMembersService = cultMembersService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Cultist>> CreateCultMember([FromBody] CultMember cultMemberData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      cultMemberData.AccountId = userInfo.Id;
      Cultist cultist = _cultMembersService.CreateCultMember(cultMemberData);
      return Ok(cultist);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpDelete("{cultMemberId}")]
  [Authorize]
  public async Task<ActionResult<string>> DestroyCultMember(int cultMemberId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _cultMembersService.DestroyCultMember(cultMemberId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}
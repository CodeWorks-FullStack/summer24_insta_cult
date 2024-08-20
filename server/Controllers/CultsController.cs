namespace insta_cult.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CultsController : ControllerBase
{
  private readonly CultsService _cultsService;
  private readonly Auth0Provider _auth0Provider;

  private readonly CultMembersService _cultMembersService;

  public CultsController(CultsService cultsService, Auth0Provider auth0Provider, CultMembersService cultMembersService)
  {
    _cultsService = cultsService;
    _auth0Provider = auth0Provider;
    _cultMembersService = cultMembersService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Cult>> CreateCult([FromBody] Cult cultData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      cultData.LeaderId = userInfo.Id;
      Cult cult = _cultsService.CreateCult(cultData);
      return Ok(cult);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Cult>> GetAllCults()
  {
    try
    {
      List<Cult> cults = _cultsService.GetAllCults();
      return Ok(cults);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{cultId}")]
  public ActionResult<Cult> GetCultById(int cultId)
  {
    try
    {
      Cult cult = _cultsService.GetCultById(cultId);
      return Ok(cult);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{cultId}/cultMembers")]
  public ActionResult<List<Cultist>> GetCultistsByCultId(int cultId)
  {
    try
    {
      List<Cultist> cultists = _cultMembersService.GetCultistsByCultId(cultId);
      return Ok(cultists);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}

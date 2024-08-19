namespace insta_cult.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CultsController : ControllerBase
{
  private readonly CultsService _cultsService;
  private readonly Auth0Provider _auth0Provider;

  public CultsController(CultsService cultsService, Auth0Provider auth0Provider)
  {
    _cultsService = cultsService;
    _auth0Provider = auth0Provider;
  }
}

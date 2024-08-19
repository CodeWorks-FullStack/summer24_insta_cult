
namespace insta_cult.Services;

public class CultsService
{

  private readonly CultsRepository _repository;

  public CultsService(CultsRepository repository)
  {
    _repository = repository;
  }

  internal Cult CreateCult(Cult cultData)
  {
    Cult cult = _repository.CreateCult(cultData);
    return cult;
  }
}

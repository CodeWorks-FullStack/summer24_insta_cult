namespace insta_cult.Services;

public class CultsService
{

  private readonly CultsRepository _repository;

  public CultsService(CultsRepository repository)
  {
    _repository = repository;
  }
}



using Microsoft.AspNetCore.Http.HttpResults;

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

  internal List<Cult> GetAllCults()
  {
    List<Cult> cults = _repository.GetAllCults();
    return cults;
  }

  internal Cult GetCultById(int cultId)
  {
    Cult cult = _repository.GetCultById(cultId);

    if (cult == null)
    {
      throw new Exception($"No cult found with the id of {cultId}");
    }

    return cult;
  }
}

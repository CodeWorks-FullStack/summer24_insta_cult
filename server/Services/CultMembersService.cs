
namespace insta_cult.Services;

public class CultMembersService
{
  private readonly CultMembersRepository _repository;

  public CultMembersService(CultMembersRepository repository)
  {
    _repository = repository;
  }

  internal Cultist CreateCultMember(CultMember cultMemberData)
  {
    Cultist cultist = _repository.CreateCultMember(cultMemberData);
    return cultist;
  }
}
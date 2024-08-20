
namespace insta_cult.Services;

public class CultMembersService
{
  private readonly CultMembersRepository _repository;

  public CultMembersService(CultMembersRepository repository)
  {
    _repository = repository;
  }

  internal CultMember CreateCultMember(CultMember cultMemberData)
  {
    CultMember cultMember = _repository.CreateCultMember(cultMemberData);
    return cultMember;
  }
}
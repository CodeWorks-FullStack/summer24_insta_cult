


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

  internal List<Cultist> GetCultistsByCultId(int cultId)
  {
    List<Cultist> cultists = _repository.GetCultistsByCultId(cultId);
    return cultists;
  }

  internal List<JoinedCult> GetMyJoinedCults(string userId)
  {
    List<JoinedCult> joinedCults = _repository.GetMyJoinedCults(userId);
    return joinedCults;
  }
}
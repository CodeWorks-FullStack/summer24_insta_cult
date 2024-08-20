




namespace insta_cult.Services;

public class CultMembersService
{
  private readonly CultMembersRepository _repository;
  private readonly CultsService _cultsService;

  public CultMembersService(CultMembersRepository repository, CultsService cultsService)
  {
    _repository = repository;
    _cultsService = cultsService;
  }

  internal Cultist CreateCultMember(CultMember cultMemberData)
  {
    Cultist cultist = _repository.CreateCultMember(cultMemberData);
    return cultist;
  }

  internal string DestroyCultMember(int cultMemberId, string userId)
  {
    CultMember cultMember = GetCultMemberById(cultMemberId);

    Cult cult = _cultsService.GetCultById(cultMember.CultId);

    if (cult.LeaderId != userId)
    {
      throw new Exception($"The great leader {cult.Leader.Name} wants to see you in the abandoned shed behind the farm");
    }

    _repository.DestroyCultMember(cultMemberId);

    return "Cult member has been dealt with";
  }

  private CultMember GetCultMemberById(int cultMemberId)
  {
    CultMember cultMember = _repository.GetCultMemberById(cultMemberId);
    if (cultMember == null)
    {
      throw new Exception($"No cult member found with the id of {cultMemberId}");
    }
    return cultMember;
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



namespace insta_cult.Repositories;

public class CultMembersRepository
{
  private readonly IDbConnection _db;

  public CultMembersRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Cultist CreateCultMember(CultMember cultMemberData)
  {
    string sql = @"
    INSERT INTO
    cultMembers(accountId, cultId)
    VALUES(@AccountId, @CultId);

    SELECT
    cultMembers.*,
    accounts.*
    FROM cultMembers
    JOIN accounts ON accounts.id = cultMembers.accountId
    WHERE cultMembers.id = LAST_INSERT_ID();";

    Cultist cultist = _db.Query<CultMember, Cultist, Cultist>(sql, (cultMember, cultist) =>
    {
      cultist.CultMemberId = cultMember.Id;
      cultist.CultId = cultMember.CultId;
      cultist.AccountId = cultMember.AccountId;
      return cultist;
    }, cultMemberData).FirstOrDefault();
    return cultist;
  }

  internal List<Cultist> GetCultistsByCultId(int cultId)
  {
    string sql = @"
    SELECT
    cultMembers.*,
    accounts.*
    FROM cultMembers
    JOIN accounts ON accounts.id = cultMembers.accountId
    WHERE cultMembers.cultId = @cultId;";

    List<Cultist> cultists = _db.Query<CultMember, Cultist, Cultist>(sql, (cultMember, cultist) =>
    {
      cultist.CultMemberId = cultMember.Id;
      cultist.CultId = cultMember.CultId;
      cultist.AccountId = cultMember.AccountId;
      return cultist;
      //   {cultId: 8}
    }, new { cultId }).ToList();
    return cultists;
  }

  internal List<JoinedCult> GetMyJoinedCults(string userId)
  {
    string sql = @"
    SELECT
    cultMembers.*,
    cults.*
    FROM cultMembers
    JOIN cults ON cults.id = cultMembers.cultId
    WHERE cultMembers.accountId = @userId;";

    List<JoinedCult> joinedCults = _db.Query<CultMember, JoinedCult, JoinedCult>(sql,
     (cultMember, cult) =>
     {
       cult.CultMemberId = cultMember.Id;
       cult.CultId = cultMember.CultId;
       cult.AccountId = cultMember.AccountId;
       return cult;
     }, new { userId }).ToList();

    return joinedCults;
  }
}





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

  internal void DestroyCultMember(int cultMemberId)
  {
    string sql = "DELETE FROM cultMembers WHERE id = @cultMemberId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { cultMemberId });

    if (rowsAffected == 0)
    {
      throw new Exception("DELETE FAILED. CHECK YOUR SQL MANUAL AND YOUR SQL SYNTAX FOR THE ERROR");
    }
    if (rowsAffected > 1)
    {
      throw new Exception("DELETED MORE THAN ONE ROW. CHECK YOUR SQL MANUAL AND YOUR SQL SYNTAX FOR THE ERROR");
    }
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

  internal CultMember GetCultMemberById(int cultMemberId)
  {
    string sql = "SELECT * FROM cultMembers WHERE id = @cultMemberId;";

    CultMember cultMember = _db.Query<CultMember>(sql, new { cultMemberId }).FirstOrDefault();

    return cultMember;
  }

  internal List<JoinedCult> GetMyJoinedCults(string userId)
  {
    string sql = @"
    SELECT
    cultMembers.*,
    cults.*,
    accounts.*
    FROM cultMembers
    JOIN cults ON cults.id = cultMembers.cultId
    JOIN accounts ON accounts.id = cults.leaderId 
    WHERE cultMembers.accountId = @userId;";

    List<JoinedCult> joinedCults = _db.Query<CultMember, JoinedCult, Profile, JoinedCult>(sql,
     (cultMember, cult, leader) =>
     {
       cult.CultMemberId = cultMember.Id;
       cult.CultId = cultMember.CultId;
       cult.AccountId = cultMember.AccountId;
       cult.Leader = leader;
       return cult;
     }, new { userId }).ToList();

    return joinedCults;
  }
}
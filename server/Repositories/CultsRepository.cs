


namespace insta_cult.Repositories;

public class CultsRepository
{
  private readonly IDbConnection _db;

  public CultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Cult CreateCult(Cult cultData)
  {
    string sql = @"
    INSERT INTO
    cults (name, fee, description, coverImg, leaderId)
    VALUES(@Name, @Fee, @Description, @CoverImg, @LeaderId);

    SELECT
    cults.*,
    accounts.*
    FROM cults
    JOIN accounts ON accounts.id = cults.leaderId
    WHERE cults.id = LAST_INSERT_ID();";

    Cult cult = _db.Query<Cult, Profile, Cult>(sql, JoinLeader, cultData).FirstOrDefault();
    return cult;
  }

  internal List<Cult> GetAllCults()
  {
    string sql = @"
    SELECT
    cults.*,
    accounts.*
    FROM cults
    JOIN accounts ON accounts.id = cults.leaderId;";

    List<Cult> cults = _db.Query<Cult, Profile, Cult>(sql, JoinLeader).ToList();

    return cults;
  }

  internal Cult GetCultById(int cultId)
  {
    string sql = @"
    SELECT
    cults.*,
    accounts.*
    FROM cults
    JOIN accounts ON accounts.id = cults.leaderId
    WHERE cults.id = @cultId;";

    Cult cult = _db.Query<Cult, Profile, Cult>(sql, JoinLeader, new { cultId }).FirstOrDefault();

    return cult;
  }

  private Cult JoinLeader(Cult cult, Profile profile)
  {
    cult.Leader = profile;
    return cult;
  }
}


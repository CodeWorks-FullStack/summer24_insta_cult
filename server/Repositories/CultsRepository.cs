
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

    SELECT * FROM cults WHERE id = LAST_INSERT_ID();";

    Cult cult = _db.Query<Cult>(sql, cultData).FirstOrDefault();
    return cult;
  }
}


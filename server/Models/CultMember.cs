namespace insta_cult.Models;

public class CultMember : RepoItem<int>
{
  public int CultId { get; set; }
  public string AccountId { get; set; }
}

public class Cultist : Profile
{
  public int CultId { get; set; }
  public int CultMemberId { get; set; } // The ID of the many-to-many
  public string AccountId { get; set; } // The ID of the account, same value as Id of profile
}
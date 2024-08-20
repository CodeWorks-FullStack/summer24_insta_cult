namespace insta_cult.Models;

public class Cult : RepoItem<int>
{
  // ID
  public string Name { get; set; }
  public double Fee { get; set; }
  public string Description { get; set; }
  public string CoverImg { get; set; }
  public string LeaderId { get; set; }
  public Profile Leader { get; set; }
}

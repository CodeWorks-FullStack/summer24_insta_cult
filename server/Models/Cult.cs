namespace insta_cult.Models;

public class Cult : RepoItem<int>
{
  public string Name { get; set; }
  public float Fee { get; set; }
  public string Description { get; set; }
  public string CoverImg { get; set; }
  public string LeaderId { get; set; }
}

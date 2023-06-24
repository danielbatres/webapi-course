namespace webapi_course.Models;

public class Category
{
  public Guid CategoryId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public int Weight { get; set; }
  [System.Text.Json.Serialization.JsonIgnore]
  public virtual ICollection<Assignment> Assignments { get; set; }
}
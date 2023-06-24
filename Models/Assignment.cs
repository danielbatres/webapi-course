namespace webapi_course.Models;

public class Assignment
{
  public Guid AssignmentId { get; set; }
  public Guid CategoryId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public Priority AssignmentPriority { get; set; }
  public DateTime CreationDateTime { get; set; }
  public virtual Category Category { get; set; }
  public string Summary { get; set; }
}

public enum Priority
{
  Low,
  Mid,
  High
}
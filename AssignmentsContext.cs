using Microsoft.EntityFrameworkCore;
using webapi_course.Models;

namespace webapi_course;

public class AssignmentsContext : DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Assignment> Assignments { get; set; }

  public AssignmentsContext(DbContextOptions<AssignmentsContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Category> CategoriesInit = new List<Category>();

    CategoriesInit.Add(new Category()
    {
      CategoryId = Guid.Parse("824d3c0a-900f-4069-a80f-ade59940e020"),
      Name = "Pending activities",
      Weight = 20
    });

    CategoriesInit.Add(new Category()
    {
      CategoryId = Guid.Parse("824d3c0a-900f-4069-a80f-ade59940e022"),
      Name = "Personal activities",
      Weight = 50
    });

    modelBuilder.Entity<Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(p => p.CategoryId);
      category.Property(p => p.Name).IsRequired().HasMaxLength(150);
      category.Property(p => p.Description).IsRequired(false);
      category.Property(p => p.Weight);
      category.HasData(CategoriesInit);
    });

    List<Assignment> AssignmentInit = new List<Assignment>();

    AssignmentInit.Add(new Assignment()
    {
      AssignmentId = Guid.Parse("4da3fc64-ee46-4654-9387-f2ea2fe4116b"),
      CategoryId = Guid.Parse("824d3c0a-900f-4069-a80f-ade59940e020"),
      AssignmentPriority = Priority.Mid,
      Title = "Payment of public services",
      CreationDateTime = DateTime.Now
    });

    AssignmentInit.Add(new Assignment()
    {
      AssignmentId = Guid.Parse("0bf7dc7e-930c-45b4-b957-d9b6e9f5a175"),
      CategoryId = Guid.Parse("824d3c0a-900f-4069-a80f-ade59940e022"),
      AssignmentPriority = Priority.Low,
      Title = "Finish watching movie on netflix",
      CreationDateTime = DateTime.Now
    });

    modelBuilder.Entity<Assignment>(assignment =>
    {
      assignment.ToTable("Assignment");
      assignment.HasKey(p => p.AssignmentId);
      assignment.HasOne(p => p.Category).WithMany(p => p.Assignments).HasForeignKey(p => p.CategoryId);
      assignment.Property(p => p.Title).IsRequired().HasMaxLength(200);
      assignment.Property(p => p.Description).IsRequired(false);
      assignment.Property(p => p.AssignmentPriority);
      assignment.Property(p => p.CreationDateTime);
      assignment.Ignore(p => p.Summary);
      assignment.HasData(AssignmentInit);
    });
  }
}
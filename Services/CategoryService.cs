using webapi_course.Models;

namespace webapi_course.Services;

public class CategoryService : ICategoryService {
  AssignmentsContext context;

  public CategoryService(AssignmentsContext dbContext) {
    context = dbContext;
  }

  public IEnumerable<Category> Get() {
    return context.Categories;
  }

  public async Task Save(Category category) { 
    context.Add(category);
    await context.SaveChangesAsync();
  }

  public async Task Update(Guid id, Category category) {
    var ActualCategory = context.Categories.Find(id);

    if (ActualCategory != null) {
      ActualCategory.Name = category.Name;
      ActualCategory.Description = category.Description;
      ActualCategory.Weight = category.Weight;

      await context.SaveChangesAsync();
    }
  }

  public async Task Delete(Guid id) {
    var ActualCategory = context.Categories.Find(id);

    if (ActualCategory != null) {
      context.Remove(ActualCategory);
      await context.SaveChangesAsync();
    }
  }
}

public interface ICategoryService {
  IEnumerable<Category> Get();
  Task Save(Category category);
  Task Update(Guid id, Category category);
  Task Delete(Guid id);
}
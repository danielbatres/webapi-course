using webapi_course.Models;

namespace webapi_course.Services;

public class AssignmentService : IAssignmentService {
  AssignmentsContext context;

  public AssignmentService(AssignmentsContext dbContext) {
    context = dbContext;
  }

  public IEnumerable<Assignment> Get() {
    return context.Assignments;
  }
}

public interface IAssignmentService {
  IEnumerable<Assignment> Get();
}
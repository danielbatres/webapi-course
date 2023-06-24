using Microsoft.AspNetCore.Mvc;

namespace webapi_course.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase {
  IHelloWorldService helloWorldService;
  protected readonly AssignmentsContext context;

  public HelloWorldController(IHelloWorldService helloWorld, AssignmentsContext dbContext) { 
    helloWorldService = helloWorld;
    context = dbContext;
  }

  [HttpGet]
  public IActionResult Get() {
    return Ok(helloWorldService.GetHelloWorld());
  }

  [HttpGet]
  [Route("createdb")]
  public IActionResult CreateDatabase() {
    context.Database.EnsureCreated();

    return Ok();
  }
}
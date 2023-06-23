using Microsoft.AspNetCore.Mvc;

namespace webapi_course.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase {
  IHelloWorldService helloWorldService;

  public HelloWorldController(IHelloWorldService helloWorld) { 
    helloWorldService = helloWorld;
  }

  public IActionResult Get() {
    return Ok(helloWorldService.GetHelloWorld());
  }
}
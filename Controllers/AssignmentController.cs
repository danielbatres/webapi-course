using Microsoft.AspNetCore.Mvc;
using webapi_course.Models;
using webapi_course.Services;

namespace webapi_course.Controllers;

[Route("api/[controller]")]
public class AssignmentController : ControllerBase {
  IAssignmentService assignmentService; ///

  public AssignmentController(IAssignmentService service) { 
    assignmentService = service;
  }

  [HttpGet]
  public IActionResult Get() {
    return Ok(assignmentService.Get());
  }
}
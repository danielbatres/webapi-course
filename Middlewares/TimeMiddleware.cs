public class TimeMiddleware {
  readonly RequestDelegate Next;

  public TimeMiddleware(RequestDelegate nextRquest) {
    Next = nextRquest;
  }

  public async Task Invoke(HttpContext context) {
    await Next(context);
    
    if (context.Request.Query.Any(p => p.Key == "time")) {
      await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
    }
  }
}

public static class TimeMiddlewareExtension
{
  public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<TimeMiddleware>();
  }
}
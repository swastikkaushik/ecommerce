public class ExceptionMiddleware 
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }catch(Exception ex)
        {
            switch(ex){
            case NotFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                break;
            case BadRequestException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            case InternalServerErrorException:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
            }
await context.Response.WriteAsJsonAsync(new
{
    success = false,
    message = ex.Message,
    statusCode = context.Response.StatusCode,
    timestamp = DateTime.UtcNow
});        }

       
    }
}
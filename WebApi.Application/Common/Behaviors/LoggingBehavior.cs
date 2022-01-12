using MediatR;
using Serilog;
using WebApi.Application.Interfaces;

namespace WebApi.Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest
    : IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehavior(ICurrentUserService currentUserService) =>
        _currentUserService = currentUserService;

    public async Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId;

        Log.Information("WebApi Request: {Name} {@UserId} {@Request}",
            requestName, userId, request);

        var response = await next();

        return response;
    }
}
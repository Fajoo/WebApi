namespace WebApi.Application.Interfaces;

/// <summary>
/// The interface describing the service for obtaining user IDs
/// </summary>
public interface ICurrentUserService
{
    Guid UserId { get; }
}
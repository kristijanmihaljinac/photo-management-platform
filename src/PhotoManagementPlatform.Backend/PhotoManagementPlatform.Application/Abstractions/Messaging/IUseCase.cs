using Common.Shared;
using MediatR;

namespace PhotoManagementPlatform.Application.Abstractions.Messaging;

public interface IUseCase<TResponse> : IRequest<Result<TResponse>>
{
}

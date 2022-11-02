using Common.Shared;
using MediatR;

namespace PhotoManagementPlatform.Application.Abstractions.Messaging;

public interface IUseCaseHandler<TUseCase, TResponse>
    : IRequestHandler<TUseCase, Result<TResponse>>
    where TUseCase : IUseCase<TResponse>
{
}

public interface IUseCaseHandler<TUseCase> : IRequestHandler<TUseCase, Result>
    where TUseCase : IUseCase
{
}
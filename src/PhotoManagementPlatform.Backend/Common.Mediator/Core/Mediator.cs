using Common.Mediator.Middleware;
using System.Reflection;

namespace Common.Mediator.Core
{
    public class Mediator : IMediator
    {
        private readonly IServiceFactory _serviceFactory;

        public Mediator(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public Task<TResponse> HandleAsync<TResponse>(IMessage<TResponse> message,
                                                        IMediationContext mediationContext = default(MediationContext), CancellationToken cancellationToken = default(CancellationToken))
        {
            if (mediationContext == null)
            {
                mediationContext = MediationContext.Default;
            }

            var targetHandler = GetTargetHandler<TResponse>(message.GetType());

            var result = InvokeInstanceAsync(_serviceFactory.GetInstance(targetHandler), message, targetHandler, mediationContext, cancellationToken);

            return result;
        }

        private Type GetTargetHandler<TResponse>(Type targetType)
        {
            return typeof(IMessageProcessor<,>).MakeGenericType(targetType, typeof(TResponse));
        }

        private Task<TResponse> InvokeInstanceAsync<TResponse>(object instance, IMessage<TResponse> message, Type targetHandler,
                                                                IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var method = instance.GetType()
                .GetTypeInfo()
                .GetMethod(nameof(IMessageProcessor<IMessage<TResponse>, TResponse>.HandleAsync));

            if (method == null)
            {
                throw new ArgumentException($"{instance.GetType().Name} is not a known {targetHandler.Name}",
                    instance.GetType().FullName);
            }

            return (Task<TResponse>)method.Invoke(instance, new object[] { message, mediationContext, cancellationToken });
        }
    }

}

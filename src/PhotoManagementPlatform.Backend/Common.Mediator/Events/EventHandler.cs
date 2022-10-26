﻿using Common.Mediator.Core;

namespace Common.Mediator.Events
{
    public abstract class EventHandler<TEvent> : IEventHandler<TEvent> where TEvent : IMessage<Unit>
    {
        public async Task<Unit> HandleAsync(TEvent message, IMediationContext mediationContext,
            CancellationToken cancellationToken)
        {
            await HandleEventAsync(message, mediationContext, cancellationToken);
            return Unit.Result;
        }

        protected abstract Task HandleEventAsync(TEvent @event, IMediationContext mediationContext,
            CancellationToken cancellationToken);
    }
}

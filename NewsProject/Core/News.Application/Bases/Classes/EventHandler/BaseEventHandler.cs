using News.Domain.Comman;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Bases.Interfaces.DI;

namespace News.Application.Bases.Classes.EventHandler
{
    public class BaseEventHandler : ITransient
    {
        private readonly IBaseRule<EntityBase> _rule;

        public BaseEventHandler(IBaseRule<EntityBase> rule)
          => _rule = rule;

        public void SubscribeEventHandler()
        => DeleteCommandHandler.OnEntityDelete += OnEntityDelete;

        private void OnEntityDelete(EntityBase entity)
        => _rule.EntityNotFound(entity);

        public void UnsubscribeFromEvents()
        => DeleteCommandHandler.OnEntityDelete -= OnEntityDelete;

        ~BaseEventHandler()
        => UnsubscribeFromEvents();
    }
}
using News.Domain.Comman;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Rules;

namespace News.Application.Bases.Classes.EventHandler
{
    internal abstract class BaseEventHandler
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
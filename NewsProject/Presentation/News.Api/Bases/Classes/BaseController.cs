using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace News.Api.Bases.Classes
{
    //custom security. controller-a  dusmeden role-lari yoxlamaq lazimdir .[authorize] yazmadan
    public abstract class BaseController : ControllerBase
    {
        private protected readonly IMediator mediator;

        public BaseController(IMediator mediator) => this.mediator = mediator;

        private protected virtual async Task<IActionResult> ExecuteCommand<T>(Action action, Func<T> returnMethod)
             where T : IActionResult
        {
            action?.Invoke();
            return returnMethod.Invoke();
        }
    }
}
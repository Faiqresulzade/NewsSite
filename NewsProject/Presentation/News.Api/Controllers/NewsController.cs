using Microsoft.AspNetCore.Mvc;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using NewsEntity = News.Domain.Entities.News;

namespace News.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.GetReadRepository<NewsEntity>().GetAllAsync(x => x.IsDeleted == false));
        }
    }
}
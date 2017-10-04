using System.Web.Http;
using Elf.Core.Uow;

namespace Elf.Api.Api
{
    public abstract class BaseApiController:ApiController
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        protected BaseApiController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
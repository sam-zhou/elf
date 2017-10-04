using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Elf.Core.Models;
using Elf.Core.Uow;

namespace Elf.Api.Api
{
    public interface IElfController
    {
        

    }

    [AllowAnonymous]
    public class ElfController : BaseApiController, IElfController
    {

        public ElfController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
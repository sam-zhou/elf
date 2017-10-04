using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Elf.Core.Models;
using Elf.Core.Uow;
using Elf.ServiceApp.Api;

namespace Elf.ServiceApp.Api
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

        public async Task<IEnumerable<Core.Models.Elf>> GetElfsAsync()
        {
            var output = new List<Core.Models.Elf>();

            return output;
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
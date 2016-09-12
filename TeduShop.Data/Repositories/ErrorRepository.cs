using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IErorrRepository : IRepository<Error>
    {
    }

    public class ErorrRepository : RepositoryBase<Error>, IErorrRepository
    {
        public ErorrRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}

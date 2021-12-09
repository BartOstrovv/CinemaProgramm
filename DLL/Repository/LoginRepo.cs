using DLL.Context;
using DLL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class LoginRepo : BaseRepository<LoginData>
    {
        public LoginRepo(CinemaContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<LoginData>> GetAllWithEmployee() =>
            await this.Entities.Include(x => x.Employee).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<LoginData>> FindByConditionWithEmployeeAsync(Expression<Func<LoginData, bool>> predicat) =>
            await this.Entities.Where(predicat).Include(x => x.Employee).ToListAsync().ConfigureAwait(false);
    }
}

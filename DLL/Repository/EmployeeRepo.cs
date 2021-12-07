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
    public class EmployeeRepo : BaseRepository<Employee>
    {
        public EmployeeRepo(CinemaContext context) : base(context) 
        {
        }
        //GetData
        public async Task<IReadOnlyCollection<Employee>> GetEmployeesWithLoginsAsync() =>
            await this.Entities.Include(x => x.UserInfo).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Employee>> GetEmployeesWithTicketsAsync() =>
            await this.Entities.Include(x => x.Tickets).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Employee>> GetEmployeesWithAllIncludedAsync() =>
            await this.Entities.Include(x => x.UserInfo).Include(x => x.Tickets).ToListAsync().ConfigureAwait(false);
        //FindData
        public async Task<IReadOnlyCollection<Employee>> FindByConditionWithTicketsAsync(Expression<Func<Employee, bool>> predicat) =>
            await this.Entities.Include(x => x.Tickets).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Employee>> FindByConditionWithLoginAsync(Expression<Func<Employee, bool>> predicat) =>
            await this.Entities.Include(x => x.UserInfo).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Employee>> FindByConditionWithAllIncludedAsync(Expression<Func<Employee, bool>> predicat) =>
            await this.Entities.Include(x => x.UserInfo).Include(x => x.Tickets).Where(predicat).ToListAsync().ConfigureAwait(false);
    }
}

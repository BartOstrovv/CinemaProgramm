using DLL.Model;
using DLL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class TicketRepo : BaseRepository<Ticket>
    {
        public TicketRepo(CinemaContext context) : base(context)
        {
        }
        //GetData
        public async Task<IReadOnlyCollection<Ticket>> GetSessionsWithSessionsAsync() =>
            await this.Entities.Include(x => x.Session).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Ticket>> GetSessionsWithPlacesAsync() =>
            await this.Entities.Include(x => x.Place).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Ticket>> GetSessionsWithEmployeesAsync() =>
            await this.Entities.Include(x => x.Employee).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Ticket>> GetSessionsWithAllIncludedAsync() =>
            await this.Entities.Include(x => x.Session).Include(x => x.Employee).Include(x => x.Place).ToListAsync().ConfigureAwait(false);
        //FindData
        public async Task<IReadOnlyCollection<Ticket>> FindByConditionWithSessionsAsync(Expression<Func<Ticket, bool>> predicat) =>
            await this.Entities.Where(predicat).Include(x => x.Session).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Ticket>> FindByConditionWithPlacesAsync(Expression<Func<Ticket, bool>> predicat) =>
            await this.Entities.Where(predicat).Include(x => x.Place).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Ticket>> FindByConditionWithEmployeesAsync(Expression<Func<Ticket, bool>> predicat) =>
            await this.Entities.Where(predicat).Include(x => x.Employee).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Ticket>> FindByConditionWithAllIncludedAsync(Expression<Func<Ticket, bool>> predicat) =>
            await this.Entities.Where(predicat).Include(x => x.Session).Include(x => x.Employee).Include(x => x.Place).ToListAsync().ConfigureAwait(false);
    }
}

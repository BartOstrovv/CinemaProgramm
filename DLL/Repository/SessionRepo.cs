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
    public class SessionRepo : BaseRepository<Session>
    {
        public SessionRepo(CinemaContext context) : base(context)
        {
        }
        //GetData
        public async Task<IReadOnlyCollection<Session>> GetSessionsWithFilmsAsync() =>
            await this.Entities.Include(x => x.Film).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Session>> GetSessionsWithHallsAsync() =>
            await this.Entities.Include(x => x.Hall).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Session>> GetSessionsWithTicketsAsync() =>
            await this.Entities.Include(x => x.Tickets).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Session>> GetSessionsWithAllIncludedAsync() =>
             await this.Entities.Include(x => x.Film).Include(x => x.Hall).Include(x => x.Tickets).ToListAsync().ConfigureAwait(false);
        //FindData
        public async Task<IReadOnlyCollection<Session>> FindByConditionWithFilmsAsync(Expression<Func<Session, bool>> predicat) =>
            await this.Entities.Include(x => x.Film).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Session>> FindByConditionWithHallsAsync(Expression<Func<Session, bool>> predicat) =>
            await this.Entities.Include(x => x.Hall).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Session>> FindByConditionWithTicketsAsync(Expression<Func<Session, bool>> predicat) =>
            await this.Entities.Include(x => x.Tickets).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Session>> FindByConditionWithAllIncludedAsync(Expression<Func<Session, bool>> predicat) =>
            await this.Entities.Include(x => x.Film).Include(x => x.Hall).Include(x => x.Tickets).Where(predicat).ToListAsync().ConfigureAwait(false);
    }
}

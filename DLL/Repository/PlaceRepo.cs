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
    public class PlaceRepo : BaseRepository<Place>
    {
        public PlaceRepo(CinemaContext context) : base(context)
        {
        }
        //GetData
        public async Task<IReadOnlyCollection<Place>> GetAllWithHallsAsync() =>
            await this.Entities.Include(x => x.Hall).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Place>> GetAllWithTicketsAsync() =>
            await this.Entities.Include(x => x.Ticket).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Place>> GetAllWithAllIncludedAsync() =>
            await this.Entities.Include(x => x.Ticket).Include(x => x.Hall).ToListAsync().ConfigureAwait(false);
        //FindData
        public async Task<IReadOnlyCollection<Place>> FindByConditionWithHallsAsync(Expression<Func<Place, bool>> predicat) =>
            await this.Entities.Where(predicat).Include(x => x.Hall).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Place>> FindByConditionWithTicketsAsync(Expression<Func<Place, bool>> predicat) =>
            await this.Entities.Where(predicat).Include(x => x.Ticket).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Place>> FindByConditionWithAllIncludedAsync(Expression<Func<Place, bool>> predicat) =>
            await this.Entities.Where(predicat).Include(x => x.Hall).Include(x=>x.Ticket).Where(predicat).ToListAsync().ConfigureAwait(false);
    }
}

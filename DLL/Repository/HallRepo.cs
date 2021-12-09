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
    public class HallRepo : BaseRepository<Hall>
    {
        public HallRepo(CinemaContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Hall>> GetAllWithPlacesAsync() =>
            await _context.Halls.Include(x => x.Places).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Hall>> FindByConditionWithPlacesAsync(Expression<Func<Hall, bool>> predicat) =>
            await _context.Halls.Where(predicat).Include(x=>x.Places).ToListAsync().ConfigureAwait(false);
    }
}

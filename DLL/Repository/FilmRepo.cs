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
    public class FilmRepo : BaseRepository<Film>
    {
        public FilmRepo(CinemaContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Film>> GetAllWithSessionsAsync() =>
            await _context.Films.Include(x => x.Sessions).ToListAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Film>> FindByConditionWithSessionAsync(Expression<Func<Film, bool>> predicat) =>
            await _context.Films.Where(predicat).Include(x => x.Sessions).ToListAsync().ConfigureAwait(false);
    }
}

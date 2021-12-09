using DLL.Repository;
using DLL.Model;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace BLL.Service
{
    public class SessionService
    {
        private readonly SessionRepo _sessionRepo;
        private readonly FilmRepo _filmRepo;
        public SessionService(SessionRepo sessRepo, FilmRepo filmRepo)
        {
            _sessionRepo = sessRepo;
            _filmRepo = filmRepo;
        }

        public async Task<IReadOnlyCollection<Session>> GetAllSessionAsync() =>
            await _sessionRepo.GetSessionsWithAllIncludedAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Film>> GetAllFilmsAsync() =>
            await _filmRepo.GetAllWithSessionsAsync().ConfigureAwait(false);

        public async Task AddNewSesionAsync(Film film, Session session)
        {
            await _filmRepo.CreateAsync(film).ConfigureAwait(false);
            
            var f = (await _filmRepo.FindByConditionAsync
                (x => x.Description == film.Description && x.Duration == film.Duration && x.Genre == x.Genre && x.Price == film.Price && x.Title == film.Title))?.First();
            session.Film = f;
            await _sessionRepo.CreateAsync(session);
        }

        public async Task ModifySessionAsync(Session session)
        {
           var s = (await _sessionRepo.FindByConditionWithAllIncludedAsync(x => x.Id == session.Id).ConfigureAwait(false))?.First();
            if (s == null)
                return;
           await _sessionRepo.UpdateAsync(session);
        }
    }
}

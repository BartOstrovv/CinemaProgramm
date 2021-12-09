using DLL.Repository;
using DLL.Model;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace BLL.Service
{
    public class TicketService
    {
        private readonly TicketRepo _ticketRepo;
        public TicketService(TicketRepo ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        public async Task<IReadOnlyCollection<Ticket>> GetTicketsAsync() =>
            await _ticketRepo.GetAllAsync();

        public async Task AddNewTicketAsync(Ticket ticket) =>
            await _ticketRepo.CreateAsync(ticket).ConfigureAwait(false);

        public async Task ModifyTicketAsync(Ticket ticket)
        {
            var t = (await _ticketRepo.FindByConditionWithAllIncludedAsync(x => x.Id == ticket.Id).ConfigureAwait(false))?.First();
            if (t == null)
                return;
            await _ticketRepo.UpdateAsync(ticket);
        }
    }
}

using SkillsTest.Domain.Helpers;
using SkillsTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkillsTest.Domain.Services
{
    public class TicketService : BaseService<DefaultDbContext, Ticket>, ITicketService
    {
        public Page<Ticket> Get(bool decending, string propertyName, int currentPage, int pageSize)
        {
            return this.All()
                .OrderBy(propertyName, decending)
                .ToPage(currentPage, pageSize, decending, propertyName);
        }

        public Ticket GetWithComments(Guid id)
        {
            return this.Context.Tickets
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void Add(Ticket entity)
        {
            this._Add(entity);
            this._SaveChanges();
        }

        public void Update(Ticket entity)
        {
            this._Update(entity);
            this._SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = this.All().FirstOrDefault(a => a.Id == id);
            this._Delete(entity);
            this._SaveChanges();
        }
    }

    public interface ITicketService : IBaseService<Ticket>
    {
        Page<Ticket> Get(bool decending, string propertyName, int currentPage, int pageSize);
        Ticket GetWithComments(Guid id);
        void Add(Ticket entity);
        void Update(Ticket entity);
        void Delete(Guid id);
    }
}

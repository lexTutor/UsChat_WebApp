using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Us.DataAccess;
using UsApplication.Core.Repository;
using UsApplication.Models;

namespace UsApplication.Implementation.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        private readonly DataContext _ctx;
        public MessageRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public async Task<ICollection<Message>> GetMessagesBetweenConnections(string fromId, string toId)
        {
            var result = await _ctx.Message
                .Where(msg => (msg.UserFromId == fromId || msg.UserToId == fromId)
                             && (msg.UserFromId == toId || msg.UserToId == toId))
                .ToListAsync();

            return result;
        }
    }
}

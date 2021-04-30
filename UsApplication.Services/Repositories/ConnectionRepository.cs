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
    public class ConnectionRepository: GenericRepository<Connection>, IConnectionRepository
    {
        private readonly DataContext _ctx;
        public ConnectionRepository(DataContext ctx): base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<Connection>> GetConnections(string Id)
        {
            var result = await _ctx.Connection.Where(conn => conn.UserId_To == Id || conn.UserId_From == Id).ToListAsync();
            return result;
        }
    }
}

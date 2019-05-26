using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isen.DotNet.Library.Context;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Isen.DotNet.Library.Repositories.Db
{
    public class DbContextContractRepository : 
        BaseDbRepository<Contract>,
        IContractRepository
    {
        public DbContextContractRepository(
            ApplicationDbContext dbContext) : 
            base(dbContext)
        {
        }

        public override IQueryable<Contract> Includes(IQueryable<Contract> includes)
        {
            var inc = base.Includes(includes);
            inc = inc.Include(e => e.PlayerContract)
                .Include(e => e.ClubContract);
            return inc;
        }
    }
}
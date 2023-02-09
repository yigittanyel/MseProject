using MSE.DataAccess.Context;
using MSE.DataAccess.Repositories.Abstract;
using MSE.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.DataAccess.Repositories.Concrete
{
    public class WorkStationRepository : GenericRepository<WorkStation>, IWorkStationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WorkStationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

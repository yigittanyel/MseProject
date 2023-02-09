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
    public class AlarmRepository : GenericRepository<Alarm>, IAlarmRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AlarmRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

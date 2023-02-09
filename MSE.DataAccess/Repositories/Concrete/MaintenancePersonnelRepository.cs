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
    public class MaintenancePersonnelRepository : GenericRepository<MaintenancePersonnel>, IMaintenancePersonnelRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MaintenancePersonnelRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

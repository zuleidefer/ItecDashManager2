using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Data.Context;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;

namespace ItecDashManager.Data.Repositories;

    public class DashboardRepository : IDashboardRepository
    {
        public DashboardRepository (DataContext context)
        {
            
        }
    }


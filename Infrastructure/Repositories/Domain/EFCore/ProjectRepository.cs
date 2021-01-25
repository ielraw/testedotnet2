﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.DBConfiguration.EFCore;
using Infrastructure.Interfaces.Repositories.Domain; 
 using Microsoft.Extensions.Logging;
using Infrastructure.Repositories.Standard.EFCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Infrastructure.Repositories.Domain.EFCore
{
    public class ProjectRepository : DomainRepository<Project>,
                                      IProjectRepository
    {
        public ProjectRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
﻿using HW4._4_EntityFreamwork.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Services
{
    public class DbContextWrapper<T> : IDbContextWrapper<T>
        where T : DbContext
    {
        private readonly T _dbContext;
        public DbContextWrapper(
        IDbContextFactory<T> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }
        public T DbContext => _dbContext;

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}

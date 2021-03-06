﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList.Domain.Entities.Infrastructure
{
    public class DatabaseResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public DatabaseResult()
        {
            Success = false;
            Message = "";
            Exception = null;
        }
    }

    public class DatabaseOneResult<TEntity> : DatabaseResult where TEntity : IBaseEntity
    {
        public TEntity Entity { get; set; }
    }

    public class DatabaseManyResult<TEntity> : DatabaseResult where TEntity : IBaseEntity
    {
        public List<TEntity> Entities { get; set; }
    }
}

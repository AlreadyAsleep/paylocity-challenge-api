using PaylocityCodingChallenge.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityCodingChallenge.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly bool _inMemory;

        public BaseRepository(bool inMemory = false)
        {
            _inMemory = inMemory;
        }

        public EmployeeDbContext GetDbContext()
        {
            return new EmployeeDbContext(_inMemory);
        }
    }
}

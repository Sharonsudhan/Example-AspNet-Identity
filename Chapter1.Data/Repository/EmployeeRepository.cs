using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter1.Data.Infrastructure;
using Chapter1.models;

namespace Chapter1.Data.Repository
{
    public class EmployeeRepository: RepositoryBase<Employee>,IEmployeeRepository
    {

        public EmployeeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }


    }

     public interface IEmployeeRepository : IRepository<Employee>
    {    

    }
}
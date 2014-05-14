using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter1.Services.Interfaces;
using Chapter1.models;
using Chapter1.Data.Repository;
using Chapter1.Data.Infrastructure;

namespace Chapter1.Services.Implementation
{
    public class ViewEmployees : IViewEmployees
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;

        public ViewEmployees(IEmployeeRepository _employeeRepository, IUnitOfWork _unitOfWork)
        {
            this.employeeRepository = _employeeRepository;
            this.unitOfWork = _unitOfWork;

        }
        public IEnumerable<Employee> viewemployee()
        
        {
                  var employees = employeeRepository.GetAll().OrderByDescending(g=>g.Id).ToList();
                  return employees;       
        }
        
    }
}

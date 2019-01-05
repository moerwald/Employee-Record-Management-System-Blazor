using ServerSideSPA.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerSideSPA.App.Services
{
    public class EmployeeService
    {
        private DataAccess.EmployeeDataAccessLayer al = new DataAccess.EmployeeDataAccessLayer();

        public Task<List<Employee>> GetEmployeesList() => Task.FromResult(al.GetAllEmployees());

        public void Create(Employee employee) => al.AddEmployee(employee);

        public Task<Employee> Details(int id) => Task.FromResult(al.GetEmployeeData(id));

        public void Edit(Employee employee) => al.UpdateEmployee(employee);

        public void Delete(int id) => al.DeleteEmployee(id);

        public Task<List<Cities>> GetCities() => Task.FromResult(al.GetCityData());
    }
}
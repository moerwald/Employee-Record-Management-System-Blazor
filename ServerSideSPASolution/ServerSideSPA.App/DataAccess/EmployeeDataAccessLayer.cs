using Microsoft.EntityFrameworkCore;
using ServerSideSPA.App.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServerSideSPA.App.DataAccess
{
    public class EmployeeDataAccessLayer
    {
        private MyDbContext db = new MyDbContext();

        public List<Employee> GetAllEmployees() => db.Employee.AsNoTracking().ToList();

        public void AddEmployee(Employee employee)
        {
            try
            {
                db.Employee.Add(employee);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Employee GetEmployeeData(int id)
        {
            try
            {
                var e = db.Employee.Find(id);
                // Deactivate Entity context tracking
                db.Entry(e).State = EntityState.Detached;
                return e;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                var e = db.Employee.Find(id);
                db.Employee.Remove(e);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Cities> GetCityData() => db.Cities.ToList();
    }
}
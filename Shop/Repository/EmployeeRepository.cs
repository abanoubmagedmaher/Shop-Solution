using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Repository
{
    public class EmployeeRepository
    {
        ShopContext dbcontext;
        public EmployeeRepository()
        {
            dbcontext = new ShopContext();

        }

        public void Add(Employee Emp)
        {
            dbcontext.Add(Emp);
        }

        public void Update(Employee Emp) 
        {
            dbcontext.Update(Emp);
        }

        public void Delete(int id) 
        {
            var employee = GetById(id);
            dbcontext.Remove(employee);
        }

        public List<Employee> GetAll(string include="")
        {
            return dbcontext.Employee.Include(include).ToList();
        }
        public Employee GetById(int id)
        {
            return dbcontext.Employee.FirstOrDefault(e => e.Id == id);
        }

        public void Save()
        {
            dbcontext.SaveChanges();
        }

    }

}

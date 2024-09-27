using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        ShopContext dbcontext;
        public EmployeeRepository(ShopContext _context)
        {
            dbcontext = _context;
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
            return dbcontext.Employee.ToList();
        }
        public Employee GetById(int id)
        {
            return dbcontext.Employee.FirstOrDefault(e => e.Id == id);
        }

        public void Save()
        {
            dbcontext.SaveChanges();
        }

        public List<Employee> GetEmpsByDeptId(int deptId)
        {
            return dbcontext.Employee.Where(e => e.DepartmentID == deptId).ToList();
        }
    }

}

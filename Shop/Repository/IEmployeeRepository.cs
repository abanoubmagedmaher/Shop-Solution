using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Repository
{
    public interface IEmployeeRepository
    {
        public void Add(Employee Emp);

        public void Update(Employee Emp);


        public void Delete(int id);

        public List<Employee> GetAll(string include = "");

        public Employee GetById(int id);


        public void Save();
       
    }
}

using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Repository
{
    public interface IDepartmentRepository
    {
        public void Add(Department Dept);
 
        public void Update(Department Dept);
        

        public void Delete(int id);
      

        public List<Department> GetAll(string include = "");
       
        public Department GetById(int id);
       

        public void Save();
      
    }
}

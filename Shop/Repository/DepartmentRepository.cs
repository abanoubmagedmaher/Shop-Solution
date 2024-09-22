using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        ShopContext dbcontext;
        public DepartmentRepository() 
        {
            dbcontext =new ShopContext();   
        }
        public void Add(Department Dept)
        {
            dbcontext.Add(Dept);
        }

        public void Update(Department Dept) 
        {
            dbcontext.Update(Dept);
        }

        public void Delete(int id) 
        {
            var dept = GetById(id);
            dbcontext.Remove(dept);
        }

        public List<Department> GetAll(string include="")
        {
            return dbcontext.Department.Include(include).ToList();
        }

        public Department GetById(int id)
        {
            return dbcontext.Department.FirstOrDefault(d => d.Id == id);
        }
        
        public void Save()
        {
            dbcontext.SaveChanges();
        }
    }

}

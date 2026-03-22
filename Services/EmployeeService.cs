using Interview_Practice.Domain;
using Microsoft.EntityFrameworkCore;

namespace Interview_Practice.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbcontex _context;

        public EmployeeService(EmployeeDbcontex context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            employee.HireDate = DateTime.Now;
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> UpdateAsync(int id, Employee updated)
        {
            if (id != updated.Id)
                return false;

            var exists = await _context.Employees.AnyAsync(e => e.Id == id);
            if (!exists)
                return false;

            _context.Entry(updated).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

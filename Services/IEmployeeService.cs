using Interview_Practice.Domain;

namespace Interview_Practice.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employee);
        Task<bool> UpdateAsync(int id, Employee updated);
        Task<bool> DeleteAsync(int id);
    }
}

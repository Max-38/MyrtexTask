using MyrtexTask.Domain;

namespace MyrtexTask.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllAsync();

        public Task CreateAsync(Employee employee);

        public Task<Employee> GetByIdAsync(Guid id);
        public Task DeleteAsync(Guid id);
        public Task UpdateAsync(Employee employee);
    }
}

using Microsoft.EntityFrameworkCore;
using MyrtexTask.Application.Interfaces;
using MyrtexTask.Domain;

namespace MyrtexTask.Data.EF
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbContextFactory<MyrtexTaskDbContext> dbContextFactory;

        public EmployeeRepository(IDbContextFactory<MyrtexTaskDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Получение всего списка сотрудников
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAllAsync()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return await dbContext.Employees.ToListAsync();
            }
        }

        /// <summary>
        /// Получение сотрудника по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<Employee> GetByIdAsync(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

                if(employee == null)
                    throw new NullReferenceException(nameof(employee));

                return employee;
            }
        }

        /// <summary>
        /// Добавление нового сотрудника в базу данных
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task CreateAsync(Employee employee)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                employee.Id = Guid.NewGuid();
                dbContext.Employees.Add(employee);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удаление сотрудника по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task DeleteAsync(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

                if(employee == null)
                    throw new NullReferenceException(nameof(employee));

                dbContext.Remove(employee);
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Обновление данных о сотруднике
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task UpdateAsync (Employee employee)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.Update(employee);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

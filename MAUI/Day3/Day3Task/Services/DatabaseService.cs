using SQLite;
using Day3Task.Models;

namespace Day3Task.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;

        private async Task InitAsync()
        {
            if (_db != null) return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "employees.db");
            _db = new SQLiteAsyncConnection(dbPath);

            await _db.CreateTableAsync<Department>();
            await _db.CreateTableAsync<Employee>();

            var count = await _db.Table<Department>().CountAsync();
            if (count == 0)
            {
                var departments = new List<Department>
                {
                    new Department { Name = "Human Resources" },
                    new Department { Name = "Engineering" },
                    new Department { Name = "Marketing" },
                    new Department { Name = "Finance" },
                    new Department { Name = "Sales" },
                    new Department { Name = "Operations" },
                };
                await _db.InsertAllAsync(departments);
            }
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            await InitAsync();
            return await _db.Table<Department>().ToListAsync();
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            await InitAsync();
            return await _db.InsertAsync(employee);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            await InitAsync();
            return await _db.Table<Employee>().ToListAsync();
        }
    }
}
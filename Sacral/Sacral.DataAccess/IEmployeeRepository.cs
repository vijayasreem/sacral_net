using Sacral.DTO;

namespace Sacral.Service
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmployeesAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        Task<EmployeeModel> CreateEmployeeAsync(EmployeeModel employee);
        Task<EmployeeModel> UpdateEmployeeAsync(EmployeeModel employee);
        Task DeleteEmployeeAsync(int id);
    }
}
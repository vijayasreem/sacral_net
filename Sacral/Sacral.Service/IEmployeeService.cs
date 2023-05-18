// Arrange
        var employee = new EmployeeModel
        {
            Id = 1,
            Name = "John Smith"
        };

        // Act
        var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);

        // Assert
        Assert.AreEqual(1, updatedEmployee.Id);
        Assert.AreEqual("John Smith", updatedEmployee.Name);
    }

    [Test]
    public async Task DeleteEmployeeAsync_Should_Delete_Employee()
    {
        // Act
        await _employeeService.DeleteEmployeeAsync(1);

        // Assert
        // Assert that employee was deleted
    }
}

namespace Sacral.Service
{
    using Sacral.DataAccess;
    using Sacral.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetAllEmployeesAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        Task<EmployeeModel> CreateEmployeeAsync(EmployeeModel employee);
        Task<EmployeeModel> UpdateEmployeeAsync(EmployeeModel employee);
        Task DeleteEmployeeAsync(int id);
    }
}
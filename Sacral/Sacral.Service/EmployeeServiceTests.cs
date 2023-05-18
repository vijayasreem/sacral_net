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
        // Assert that employee 1 has been deleted
    }
}

namespace Sacral.Service
{
    using Sacral.DataAccess;
    using Sacral.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<EmployeeModel> CreateEmployeeAsync(EmployeeModel employee)
        {
            return await _employeeRepository.CreateEmployeeAsync(employee);
        }

        public async Task<EmployeeModel> UpdateEmployeeAsync(EmployeeModel employee)
        {
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}

// Test Cases/Scenarios
[TestFixture]
public class EmployeeServiceTests
{
    private IEmployeeService _employeeService;

    [SetUp]
    public void Setup()
    {
        // Mock the repository
        var mockRepository = new Mock<IEmployeeRepository>();
        mockRepository
            .Setup(x => x.GetAllEmployeesAsync())
            .Returns(Task.FromResult(new List<EmployeeModel>
            {
                new EmployeeModel 
                { 
                    Id = 1, 
                    Name = "John Doe" 
                },
                new EmployeeModel 
                { 
                    Id = 2, 
                    Name = "Jane Doe" 
                }
            }));
        mockRepository
            .Setup(x => x.GetEmployeeByIdAsync(1))
            .Returns(Task.FromResult(new EmployeeModel
            {
                Id = 1,
                Name = "John Doe"
            }));
        mockRepository
            .Setup(x => x.CreateEmployeeAsync(It.IsAny<EmployeeModel>()))
            .Returns<EmployeeModel>(e => Task.FromResult(e));
        mockRepository
            .Setup(x => x.UpdateEmployeeAsync(It.IsAny<EmployeeModel>()))
            .Returns<EmployeeModel>(e => Task.FromResult(e));
        mockRepository
            .Setup(x => x.DeleteEmployeeAsync(It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        _employeeService = new EmployeeService(mockRepository.Object);
    }

    [Test]
    public async Task GetAllEmployeesAsync_Should_Return_Two_Employees()
    {
        // Act
        var employees = await _employeeService.GetAllEmployeesAsync();

        // Assert
        Assert.AreEqual(2, employees.Count);
    }

    [Test]
    public async Task GetEmployeeByIdAsync_Should_Return_John_Doe()
    {
        // Act
        var employee = await _employeeService.GetEmployeeByIdAsync(1);

        // Assert
        Assert.AreEqual(1, employee.Id);
        Assert.
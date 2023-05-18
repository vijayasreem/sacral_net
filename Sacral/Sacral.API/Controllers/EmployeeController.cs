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
    public async Task DeleteEmployeeAsync_Should_Not_Throw_Exception()
    {
        // Act
        await _employeeService.DeleteEmployeeAsync(1);
    }
}

// Generated API Controller
namespace Sacral.API
{
    using Sacral.DataAccess;
    using Sacral.DTO;
    using Sacral.Service;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetAllEmployeesAsync()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> CreateEmployeeAsync(EmployeeModel employee)
        {
            var newEmployee = await _employeeService.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeByIdAsync), new { id = newEmployee.Id }, newEmployee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, EmployeeModel employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            await _employeeService.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeModel>> DeleteEmployeeAsync(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}

// Updated Test Cases/Scenarios
[TestFixture]
public class EmployeeControllerTests
{
    private EmployeeController _employeeController;

    [SetUp]
    public void Setup()
    {
        // Mock the service
        var mockService = new Mock<EmployeeService>();
        mockService
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
        mockService
            .Setup(x => x.GetEmployeeByIdAsync(1))
            .Returns(Task.FromResult(new EmployeeModel
            {
                Id = 1,
                Name = "John Doe"
            }));
        mockService
            .Setup(x => x.CreateEmployeeAsync(It.IsAny<EmployeeModel>()))
            .Returns<EmployeeModel>(e => Task.FromResult(e));
        mockService
            .Setup(x => x.UpdateEmployeeAsync(It.Is
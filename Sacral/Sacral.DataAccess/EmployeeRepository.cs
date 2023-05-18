namespace Sacral
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoDatabase _db;

        public EmployeeRepository(IMongoDatabase db)
        {
            _db = db;
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            var collection = _db.GetCollection<EmployeeModel>("employees");
            var employees = await collection.Find(Builders<EmployeeModel>.Filter.Empty).ToListAsync();
            return employees;
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var filter = Builders<EmployeeModel>.Filter.Eq(x => x.Id, id);
            var collection = _db.GetCollection<EmployeeModel>("employees");
            var employee = await collection.Find(filter).SingleOrDefaultAsync();
            return employee;
        }

        public async Task<EmployeeModel> CreateEmployeeAsync(EmployeeModel employee)
        {
            var collection = _db.GetCollection<EmployeeModel>("employees");
            await collection.InsertOneAsync(employee);
            return employee;
        }

        public async Task<EmployeeModel> UpdateEmployeeAsync(EmployeeModel employee)
        {
            var filter = Builders<EmployeeModel>.Filter.Eq(x => x.Id, employee.Id);
            var collection = _db.GetCollection<EmployeeModel>("employees");
            await collection.ReplaceOneAsync(filter, employee);
            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var filter = Builders<EmployeeModel>.Filter.Eq(x => x.Id, id);
            var collection = _db.GetCollection<EmployeeModel>("employees");
            await collection.DeleteOneAsync(filter);
        }
    }
}
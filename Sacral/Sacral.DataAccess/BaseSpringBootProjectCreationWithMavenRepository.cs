namespace Sacral
{
    public class BaseSpringBootProjectCreationWithMavenRepository
    {
        private readonly SqlConnection _connection;
        public BaseSpringBootProjectCreationWithMavenRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<BaseSpringBootProjectCreationWithMavenModel> GetAsync(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT BuildTool, Language, Framework FROM BaseSpringBootProjectCreationWithMaven WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                _connection.Open();
                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var model = new BaseSpringBootProjectCreationWithMavenModel
                    {
                        Id = id,
                        BuildTool = reader.GetString(0),
                        Language = reader.GetString(1),
                        Framework = reader.GetString(2)
                    };
                    _connection.Close();
                    return model;
                }
                else
                {
                    _connection.Close();
                    return null;
                }
            }
        }

        public async Task<IEnumerable<BaseSpringBootProjectCreationWithMavenModel>> GetAllAsync()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, BuildTool, Language, Framework FROM BaseSpringBootProjectCreationWithMaven";
                _connection.Open();
                var reader = await command.ExecuteReaderAsync();
                var models = new List<BaseSpringBootProjectCreationWithMavenModel>();
                while (await reader.ReadAsync())
                {
                    var model = new BaseSpringBootProjectCreationWithMavenModel
                    {
                        Id = reader.GetInt32(0),
                        BuildTool = reader.GetString(1),
                        Language = reader.GetString(2),
                        Framework = reader.GetString(3)
                    };
                    models.Add(model);
                }
                _connection.Close();
                return models;
            }
        }

        public async Task<bool> InsertAsync(BaseSpringBootProjectCreationWithMavenModel model)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO BaseSpringBootProjectCreationWithMaven (BuildTool, Language, Framework) VALUES (@BuildTool, @Language, @Framework)";
                command.Parameters.AddWithValue("@BuildTool", model.BuildTool);
                command.Parameters.AddWithValue("@Language", model.Language);
                command.Parameters.AddWithValue("@Framework", model.Framework);
                _connection.Open();
                var rowAffected = await command.ExecuteNonQueryAsync();
                _connection.Close();
                return rowAffected > 0;
            }
        }

        public async Task<bool> UpdateAsync(BaseSpringBootProjectCreationWithMavenModel model)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE BaseSpringBootProjectCreationWithMaven SET BuildTool = @BuildTool, Language = @Language, Framework = @Framework WHERE Id = @Id";
                command.Parameters.AddWithValue("@BuildTool", model.BuildTool);
                command.Parameters.AddWithValue("@Language", model.Language);
                command.Parameters.AddWithValue("@Framework", model.Framework);
                command.Parameters.AddWithValue("@Id", model.Id);
                _connection.Open();
                var rowAffected = await command.ExecuteNonQueryAsync();
                _connection.Close();
                return rowAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM BaseSpringBootProjectCreationWithMaven WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                _connection.Open();
                var rowAffected = await command.ExecuteNonQueryAsync();
                _connection.Close();
                return rowAffected > 0;
using System.Data;
using System.Data.SqlClient;
using Sacral.DTO;

namespace Sacral
{
    public class DesignatedPersonRepository : IDesignatedPersonRepository
    {
        private string _connectionString;
        public DesignatedPersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DesignatedPersonModel> CreateDesignatedPersonAsync(DesignatedPersonModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO DesignatedPerson (FirstName, LastName, ContactNumber, Email)
                                        VALUES (@firstName, @lastName, @contactNumber, @email);
                                        SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("@firstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", model.LastName);
                    cmd.Parameters.AddWithValue("@contactNumber", model.ContactNumber);
                    cmd.Parameters.AddWithValue("@email", model.Email);

                    model.Id = await cmd.ExecuteScalarAsync();

                    return model;
                }
            }
        }

        public async Task<DesignatedPersonModel> GetDesignatedPersonAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, FirstName, LastName, ContactNumber, Email
                                        FROM DesignatedPerson
                                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = await cmd.ExecuteReaderAsync();

                    if (reader.Read())
                    {
                        return new DesignatedPersonModel
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            ContactNumber = (string)reader["ContactNumber"],
                            Email = (string)reader["Email"]
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public async Task<DesignatedPersonModel> UpdateDesignatedPersonAsync(DesignatedPersonModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE DesignatedPerson
                                        SET FirstName = @firstName, 
                                            LastName = @lastName, 
                                            ContactNumber = @contactNumber,
                                            Email = @email
                                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", model.Id);
                    cmd.Parameters.AddWithValue("@firstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", model.LastName);
                    cmd.Parameters.AddWithValue("@contactNumber", model.ContactNumber);
                    cmd.Parameters.AddWithValue("@email", model.Email);

                    await cmd.ExecuteNonQueryAsync();

                    return model;
                }
            }
        }

        public async Task DeleteDesignatedPersonAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM DesignatedPerson 
                                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
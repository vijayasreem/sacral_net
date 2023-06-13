using System;
using System.Data.SqlClient;
using Sacral.DTO;

namespace Sacral
{
    public class DesignatedPersonRepository : IDesignatedPersonRepository
    {
        private readonly string connectionString;

        public DesignatedPersonRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<DesignatedPersonModel> GetDesignatedPersonAsync(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("SELECT * FROM DesignatedPerson WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return new DesignatedPersonModel
                            {
                                Id = (int)reader["Id"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Email = (string)reader["Email"],
                                Phone = (string)reader["Phone"]
                            };
                        }

                        return null;
                    }
                }
            }
        }

        public async Task<int> CreateDesignatedPersonAsync(DesignatedPersonModel designatedPerson)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("INSERT INTO DesignatedPerson (FirstName, LastName, Email, Phone) VALUES (@FirstName, @LastName, @Email, @Phone); SELECT CAST(SCOPE_IDENTITY() as int)", conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", designatedPerson.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", designatedPerson.LastName);
                    cmd.Parameters.AddWithValue("@Email", designatedPerson.Email);
                    cmd.Parameters.AddWithValue("@Phone", designatedPerson.Phone);

                    return (int)await cmd.ExecuteScalarAsync();
                }
            }
        }

        public async Task UpdateDesignatedPersonAsync(DesignatedPersonModel designatedPerson)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("UPDATE DesignatedPerson SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", designatedPerson.Id);
                    cmd.Parameters.AddWithValue("@FirstName", designatedPerson.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", designatedPerson.LastName);
                    cmd.Parameters.AddWithValue("@Email", designatedPerson.Email);
                    cmd.Parameters.AddWithValue("@Phone", designatedPerson.Phone);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteDesignatedPersonAsync(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("DELETE FROM DesignatedPerson WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
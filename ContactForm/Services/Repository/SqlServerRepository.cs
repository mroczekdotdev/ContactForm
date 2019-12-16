using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MroczekDotDev.ContactForm.Models;
using System.Data;

namespace MroczekDotDev.ContactForm.Services.Repository
{
    public class SqlServerRepository : IRepository
    {
        private readonly SqlServerRepositoryOptions options;
        private readonly string connectionString;

        public SqlServerRepository(
            IOptions<SqlServerRepositoryOptions> optionsAccessor)
        {
            options = optionsAccessor.Value;
            connectionString = options.ConnectionString;
        }

        public void AddForm(FormViewModel form)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddForm";

                    command.Parameters.AddWithValue("@FirstName", form.FirstName);
                    command.Parameters.AddWithValue("@LastName", form.LastName);
                    command.Parameters.AddWithValue("@Email", form.Email);
                    command.Parameters.AddWithValue("@Phone", form.Phone);
                    command.Parameters.AddWithValue("@Subject", form.Subject);
                    command.Parameters.AddWithValue("@Message", form.Message);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}

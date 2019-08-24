using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace RegistroClientes.Pages
{
    public class IndexModel : PageModel
    {
        public IConfiguration Configuration { get; }
        [BindProperty]
        public Cliente Client { get; set; }
        public IndexModel(IConfiguration config)
        {
            Configuration = config;
            Client = new Cliente();
        }
        public void OnGet()
        {
            Client = new Cliente();
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                string defaultConnection = Configuration["ConnectionStrings:DefaultConnection"];
                using (SqlConnection connection = new SqlConnection(defaultConnection))
                {
                    string query = $"INSERT INTO Clientes(Name, Email, DOB) Values('{Client.Name}', '{Client.Email}','{Client.DateOfBirth}')";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}

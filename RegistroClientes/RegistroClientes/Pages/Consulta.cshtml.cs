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
    public class ConsultaModel : PageModel
    {
        public IConfiguration Configuration { get; }
        public List<Cliente> Clientes;

        public ConsultaModel(IConfiguration config)
        {
            Configuration = config;
            Clientes = new List<Cliente>();
        }
        public void OnGet()
        {
            if (ModelState.IsValid)
            {
                string defaultConnection = Configuration["ConnectionStrings:DefaultConnection"];
                using (SqlConnection connection = new SqlConnection(defaultConnection))
                {
                    string query = $"SELECT * FROM Clientes";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();

                        cliente.ID = Convert.ToInt32(reader["Id"]);
                        cliente.Name = reader["Name"].ToString();
                        cliente.Email = reader["Email"].ToString();
                        cliente.DateOfBirth = DateTime.Parse(reader["DOB"].ToString());
                        Clientes.Add(cliente);
                    }
                    connection.Close();


                }


            }
        }
    }
}
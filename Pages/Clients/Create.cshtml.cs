using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace MusteriListesi.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();

        public void OnGet()
        {
        }
        public void OnPost() {
            try {
                clientInfo.name = Request.Form["name"];
                clientInfo.email = Request.Form["email"];
                clientInfo.address = Request.Form["address"];
                clientInfo.phone = Request.Form["phone"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                String connectionString = "Data Source=localhost;Initial Catalog=ClientList;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO clients" +
                        "(name,email,address,phone)" +
                        "VALUES" +
                        "(@name,@email,@address,@phone)";
                    using(SqlCommand command = new SqlCommand(sql,connection))
                    {
                        command.Parameters.AddWithValue("@name",clientInfo.name);
                        command.Parameters.AddWithValue("@email", clientInfo.email);
                        command.Parameters.AddWithValue("@address", clientInfo.address);
                        command.Parameters.AddWithValue("@phone", clientInfo.phone);
                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            clientInfo.name = "";
            clientInfo.email = "";
            clientInfo.address = "";
            clientInfo.phone = "";
            

        }

        
        //using(SqlConnection con = new SqlConnection(connectionString))


    }
}

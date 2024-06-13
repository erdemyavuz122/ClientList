using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Dynamic;

namespace MusteriListesi.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> ListClients = new List<ClientInfo>(); 
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost;Initial Catalog=ClientList;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    
                    String sql = "SELECT *FROM clients";
                    using (SqlCommand cmd = new SqlCommand(sql,con)) { 
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.address = reader.GetString(3);
                                clientInfo.phone = reader.GetString(4);
                                ListClients.Add(clientInfo);
                            }
                        }
                    
                    }                   
                }
            }
            
            catch(Exception ex) {
            Console.WriteLine(ex.ToString());
            }
        }
        
        
    }
    public class ClientInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

    }
}

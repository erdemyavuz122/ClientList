using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MusteriListesi.Pages.Clients
{
    public class EditModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public void OnGet()
        {
            try
            {

            }
            catch(Exception ex) {
            ex.ToString();
            }
        }
    }
}

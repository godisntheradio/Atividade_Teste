using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RegistroClientes.Pages
{
    public class IndexModel : PageModel
    {
        public string Name;
        public void OnGet()
        {
            Name = "Gabriel";
        }
        public void ChangePage()
        {
            Response.Redirect("/Consulta");
        }
    }
}

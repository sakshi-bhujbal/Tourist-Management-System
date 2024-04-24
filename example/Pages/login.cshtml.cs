using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using MySqlX.XDevAPI.Common;
using System;
using Mysqlx.Resultset;
using example.models;

namespace example.Pages
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public required Login log { get; set; }

        public RedirectToPageResult OnPost()
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
          

            using (MySqlConnection con = new MySqlConnection("server=localhost;username=root;database=vv;port=3306;password=sakshi01@5"))
            {
                //opening connection
                con.Open();

                var command = new MySqlCommand("SELECT COUNT(*) FROM reg WHERE email=@email AND password=@password", con);



                command.Parameters.AddWithValue("email", email);
                command.Parameters.AddWithValue("password", password);
                var result=(long)command.ExecuteScalar();

                if (result == 1)
                {
                    // Successful sign-in logic
                    return RedirectToPage("/Index"); // Redirect to dashboard page
                }
                else
                {
                    // Failed sign-in logic
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                    return RedirectToPage("/Login");  // Reload sign-in page with error message


                    con.Close();

                }

            }

        }
    }
}
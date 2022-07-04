using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeyIdeas_Assignment.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace KeyIdeas_Assignment.Controllers
{
    public class RegistrationController : Controller
    {
        public string value = "";

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult Index(Register register)
        {
            if (Request.HttpMethod == "POST")
            {
                Register er = new Register();
                using (SqlConnection con = new SqlConnection("Data Source=SQLEXPRESS;Integrated Security=true;Initial Catalog=Sample"))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EnrollDetail", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", register.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", register.LastName);
                        cmd.Parameters.AddWithValue("@Password", register.Password);
                        cmd.Parameters.AddWithValue("@Gender", register.Gender);
                        cmd.Parameters.AddWithValue("@Email", register.Email);
                        cmd.Parameters.AddWithValue("@Username", register.PhoneNumber);
                        cmd.Parameters.AddWithValue("@SecurityAnwser", register.SecurityAnwser);
                        cmd.Parameters.AddWithValue("@status", "INSERT");
                        con.Open();
                        ViewData["result"] = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker_Project.Models
{
	public class RegisterModel
	{
		public UserType UserType { get; set; }

		public string Email { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Password { get; set; }

		public string Results { get; }

		public RegisterModel(string results) => Results = results;

		public RegisterModel() { }
	}
}
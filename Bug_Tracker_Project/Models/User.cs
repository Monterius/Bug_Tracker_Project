using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Remove option to perform any operation such as deleting a ticket
/// From any user type that is not allowed
/// </summary>
public enum UserType { Developer, Manager, Admin }
namespace Bug_Tracker_Project.Models
{
    public class User
    {
        private UserType Type { get; }

        private string FirstName { get; }

        private string LastName { get; }

        private string Email { get; }

        private string Password { get; }

        public User (RegisterModel registerModel)
        {
            Type = registerModel.UserType;
            FirstName = registerModel.FirstName;
            LastName = registerModel.LastName;
            Email = registerModel.Email;
            Password = registerModel.Password;
        }

        public User() { }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker_Project.Models
{
    public class Project
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public User Creator { get; }

        public DateTime EstimatedCompletionDate { get; set; }

        public DateTime TimeOfCreation { get; }

        public List<User> MembersOfProject;

        public Project() {}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum Status { Active, Resolved, PendingReview, Closed }
namespace Bug_Tracker_Project.Models
{
    public class Task
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public User Submitter { get; }

        public User Developer { get; set; }

        public Status Status { get; set; }

        public DateTime TimeOfCreation { get; }

        // Only for testing
        public string Results { get; }

        public Task(User user)
        {
            Submitter = user;
            TimeOfCreation = DateTime.Now;
        }

        public Task(string results) => Results = results;

        public Task() {}
    }
}
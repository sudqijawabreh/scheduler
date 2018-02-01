using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string User { get; set; }
        public ProjectListModel [] Projects { get; set; }
        public int selected { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        
    }
}
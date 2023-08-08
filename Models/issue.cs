using System.ComponentModel.DataAnnotations;

namespace trackingapi.Models
{
    public class issue
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Priority priority { get; set; }
        
        public IssueType IssueType { get; set; }

        public DateTime created { get; set; }
        public DateTime Completed { get; set; }
    }

    public enum Priority
    {
        Low,Medium,High
    }
    public enum IssueType
    {
        Feature,Bug, Documentation
    }


}

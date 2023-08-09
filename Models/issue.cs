using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace trackingapi.Models
{
    public class Issue
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

    public class FilterRequest
    {
        public int Page { get; set; }
        public int Num { get; set; }
        public IssueType Type { get; set; }
    }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Priority
    {
        Low,Medium,High
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IssueType
    {
        Feature,Bug, Documentation
        
    }


}

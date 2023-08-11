using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using trackingapi.Models;

namespace trackingapi.DTO
{
    public class IssueDTO : Issue
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Models.IssueType IssueType { get; internal set; }
        // public Priority priority { get; set; }


        //  public IssueType IssueType { get; set; }



    }

    public class IssueFilter : FilterDTO
    {
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

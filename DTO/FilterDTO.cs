using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace trackingapi.DTO
{
    public class FilterDTO
    {
        public int Page { get; set; }
        public int Num { get; set; }
        public Models.IssueType Type { get; internal set; }
        public string Sort { get; set; }
        //public IssueType Type { get; set; }
    }

}

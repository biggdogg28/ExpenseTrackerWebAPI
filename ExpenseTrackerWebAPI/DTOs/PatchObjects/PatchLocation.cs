using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTrackerWebAPI.DTOs.PatchObjects
{
    public class PatchLocation
    {
        [Key]
        [JsonIgnore]
        public Guid IdLocation { get; set; }
        public string? Name { get; set; }
    }
}

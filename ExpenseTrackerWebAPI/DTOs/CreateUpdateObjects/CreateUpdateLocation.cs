using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects
{
    public class CreateUpdateLocation
    {
        [Key]
        [JsonIgnore]
        public Guid IdLocation { get; set; }
        public string? Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTrackerWebAPI.DTOs.PatchObjects
{
    public class PatchIncomeType
    {
        [Key]
        [JsonIgnore]
        public Guid IncomeTypeID { get; set; }
        public string? Name { get; set; }
    }
}

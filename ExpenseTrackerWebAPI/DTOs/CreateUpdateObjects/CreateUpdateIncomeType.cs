using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects
{
    public class CreateUpdateIncomeType
    {
        [Key]
        [JsonIgnore]
        public Guid IncomeTypeID { get; set; }
        public string? Name { get; set; }
    }
}

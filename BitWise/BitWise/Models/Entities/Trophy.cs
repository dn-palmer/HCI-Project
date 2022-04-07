using BitWise.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace BitWise.Models.Entities
{
    public class Trophy
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateOnly DateEarned { get; set; }
        public BitWiseUser BitWiseUser { get; set; }
    }
}

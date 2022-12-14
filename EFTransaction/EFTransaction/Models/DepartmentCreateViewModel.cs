using System.ComponentModel.DataAnnotations;

namespace EFTransaction.Models
{
    public class DepartmentCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DepartmentCode { get; set; }
    }
}

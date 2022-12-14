using System.ComponentModel.DataAnnotations;

namespace EFTransaction.Models
{
    public class Department
    {

        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string DepartmentCode { get; set; }


    }
}

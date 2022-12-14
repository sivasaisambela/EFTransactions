using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTransaction.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        

        [Required, MaxLength(40, ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

              

        [Required, MaxLength(40)]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Email { get; set; }

       
        public string PhoneNumber { get; set; }

        [Required, MaxLength(150)]
        public string Address { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(20)]
        public string Postcode { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [NotMapped]
        public string DeptName { get; set; }

        [NotMapped]
        public string DeptCode { get; set; }
    }
}

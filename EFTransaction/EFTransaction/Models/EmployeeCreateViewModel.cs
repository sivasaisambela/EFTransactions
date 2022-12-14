using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace EFTransaction.Models
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }


      
        public string FirstName { get; set; }
    

       
        public string LastName { get; set; }
        public string Gender { get; set; }

        
        public int DepartmentId { get; set; }


        public string ImageUrl { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        
        public string Designation { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Joined")]
        public DateTime DateOfJoin { get; set; } = DateTime.Now;

        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

            

       
        public string Address { get; set; }

      
        public string City { get; set; }

       
        public string Postcode { get; set; }

      
        public string DeptName { get; set; }

        
        public string DeptCode { get; set; }

    }
}

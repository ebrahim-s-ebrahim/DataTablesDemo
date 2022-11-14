using System.ComponentModel.DataAnnotations;

namespace DataTablesDemo.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, MaxLength(55)]
        public string FirstName { get; set; }

        [Required, MaxLength(55)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

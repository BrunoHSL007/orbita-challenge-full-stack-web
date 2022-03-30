using System.ComponentModel.DataAnnotations;

namespace backend.ViewModel
{
    public class CreateStudentViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
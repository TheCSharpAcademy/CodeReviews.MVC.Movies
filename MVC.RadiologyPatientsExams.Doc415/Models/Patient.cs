using RadiologyPatientsExams.Validations;
using System.ComponentModel.DataAnnotations;

namespace RadiologyPatientsExams.Models;

public class Patient
{
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 2)]
    [Required]
    public string Name { get; set; }

    [StringLength(50, MinimumLength = 2)]
    [Required]
    public string Surname { get; set; }

    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [Required]
    [BirthDateValidation(ErrorMessage = "Birthdate can not be in the future.")]
    public DateTime BirthDate { get; set; }

    [Display(Name = "E-Mail")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
    [Phone()]
    [Required]
    public string Phone { get; set; }

    public bool NotDeleted { get; set; } = true;

}

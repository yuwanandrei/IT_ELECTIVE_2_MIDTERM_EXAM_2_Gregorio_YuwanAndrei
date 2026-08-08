using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models;

public enum Sex
{
    Male,
    Female
}

public enum VisitType
{
    [Display(Name = "Walk-in")]
    WalkIn,
    [Display(Name = "Follow-up")]
    FollowUp,
    Emergency,
    Referral
}

public enum VisitStatus
{
    Waiting,
    [Display(Name = "In Consultation")]
    InConsultation,
    Completed
}

public class PatientVisit
{
    public int Id { get; set; }

    [Display(Name = "Visit Number")]
    public string VisitNumber { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [StringLength(50)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Age is required")]
    [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Sex is required")]
    public Sex Sex { get; set; }

    [Required(ErrorMessage = "Contact number is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    [Display(Name = "Contact Number")]
    public string ContactNumber { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [StringLength(200)]
    public string Address { get; set; }

    [Required(ErrorMessage = "Physician is required")]
    [StringLength(100)]
    public string Physician { get; set; }

    [Required(ErrorMessage = "Visit type is required")]
    [Display(Name = "Visit Type")]
    public VisitType VisitType { get; set; }

    [Required(ErrorMessage = "Arrival date and time is required")]
    [Display(Name = "Arrival Date & Time")]
    [DataType(DataType.DateTime)]
    public DateTime ArrivalDateTime { get; set; } = DateTime.Now;

    [Display(Name = "Consultation End Time")]
    [DataType(DataType.DateTime)]
    public DateTime? ConsultationCompletedDateTime { get; set; }

    public VisitStatus Status { get; set; } = VisitStatus.Waiting;

    [Required(ErrorMessage = "Chief complaint is required")]
    [StringLength(500)]
    [Display(Name = "Chief Complaint")]
    public string ChiefComplaint { get; set; }

    [StringLength(1000)]
    public string Notes { get; set; }

    [Display(Name = "Patient")]
    public string FullName => $"{FirstName} {LastName}";
}

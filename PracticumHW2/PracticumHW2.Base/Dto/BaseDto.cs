using System.ComponentModel.DataAnnotations;

namespace PracticumHW2.Base.Dto
{
    public abstract class BaseDto
    {
        public int Id { get; set; }


        [MaxLength(100)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; } = string.Empty;

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

    }
}

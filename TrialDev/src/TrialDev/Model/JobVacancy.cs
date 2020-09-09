using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrialDev.Model
{
    public class JobVacancy
    {
        public JobVacancy()
        {
            CreatedDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "Vacancy Name")]
        [Column(TypeName = "varchar(50)")]
        public string VacancyName { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime PeriodeStart { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime PeriodeEnd { get; set; }
        public int Slots { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

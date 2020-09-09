using System;
using System.ComponentModel.DataAnnotations;

namespace TrialDev.Model
{
    public class JobVacancyDTO
    {
        [Required]
        public int JobId { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string VacancyName { get; set; }
        [Required]
        public string Period { get; set; }
        public int? Slots { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

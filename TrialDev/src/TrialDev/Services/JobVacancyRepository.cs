using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrialDev.Model;

namespace TrialDev.Services
{
    public class JobVacancyRepository : IJobVacancy
    {

        private readonly ApplicationDbContext _context;
        public JobVacancyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            JobVacancy jv = _context.JobVacancies.SingleOrDefault(a => a.JobId.Equals(id));
            if (jv != null)
            {
                _context.Remove(jv);
            }
        }

        public async Task<JobVacancyDTO> getById(int? id)
        {
            JobVacancyDTO data = _context.JobVacancies.Where(a => a.JobId.Equals(id)).Select(a => new JobVacancyDTO
            {
                JobId = a.JobId,
                JobTitle = a.JobTitle,
                Note = a.Note,
                Period = a.PeriodeStart.ToString("yyyy-MM-dd") + " - " + a.PeriodeEnd.ToString("yyyy-MM-dd"),
                Slots = a.Slots,
                VacancyName = a.VacancyName,
                CreatedDate = a.CreatedDate
            }).SingleOrDefault();

            return data;
        }

        public async Task<IEnumerable<JobVacancyDTO>> GetJobVacancies()
        {
            List<JobVacancyDTO> data = _context.JobVacancies.Select(a => new JobVacancyDTO
            {
                JobId = a.JobId,
                JobTitle = a.JobTitle,
                Note = a.Note,
                Period = a.PeriodeStart.ToString("MMMM dd,yyyy") + " - " + a.PeriodeEnd.ToString("MMMM dd,yyyy"),
                Slots = a.Slots,
                VacancyName = a.VacancyName,
                CreatedDate = a.CreatedDate
            }).ToList();

            return data;
        }

        public async Task Insert(JobVacancyDTO jobVacancyDTO)
        {
            string[] period = jobVacancyDTO.Period.Split('-');
            JobVacancy jv = new JobVacancy();
            jv.JobTitle = jobVacancyDTO.JobTitle;
            jv.VacancyName = jobVacancyDTO.VacancyName;
            jv.PeriodeStart = Convert.ToDateTime(period[0]);
            jv.PeriodeEnd = Convert.ToDateTime(period[1]);
            jv.Slots = jobVacancyDTO.Slots ?? 0;
            jv.Note = jobVacancyDTO.Note;
            _context.Add(jv);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(JobVacancyDTO jobVacancyDTO)
        {
            string[] period = jobVacancyDTO.Period.Split('-');


            JobVacancy jv = _context.JobVacancies.FirstOrDefault(a => a.JobId.Equals(jobVacancyDTO.JobId));
            jv.JobTitle = jobVacancyDTO.JobTitle;
            jv.VacancyName = jobVacancyDTO.VacancyName;
            jv.PeriodeStart = Convert.ToDateTime(period[0]);
            jv.PeriodeEnd = Convert.ToDateTime(period[1]);
            jv.Slots = jobVacancyDTO.Slots ?? 0;
            jv.Note = jobVacancyDTO.Note;
            _context.JobVacancies.Update(jv);
        }


    }
}

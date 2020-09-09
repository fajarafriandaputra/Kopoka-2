using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrialDev.Model;

namespace TrialDev.Services
{
    public interface IJobVacancy
    {
        Task<IEnumerable<JobVacancyDTO>> GetJobVacancies();
        Task Save();
        Task Insert(JobVacancyDTO jobVacancyDTO);
        Task Delete(int id);
        Task Update(JobVacancyDTO jobVacancyDTO);
        Task<JobVacancyDTO> getById(int? id);
    }
}

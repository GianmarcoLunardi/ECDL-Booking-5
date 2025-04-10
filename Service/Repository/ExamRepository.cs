using Identity2.Data;
using Identity2.Models;
using Identity2.Service.Interface;
using Identity2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Identity2.Service.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly ApplicationDbContext _RepoExam;
        private readonly DbSet<Exam> Tabella;
      
        public ExamRepository(ApplicationDbContext repoExam)
        {
            _RepoExam = repoExam;
            Tabella = _RepoExam.Exams;

        }

        public async Task Add(Exam entity)
        {
             await _RepoExam.Exams.AddAsync(entity);
        }

        public async Task Add(Exam entity, Guid IdSchool)
        {
            Exam e = new Exam();
            e.Date = entity.Date;
            e.IdSchool = IdSchool;
            e.School = await _RepoExam.Schools.FindAsync(IdSchool);
            await _RepoExam.Exams.AddAsync(e);
            await _RepoExam.SaveChangesAsync();


        }

        public async Task<IEnumerable<Exam>> All(PageInfo page = null)
        {
            return  _RepoExam.Exams
                .OrderByDescending(s=>s.Date)
                                .ToList<Exam>() ;
        }


        //All_School

        public async Task<IEnumerable<Exam>> All_School(PageInfo page = null)
        {


            return Tabella.Include(x => x.School).ToList();
            /*
            return _RepoExam.Exams
                .OrderByDescending(s => s.Date)
                
                                .ToList<Exam>();*/
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Exam> Find(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

// throw new NotImplementedException();
using Identity2.Data;
using Identity2.Models.Identity;
using Identity2.Service.Interface;
using Identity2.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity2.Service.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        internal DbSet<School> TabellaSchool; 

        public SchoolRepository(ApplicationDbContext applicationDbContext) 
        {
            _ApplicationDbContext = applicationDbContext;
            this.TabellaSchool = _ApplicationDbContext.Schools;
        }

        public async Task Add(School entity)
        {
            this.TabellaSchool.Add(entity);
            await _ApplicationDbContext.SaveChangesAsync();
        }




        public async  Task<IEnumerable<School>> All(PageInfo page = null)
        { 
            if(page==null){
                return await _ApplicationDbContext.Schools.ToListAsync<School>(); 
            } else
            {
                return await _ApplicationDbContext.Schools.ToArrayAsync<School>();
                //throw new NotImplementedException();
            }
        }

        public async Task<List<SelectListItem>> ListSchoolSelect(Guid? Id)
        {            
            
            List<SelectListItem> x = await TabellaSchool.Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.Name, Selected = false })
            .ToListAsync();
            
            if (Id != null)
            {
                SelectListItem elemento = x.Find(x => x.Value == Id.ToString());
                elemento.Selected= true;    
           
            }
            return x;  
             
        }



        public async Task Delete(Guid id)
        {
            var c = await TabellaSchool.FindAsync(id);
            TabellaSchool.Remove(c);
            await _ApplicationDbContext.SaveChangesAsync();
        }

        public async Task<School> Find(Guid id)
        {
            //var c = TabellaSchool.Include(i => i.Classes);
            return await TabellaSchool.Include(i => i.Classes).FirstAsync(x=> x.id == id);
        }

        public async Task<School> FindInclude(Guid id, string Inclu = null)
        {
          if (Inclu ==null) {
                return await TabellaSchool.FindAsync(id);
            }  else
            {
                return await TabellaSchool.Include(i => i.Classes)
                    .FirstOrDefaultAsync(i=>i.id == id);
            }
        }
    }
}
//  throw new NotImplementedException();
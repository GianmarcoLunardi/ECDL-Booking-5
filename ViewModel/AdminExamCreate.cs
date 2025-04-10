using Identity2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.ViewModel
{
   
    public class AdminExamCreate
    {
        public Exam exam { get; set; }
        public IEnumerable<SessionType> sessionList { get; set; }
        public Guid sessionId { get; set; }

        // Aggiunta Della Lista DDei Luoghi Deop Down
        public List<SelectListItem> PlaceList { get; set; } = new List<SelectListItem>();
        public Guid? PlaceSelected { get; set; }




    }
   
}

using KonsultApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonsultApp.DTO
{
    public class KonsultReponseDto
    {
        public int KonsultId { get; set; }
        public string ForNamn { get; set; }
        public string EfterNamn { get; set; }
        public int AntalAr { get; set; }

        public virtual ICollection<Bonu> Bonus { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace KonsultApp.Models
{
    public partial class Konsult
    {
        public Konsult()
        {
            Bonus = new HashSet<Bonu>();
        }

        public int KonsultId { get; set; }
        public string ForNamn { get; set; }
        public string EfterNamn { get; set; }
        public int AntalAr { get; set; }

        public virtual ICollection<Bonu> Bonus { get; set; }
    }
}

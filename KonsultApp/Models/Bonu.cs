using System;
using System.Collections.Generic;

#nullable disable

namespace KonsultApp.Models
{
    public partial class Bonu
    {
        public int BonusId { get; set; }
        public int Bonus { get; set; }
        public int KonsultId { get; set; }

        public virtual Konsult Konsult { get; set; }
    }
}

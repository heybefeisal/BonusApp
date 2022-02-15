using KonsultApp.DTO;
using KonsultApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonsultApp.Domain.Services.Interfaces
{
    public interface IKonsultService
    {
        ICollection<Konsult> GetKonsults();
        bool CreateKonsult(KonsultRequestDto konsultRequestDto);
        Konsult EditKonsult(int id, KonsultRequestDto konsultRequestDto);
        bool DeleteKonsult(int id);
    }
}

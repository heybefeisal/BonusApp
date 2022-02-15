using KonsultApp.Domain.Services.Interfaces;
using KonsultApp.DTO;
using KonsultApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonsultApp.Domain.Services
{
    public class KonsultService : IKonsultService
    {
        private readonly BonusDBContext _dbContext;
        public KonsultService(BonusDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateKonsult(KonsultRequestDto konsultRequestDto)
        {
            var newKonsult = new Konsult();
            newKonsult.ForNamn = konsultRequestDto.ForNamn;
            newKonsult.EfterNamn = konsultRequestDto.EfterNamn;
            newKonsult.AntalAr = konsultRequestDto.AntalAr;

            if(_dbContext.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeleteKonsult(int id)
        {
            var findKonsult = _dbContext.Konsults.FirstOrDefault(i => i.KonsultId == id);
            if(findKonsult == null)
            {
                return false;
            }
            _dbContext.Konsults.Remove(findKonsult);
            if(_dbContext.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public Konsult EditKonsult(int id, KonsultRequestDto konsultRequestDto)
        {
            var edit = _dbContext.Konsults.FirstOrDefault(i => i.KonsultId == id);
            if(edit == null)
            {
                return null;
            }
            edit.ForNamn = konsultRequestDto.ForNamn;
            edit.EfterNamn = konsultRequestDto.EfterNamn;
            edit.AntalAr = konsultRequestDto.AntalAr;
            if(_dbContext.SaveChanges() == 1)
            {
                return edit;
            }
            return null;

        }

        public ICollection<Konsult> GetKonsults()
        {
            var konsultList = _dbContext.Konsults.ToList();
            return konsultList;
        }
    }
}

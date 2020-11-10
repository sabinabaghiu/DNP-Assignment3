using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Server.Persistence;

namespace Assignment1.Data
{
    public class AdultService : IAdultsService
    {
        private FileContext fileContext;
        private IList<Adult> adults;

        public AdultService(FileContext fileContext)
        {
            this.fileContext = fileContext;
            this.adults = fileContext.Adults;
        }

        public void SaveChanges()
        {
            fileContext.SaveChanges();
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int maxFamilyId = adults.Max(adult => adult.Id);
            adult.Id = (++maxFamilyId);
            adults.Add(adult);
            SaveChanges();
            Console.Out.WriteLine(adult);
            return adult;
        }

        public async Task<Adult> RemoveAdultAsync(int Id)
        {
            Adult toRemove = adults.First(adult => adult.Id == Id);
            adults.Remove(toRemove);
            SaveChanges();
            return toRemove;
        }
    }
}
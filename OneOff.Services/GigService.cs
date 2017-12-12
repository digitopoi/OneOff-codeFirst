using OneOff.Contracts;
using OneOff.Data.Entities;
using OneOff.Models;
using OneOff.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOff.Services
{
    public class GigService : IGigService
    {
        private readonly Guid _userId;

        public GigService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> CreateGig(GigViewModel model, bool isArtist)
        {
            var entity =
                new GigEntity()
                {
                    OwnerId = _userId,
                    Date = model.Date,
                    PostalCode = model.PostalCode
                };

            if (isArtist)
            {
                entity.IsRequest = true;
            }
            else
            {
                entity.IsRequest = false;
            }

            using (var context = new ApplicationDbContext())
            {
                context.Gigs.Add(entity);
                return await context.SaveChangesAsync() == 1;
            }
             
        }

    }
}

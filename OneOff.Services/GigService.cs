using OneOff.Contracts;
using OneOff.Data.Entities;
using OneOff.Models;
using OneOff.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<bool> DeleteGig(int gigId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = await context
                                    .Gigs
                                    .Where(e => e.GigId == gigId && e.OwnerId == _userId)
                                    .FirstOrDefaultAsync();
                context.Gigs.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }

        //  TODO: not needed until mapping
        public Task<IEnumerable<GigViewModel>> GetAllGigs()
        {
            throw new NotImplementedException();
        }

        public async Task<GigViewModel> GetGigById(int gigId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = await context
                                    .Gigs
                                    .Where(e => e.GigId == gigId && e.OwnerId == _userId)
                                    .FirstOrDefaultAsync();
                return new GigViewModel
                {
                    Date = entity.Date,
                    PostalCode = entity.PostalCode,
                };
            }
        }

        public IEnumerable<GigViewModel> GetGigsByUser()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context
                                .Gigs
                                .Where(e => e.OwnerId == _userId)
                                .Select(
                                    e => new GigViewModel
                                    {
                                        Date = e.Date,
                                        PostalCode = e.PostalCode,
                                    }
                                );
                return query.ToArray();
            }
        }

        public async Task<bool> UpdateGig(int id, GigViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = await context
                                        .Gigs
                                        .Where(e => e.GigId == id && e.OwnerId == _userId)
                                        .FirstOrDefaultAsync();
                entity.Date = model.Date;
                entity.PostalCode = model.PostalCode;

                return await context.SaveChangesAsync() == 1;
            }
        }
    }
}

using OneOff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOff.Contracts
{
    public interface IGigService
    {
        Task<bool> CreateGig(GigViewModel model, bool isArtist);
        IEnumerable<GigViewModel> GetGigsByUser();
        Task<GigViewModel> GetGigById(int gigId);
        Task<bool> UpdateGig(GigViewModel model);
        Task<bool> DeleteGig(int gigId);
        Task<IEnumerable<GigViewModel>> GetAllGigs();
    }
}

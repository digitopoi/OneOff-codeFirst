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
        Task<bool> CreateGigAsync(GigViewModel model, bool isArtist);
        IEnumerable<GigViewModel> GetGigsByUser();
        Task<GigViewModel> GetGigByIdAsync(int gigId);
        Task<bool> UpdateGigAsync(int id, GigViewModel model);
        Task<bool> DeleteGigAsync(int gigId);
        Task<IEnumerable<GigViewModel>> GetAllGigsAsync();
    }
}

using OneOff.Models;
using OneOff.Models.ViewModels;
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
        IEnumerable<GigEditViewModel> GetGigsByUser();
        Task<GigEditViewModel> GetGigByIdAsync(int gigId);
        Task<bool> UpdateGigAsync(int id, GigEditViewModel model);
        Task<bool> DeleteGigAsync(int gigId);
        Task<IEnumerable<GigViewModel>> GetAllGigsAsync();
    }
}

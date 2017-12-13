using Microsoft.AspNet.Identity;
using OneOff.Models.ViewModels;
using OneOff.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OneOff.API.Controllers
{
    [Authorize]
    public class GigController : ApiController
    {
        //  GET: /api/gig
        public IHttpActionResult Get()
        {
            var gigService = CreateGigService();

            var gigs = gigService.GetGigsByUser();

            return Ok(gigs);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var gigService = CreateGigService();

            var gig = await gigService.GetGigByIdAsync(id);

            return Ok();
        }

        public async Task<IHttpActionResult> Post(GigViewModel model, bool isArtist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gigService = CreateGigService();

            if (await gigService.CreateGigAsync(model, isArtist))
                return Ok();

            return InternalServerError();
        }

        public async Task<IHttpActionResult> Put(int id, GigEditViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gigService = CreateGigService();

            if (await gigService.UpdateGigAsync(id, model))
                return Ok();

            return InternalServerError();
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            var gigService = CreateGigService();

            if (await gigService.DeleteGigAsync(id))
                return Ok();

            return InternalServerError();
        }

        private GigService CreateGigService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gigService = new GigService(userId);
            return gigService;
        }
    }
}

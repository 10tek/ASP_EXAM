using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Edu.DataAccess.EF;
using Edu.Domain;
using MediatR;
using Edu.WebAPI.ApplicationMediator.GetApplication;
using System.Threading;
using Edu.DTOs;
using Edu.WebAPI.ApplicationMediator.CreateApplication;
using Edu.WebAPI.ApplicationMediator.EditApplication;
using Edu.WebAPI.ApplicationMediator.DeleteApplication;

namespace Edu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMediator _mediator;

        public ApplicationsController(DataContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(Guid id)
        {
            var request = new GetApplicationRequest(id);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // PUT: api/Applications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication(Guid id, ApplicationDTO applicationDTO)
        {
            var request = new EditApplicationRequest(id, applicationDTO);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // POST: api/Applications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(ApplicationDTO applicationDTO)
        {
            var request = new CreateApplicationCommand(applicationDTO);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Application>> DeleteApplication(Guid id)
        {
            var request = new DeleteApplicationRequest(id);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        private bool ApplicationExists(Guid id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}

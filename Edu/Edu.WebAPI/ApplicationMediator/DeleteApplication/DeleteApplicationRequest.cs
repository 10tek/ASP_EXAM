using Edu.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.WebAPI.ApplicationMediator.DeleteApplication
{
    public class DeleteApplicationRequest : IRequest<bool>
    {
        public Guid ApplicationId { get; }

        public DeleteApplicationRequest(Guid id)
        {
            ApplicationId = id;
        }
    }
}

using Edu.Domain;
using Edu.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.WebAPI.ApplicationMediator.GetApplication
{
    public class GetApplicationRequest : IRequest<ApplicationDTO>
    {
        public Guid ApplicationId { get; }

        public GetApplicationRequest(Guid id)
        {
            ApplicationId = id;
        }
    }
}

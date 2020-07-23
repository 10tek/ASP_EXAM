using AutoMapper;
using Edu.DataAccess.EF.Implementations;
using Edu.DataAccess.Interfaces;
using Edu.Domain;
using Edu.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Edu.WebAPI.ApplicationMediator.GetApplication
{
    public class GetApplicationRequestHandler : IRequestHandler<GetApplicationRequest, ApplicationDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetApplicationRequestHandler( IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicationDTO> Handle(GetApplicationRequest request, CancellationToken cancellationToken)
        {
            var app = await _unitOfWork.ApplicationRepository.GetAsync(request.ApplicationId);

            return _mapper.Map<ApplicationDTO>(app);
        }
    }
}

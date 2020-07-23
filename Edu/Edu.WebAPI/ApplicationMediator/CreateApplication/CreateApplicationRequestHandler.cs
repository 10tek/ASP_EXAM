using AutoMapper;
using Edu.DataAccess.Interfaces;
using Edu.Domain;
using Edu.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Edu.WebAPI.ApplicationMediator.CreateApplication
{
    public class CreateApplicationRequestHandler : IRequestHandler<CreateApplicationCommand, ApplicationDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateApplicationRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicationDTO> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
        {
            var app = new Application
            {
                College = request.College,
                IIN = request.IIN,
                Score = request.Score,
                FirstProfile = request.FirstProfile,
                SecondProfile = request.SecondProfile
            };

            await _unitOfWork.ApplicationRepository.CreateAsync(app);
            await _unitOfWork.Save();
            return _mapper.Map<ApplicationDTO>(app);
        }
    }
}

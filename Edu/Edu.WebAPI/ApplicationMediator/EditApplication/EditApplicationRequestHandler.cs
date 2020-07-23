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

namespace Edu.WebAPI.ApplicationMediator.EditApplication
{
    public class EditApplicationRequestHandler : IRequestHandler<EditApplicationRequest, ApplicationDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditApplicationRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicationDTO> Handle(EditApplicationRequest request, CancellationToken cancellationToken)
        {
            var app = new Application
            {
                Id = request.Id,
                College = request.College,
                IIN = request.IIN,
                Score = request.Score,
                FirstProfile = request.FirstProfile,
                SecondProfile = request.SecondProfile
            };

            _unitOfWork.ApplicationRepository.Edit(app);
            await _unitOfWork.Save();
            return _mapper.Map<ApplicationDTO>(app);
        }
    }
}

using AutoMapper;
using Edu.DataAccess.Interfaces;
using Edu.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Edu.WebAPI.ApplicationMediator.DeleteApplication
{
    public class DeleteApplicationRequestHandler : IRequestHandler<DeleteApplicationRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteApplicationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteApplicationRequest request, CancellationToken cancellationToken)
        {
            _unitOfWork.ApplicationRepository.Remove(request.ApplicationId);
            await _unitOfWork.Save();
            return true;
        }
    }
}

using Edu.Domain;
using Edu.Domain.Enums;
using Edu.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.WebAPI.ApplicationMediator.CreateApplication
{
    public class CreateApplicationCommand : IRequest<ApplicationDTO>
    {
        public string IIN { get; set; }
        public int Score { get; set; }
        public Profile FirstProfile { get; set; }
        public Profile SecondProfile { get; set; }
        public College College { get; set; }

        public CreateApplicationCommand(ApplicationDTO applicationDTO)
        {
            IIN = applicationDTO.IIN;
            Score = applicationDTO.Score;
            FirstProfile = applicationDTO.FirstProfile;
            SecondProfile = applicationDTO.SecondProfile;
            College = applicationDTO.College;
        }
    }
}

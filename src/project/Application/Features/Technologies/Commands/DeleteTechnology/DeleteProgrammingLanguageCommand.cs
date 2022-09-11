using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly ITechnologyRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _programmingLanguageBusinessRules;

            public DeleteTechnologyCommandHandler(ITechnologyRepository programmingLanguageRepository, IMapper mapper, TechnologyBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.TechnologyMustExist(request.Id);

                Technology programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                Technology deletedTechnology = await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
                DeletedTechnologyDto result = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);

                return result;
            }
        }
    }
}

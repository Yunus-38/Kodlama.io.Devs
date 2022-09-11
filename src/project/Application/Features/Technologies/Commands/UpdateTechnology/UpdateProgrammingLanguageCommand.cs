using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _programmingLanguageBusinessRules;

            public UpdateTechnologyCommandHandler(ITechnologyRepository programmingLanguageRepository, IMapper mapper, TechnologyBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.TechnologyNameCanNotBeDuplicated(request.Name);

                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology programmingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedTechnology);
                UpdatedTechnologyDto result = _mapper.Map<UpdatedTechnologyDto>(programmingLanguage);

                return result;
            }
        }
    }
}

using DevFreela.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetSkillById
{
    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, int>
    {
        private readonly ISkillRepository _skillRepository;
        public GetSkillByIdQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<int> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = _skillRepository.GetSkillByIdAsync(request.Id);

            return skill.Id;
        }
    }
}

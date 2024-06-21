using Bogus;
using Hepsi.Api.Application.Bases;
using Hepsi.Api.Application.Interfaces.AutoMapper;
using Hepsi.Api.Application.Interfaces.UnitOfWorks;
using Hepsi.Api.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsi.Api.Application.Features.Brands.Commands.CreateBrands
{
    public class CreateBrandsHandler : BaseHandler, IRequestHandler<CreateBrandsCommandRequest, Unit>
    {
        public CreateBrandsHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandsCommandRequest request, CancellationToken cancellationToken)
        {
            Faker faker = new("tr");
            List<Brand> brands = new();

            for(int i=1;i<=1000;i++)
            {
                brands.Add(new(faker.Commerce.Department(1)));
            }

            await unitOfWork.GetWriteReporsitory<Brand>().AddRangeAsync(brands);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

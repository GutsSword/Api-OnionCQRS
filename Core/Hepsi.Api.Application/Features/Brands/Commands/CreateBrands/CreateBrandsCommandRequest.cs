using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsi.Api.Application.Features.Brands.Commands.CreateBrands
{
    public class CreateBrandsCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}

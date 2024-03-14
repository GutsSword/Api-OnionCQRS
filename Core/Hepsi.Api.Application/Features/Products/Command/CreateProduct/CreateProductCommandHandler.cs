using Hepsi.Api.Application.Bases;
using Hepsi.Api.Application.Features.Products.Rules;
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

namespace Hepsi.Api.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest,Unit>
    {
        //private readonly IUnitOfWork unitOfWork;
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(ProductRules productRules,IMapper mapper, IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor) : base(mapper,unitOfWork,httpContextAccessor)
        {
            //this.unitOfWork = unitOfWork;  BaseHandler'da tanımlı.
            this.productRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productRules.ProductTitleMustNotBeSame(products, request.Title);

            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

            await unitOfWork.GetWriteReporsitory<Product>().AddAsync(product);
            if(await unitOfWork.SaveAsync() is not 0)
            {
                foreach(var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteReporsitory<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId,
                    });
                }

                await unitOfWork.SaveAsync();
            }

            return Unit.Value;

        }
    }
}

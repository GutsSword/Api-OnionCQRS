using Hepsi.Api.Application.Interfaces.UnitOfWorks;
using Hepsi.Api.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsi.Api.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
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

        }
    }
}

﻿using AutoMapper;
using CqrsMediatR.MedHandlers.Commands.Requests;
using CqrsMediatR.Repositories;
using MediatR;

namespace CqrsMediatR.MedHandlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<bool> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var isDeleted = _productRepository.DeleteProduct(request.Id);
            return Task.FromResult(isDeleted);
        }
    }
}

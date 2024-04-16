﻿using Express_Management.Applications.ProductGroups;
using Express_Management.DTOs;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Express_Management.ApiOData
{
    public class ProductGroupController : ODataController
    {
        private readonly ProductGroupService _productGroupService;

        public ProductGroupController(ProductGroupService productGroupService)
        {
            _productGroupService = productGroupService;
        }

        [EnableQuery]
        public IQueryable<ProductGroupDto> Get()
        {
            return _productGroupService
                .GetAll()
                .Select(rec => new ProductGroupDto
                {
                    Id = rec.Id,
                    RowGuid = rec.RowGuid,
                    Name = rec.Name,
                    Description = rec.Description,
                    CreatedAtUtc = rec.CreatedAtUtc
                });
        }


    }
}

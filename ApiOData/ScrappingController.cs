﻿using Express_Management.Applications.Scrappings;
using Express_Management.DTOs;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Express_Management.ApiOData
{
    public class ScrappingController : ODataController
    {
        private readonly ScrappingService _scrappingService;

        public ScrappingController(ScrappingService scrappingService)
        {
            _scrappingService = scrappingService;
        }

        [EnableQuery]
        public IQueryable<ScrappingDto> Get()
        {
            return _scrappingService
                .GetAll()
                .Include(x => x.Warehouse)
                .Select(rec => new ScrappingDto
                {
                    Id = rec.Id,
                    Number = rec.Number,
                    ScrappingDate = rec.ScrappingDate,
                    Status = rec.Status,
                    Warehouse = rec.Warehouse!.Name,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                });
        }




    }
}

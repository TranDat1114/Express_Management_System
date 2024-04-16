﻿using Express_Management.Applications.NumberSequences;
using Express_Management.DTOs;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Express_Management.ApiOData
{
    public class NumberSequenceController : ODataController
    {
        private readonly NumberSequenceService _numberSequenceService;

        public NumberSequenceController(NumberSequenceService numberSequenceService)
        {
            _numberSequenceService = numberSequenceService;
        }

        [EnableQuery]
        public IQueryable<NumberSequenceDto> Get()
        {
            return _numberSequenceService
                .GetAll()
                .Select(rec => new NumberSequenceDto
                {
                    Id = rec.Id,
                    EntityName = rec.EntityName,
                    Prefix = rec.Prefix,
                    Suffix = rec.Suffix,
                    LastUsedCount = rec.LastUsedCount,
                    CreatedAtUtc = rec.CreatedAtUtc
                });
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xpepper.Core.Data.EF;
using Xpepper.Core.Data.MongoDb;

namespace Xpepper.Core.Data.TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public static Guid[] LastStackItemsGuidList;

      
        
        private readonly DbUnitOfWork<TestContext> _unitOfWork;

        public WeatherForecastController(DbUnitOfWork<TestContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<TestEntity> Get()
        {
            var repo = _unitOfWork.GetRepository<TestEntity>();

            var lastStackItems = new TestEntity[0];
            if (LastStackItemsGuidList != null && LastStackItemsGuidList.Length > 0)
            {
                lastStackItems = repo.Where(x => LastStackItemsGuidList.Contains(x.Id)).ToArray();
            }
            var newItems = Enumerable.Range(0, 500).Select(x => new TestEntity() { Name = Guid.NewGuid().ToString(), CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.Now }).ToArray();
            repo.InsertRange(newItems);
            _unitOfWork.SaveChanges();
            LastStackItemsGuidList = newItems.Select(x => x.Id).Take(10).ToArray();
            return lastStackItems;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CodeAssignmentService.DeliveryDate.Models.DTO;
using CodeAssignmentService.DeliveryDate.Models.Request;
using CodeAssignmentService.DeliveryDate.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodingAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryDateController :ControllerBase
    {
        private readonly ILogger<DeliveryDateController> _logger;
        private readonly IDeliveryDateScheduleService _deliveryDateScheduleService;
        public DeliveryDateController(ILogger<DeliveryDateController> logger, IDeliveryDateScheduleService deliveryDateScheduleService)
        {
            _deliveryDateScheduleService = deliveryDateScheduleService;
            _logger = logger;
        }

        [HttpPost]
        public IEnumerable<AvailableDeliveryDate> Post([FromBody]AvailableDeliveryDateQuery query)
        {
            return _deliveryDateScheduleService.CalculateAvailableDeliveryDatesForProducts(query.PostalCode,
                query.Products);
        }
    }
}
﻿using System.Collections.Generic;
using CodeAssignmentService.Models;

namespace CodingAssignment.Models
{
    public class GetDeliveryDateRequest
    {
        public int PostalCode { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
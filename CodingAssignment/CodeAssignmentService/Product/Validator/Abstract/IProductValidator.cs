using System.Collections.Generic;
using CodeAssignmentService.Models;

namespace CodeAssignmentService.Product.Validator.Abstract
{
    public interface IProductValidator
    {
        bool AreValid(IEnumerable<ProductDTO> products);
    }
}
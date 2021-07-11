using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.ValidationTool
{
    public static class EntityValidator
    {
        public static void Validate(IValidator validator,Object model)
        {
            var results = validator.Validate(model);
            
            if (results.Errors.Count > 0)
            {
                throw new ValidationException(results.Errors);
            }

        }
    }
}

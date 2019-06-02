using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Validations
{
    public class DateTimeValidation:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null && value is DateTime)
            {
                var conteudo = (DateTime)value;

                return conteudo >= DateTime.MinValue
                    && conteudo <= DateTime.MaxValue;
            }
            else if (true)
            {

            }

            return false;
        }

    }
}
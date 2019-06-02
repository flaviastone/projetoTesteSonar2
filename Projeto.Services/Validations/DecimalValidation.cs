using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Validations
{
    //herdar de ValidationAttribute
    public class DecimalValidation:ValidationAttribute
    {
        //sobrescrever metodo isValid
        public override bool IsValid(object value)
        {
            //testar campos
            if (value != null && value is decimal)
            {
                //converter decimal
                var conteudo = (decimal)value;
                return conteudo > 0;
            }

            return false;
        }


    }
}
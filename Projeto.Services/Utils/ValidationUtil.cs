using System;
using System.Collections; //importando
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding; //importando

namespace Projeto.Services.Utils
{
    public class ValidationUtil
    {
        public static Hashtable GetErrors(ModelStateDictionary modelState)
        {
            var erros = new Hashtable();

            //percorrendo cada elemento contido no ModelState
            foreach(var state in modelState)
            {
                //verificar se o elemento contem erros de validação
                if(state.Value.Errors.Count > 0)
                {
                    //adicionar as mensagens de erro de validação
                    //no objeto hashtable CHAVE,VALOR
                    erros[state.Key] = state.Value.Errors
                        .Select(e => e.ErrorMessage).ToList();
                }
            }

            return erros;
        }
    }
}
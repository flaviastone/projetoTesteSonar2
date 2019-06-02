using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper; //importando
using Projeto.Entities; //importando
using Projeto.Services.Models; //importando

namespace Projeto.Services.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        //ctor + 2x[tab]
        public ViewModelToEntityMap()
        {
            CreateMap<DependenteCadastroViewModel, Dependente>();
            CreateMap<DependenteEdicaoViewModel, Dependente>();

            CreateMap<FuncionarioCadastroViewModel, Funcionario>();
            CreateMap<FuncionarioEdicaoViewModel, Funcionario>();
        }
    }
}
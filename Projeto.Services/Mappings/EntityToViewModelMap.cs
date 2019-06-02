using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper; //importando
using Projeto.Entities; //importando
using Projeto.Services.Models; //importando

namespace Projeto.Services.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        //ctor + 2x[tab]
        public EntityToViewModelMap()
        {
            CreateMap<Dependente, DependenteConsultaViewModel>();
            CreateMap<Funcionario, FuncionarioConsultaViewModel>();
        }
    }
}
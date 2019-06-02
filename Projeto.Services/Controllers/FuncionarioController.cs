using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Services.Models;
using Projeto.Services.Utils;
using Projeto.BLL;
using Projeto.Entities;
using AutoMapper;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/funcionario")]
    public class FuncionarioController : ApiController
    {
        private FuncionarioBusiness business;

        public FuncionarioController()
        {
            business = new FuncionarioBusiness();
        }

        [HttpPost] //Requisição HTTP POST
        public HttpResponseMessage Post(FuncionarioCadastroViewModel model)
        {
            //verificando se a model passou nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {
                    var funcionario = Mapper.Map<Funcionario>(model);
                    business.Cadastrar(funcionario);


                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Funcionário cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    //retornar status de erro 500 INTERNAL SERVER ERROR
                    return Request.CreateResponse
                        (HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                //retornar status de erro 400 BAD REQUEST
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                                    ValidationUtil.GetErrors(ModelState));
            }
        }

        [HttpPut] //Requisição HTTP PUT
        public HttpResponseMessage Put(FuncionarioEdicaoViewModel model)
        {
            //verificando se a model passou nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {
                    //converter objeto ViewModel em entidade
                    var funcionario = Mapper.Map<Funcionario>(model);
                    business.Atualizar(funcionario);

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Funcionário atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    //retornar status de erro 500 INTERNAL SERVER ERROR
                    return Request.CreateResponse
                        (HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                //retornar status de erro 400 BAD REQUEST
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                                    ValidationUtil.GetErrors(ModelState));
            }
        }

        [HttpDelete] //Requisição HTTP DELETE
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                business.Excluir(id);

                return Request.CreateResponse(HttpStatusCode.OK,
                    "Funcionário excluído com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status de erro 500 INTERNAL SERVER ERROR
                return Request.CreateResponse
                    (HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet] //Requisição HTTP GET
        public HttpResponseMessage GetAll()
        {
            try
            {
                var lista = business.ConsultarTodos();

                //Converter para listaViewModel
                var model = Mapper.Map<List<FuncionarioConsultaViewModel>>(lista);
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                //retornar status de erro 500 INTERNAL SERVER ERROR
                return Request.CreateResponse
                    (HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet] //Requisição HTTP GET
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var funcionario = business.ConsultarPorId(id);
                var model = Mapper.Map<FuncionarioConsultaViewModel>(funcionario);


                return Request.CreateResponse(HttpStatusCode.OK,model);
            }
            catch (Exception e)
            {
                //retornar status de erro 500 INTERNAL SERVER ERROR
                return Request.CreateResponse
                    (HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

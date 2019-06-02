using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Services.Models; //importando
using Projeto.Services.Utils; //importando
using Projeto.Entities;
using Projeto.BLL;
using AutoMapper;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/dependente")]
    public class DependenteController : ApiController
    {
        private DependenteBusiness business;

        public DependenteController()
        {
            business = new DependenteBusiness();
        }

        [HttpPost] //Requisição HTTP POST
        public HttpResponseMessage Post(DependenteCadastroViewModel model)
        {
            //verificando se a model passou nas regras de validação
            if(ModelState.IsValid)
            {
                try
                {
                    //converter objeto ViewModel em entidade
                    var dependente = Mapper.Map<Dependente>(model);
                    business.Cadastrar(dependente);

                    return Request.CreateResponse(HttpStatusCode.OK, 
                        "Dependente cadastrado com sucesso.");
                }
                catch(Exception e)
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
        public HttpResponseMessage Put(DependenteEdicaoViewModel model)
        {
            //verificando se a model passou nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {
                    //converter objeto ViewModel em entidade
                    var dependente = Mapper.Map<Dependente>(model);
                    business.Atualizar(dependente);

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Dependente atualizado com sucesso.");
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

                // não tem que converter em objeto ViewModel
                business.Excluir(id);

                return Request.CreateResponse(HttpStatusCode.OK,
                    "Dependente excluído com sucesso.");
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
                var model = Mapper.Map<List<DependenteConsultaViewModel>>(lista);

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
                var dependente = business.ConsultarPorId(id);
                //Converter para listaViewModel
                var model = Mapper.Map<DependenteConsultaViewModel>(dependente);

                return Request.CreateResponse(HttpStatusCode.OK, model);
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

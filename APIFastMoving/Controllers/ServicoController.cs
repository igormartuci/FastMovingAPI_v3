using APIFastMoving.Models.Servico;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace APIFastMoving.Controllers
{
    public class ServicoController : ApiController
    {
        private readonly ServicoRepositorio _servicosRepositorio;

        public ServicoController()
        {
            _servicosRepositorio = new ServicoRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Servico> List()
        {
            return _servicosRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Servico GetServico(int id)
        {
            var Servico = _servicosRepositorio.GetById(id);


            return Servico;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Servico Servico)
        {
            _servicosRepositorio.Insert(Servico);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Servico s = new Servico();
            s.IDSERV = id;
            _servicosRepositorio.Delete(s);
        }
    }
}
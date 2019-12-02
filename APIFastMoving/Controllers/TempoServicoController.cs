using APIFastMoving.Models.TempoServico;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace APIFastMoving.Controllers
{
    public class TempoServicoController : ApiController
    {
        private readonly TempoServicoRepositorio _temposservicoRepositorio;

        public TempoServicoController()
        {
            _temposservicoRepositorio = new TempoServicoRepositorio();
        }

        [HttpGet]
        public IEnumerable<TempoServico> List()
        {
            return _temposservicoRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public TempoServico GetTempoServico(int id)
        {
            var TempoServico = _temposservicoRepositorio.GetById(id);


            return TempoServico;
        }
    }
}
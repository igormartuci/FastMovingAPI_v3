using APIFastMoving.Models.ServicoExtra;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace APIFastMoving.Controllers
{
    public class ServicoExtraController : ApiController
    {
        private readonly ServicoExtraRepositorio _servicosextraRepositorio;

        public ServicoExtraController()
        {
            _servicosextraRepositorio = new ServicoExtraRepositorio();
        }

        [HttpGet]
        public IEnumerable<ServicoExtra> List()
        {
            return _servicosextraRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public ServicoExtra GetServicoExtra(int id)
        {
            var ServicoExtra = _servicosextraRepositorio.GetById(id);


            return ServicoExtra;
        }
    }
}
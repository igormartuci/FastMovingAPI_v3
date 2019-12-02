using APIFastMoving.Models.TipoCarga;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace APIFastMoving.Controllers
{
    public class TipoCargaController : ApiController
    {
        private readonly TipoCargaRepositorio _tiposcargaRepositorio;

        public TipoCargaController()
        {
            _tiposcargaRepositorio = new TipoCargaRepositorio();
        }

        [HttpGet]
        public IEnumerable<TipoCarga> List()
        {
            return _tiposcargaRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public TipoCarga GetTipoCarga(int id)
        {
            var TipoCarga = _tiposcargaRepositorio.GetById(id);


            return TipoCarga;
        }

    }
}
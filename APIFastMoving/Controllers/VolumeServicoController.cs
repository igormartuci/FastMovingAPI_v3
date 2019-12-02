using APIFastMoving.Models.VolumeServico;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace APIFastMoving.Controllers
{
    public class VolumeServicoController : ApiController
    {
        private readonly VolumeServicoRepositorio _volumeservicoRepositorio;

        public VolumeServicoController()
        {
            _volumeservicoRepositorio = new VolumeServicoRepositorio();
        }

        [HttpGet]
        public IEnumerable<VolumeServico> List()
        {
            return _volumeservicoRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public VolumeServico GetVolumeServico(int id)
        {
            var VolumeServico = _volumeservicoRepositorio.GetById(id);


            return VolumeServico;
        }
    }
}
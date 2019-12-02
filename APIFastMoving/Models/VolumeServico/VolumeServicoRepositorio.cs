using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.VolumeServico
{
    public class VolumeServicoRepositorio : IRepositorio<VolumeServico>
    {
        public void Delete(VolumeServico item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VolumeServico> GetAll()
        {
            return VolumeServicoDAL.GetVolumesServico();
        }

        public VolumeServico GetById(int id)
        {
            return VolumeServicoDAL.GetVolumeServico(id);
        }

        public void Insert(VolumeServico item)
        {
            throw new NotImplementedException();
        }

        public VolumeServico Login(VolumeServico item)
        {
            throw new NotImplementedException();
        }

        public void Update(VolumeServico item)
        {
            throw new NotImplementedException();
        }
    }
}
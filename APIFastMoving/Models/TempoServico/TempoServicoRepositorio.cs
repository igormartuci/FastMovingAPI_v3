using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.TempoServico
{
    public class TempoServicoRepositorio : IRepositorio<TempoServico>
    {
        public void Delete(TempoServico item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TempoServico> GetAll()
        {
            return TempoServicoDAL.GetTemposServico();
        }

        public TempoServico GetById(int id)
        {
            return TempoServicoDAL.GetTempoServico(id);
        }

        public void Insert(TempoServico item)
        {
            throw new NotImplementedException();
        }

        public TempoServico Login(TempoServico item)
        {
            throw new NotImplementedException();
        }

        public void Update(TempoServico item)
        {
            throw new NotImplementedException();
        }
    }
}
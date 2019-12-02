using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.TipoCarga
{
    public class TipoCargaRepositorio : IRepositorio<TipoCarga>
    {
        public void Delete(TipoCarga item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoCarga> GetAll()
        {
            return TipoCargaDAL.GetTiposCarga();
        }

        public TipoCarga GetById(int id)
        {
            return TipoCargaDAL.GetTipoCarga(id);
        }

        public void Insert(TipoCarga item)
        {
            throw new NotImplementedException();
        }

        public TipoCarga Login(TipoCarga item)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoCarga item)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.ServicoExtra
{
    public class ServicoExtraRepositorio : IRepositorio<ServicoExtra>
    {
        public void Delete(ServicoExtra item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServicoExtra> GetAll()
        {
            return ServicoExtraDAL.GetServicosExtra();
        }

        public ServicoExtra GetById(int id)
        {
            return ServicoExtraDAL.GetServicoExtra(id);
        }

        public void Insert(ServicoExtra item)
        {
            throw new NotImplementedException();
        }

        public ServicoExtra Login(ServicoExtra item)
        {
            throw new NotImplementedException();
        }

        public void Update(ServicoExtra item)
        {
            throw new NotImplementedException();
        }
    }
}
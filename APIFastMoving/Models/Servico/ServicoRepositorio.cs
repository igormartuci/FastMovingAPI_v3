using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.Servico
{

    public class ServicoRepositorio : IRepositorio<Servico>
    {
        public void Delete(Servico item)
        {
            ServicoDAL.DeleteServico(item.IDSERV);
        }

        public IEnumerable<Servico> GetAll()
        {
            return ServicoDAL.GetServicos();
        }

        public Servico GetById(int id)
        {
            return ServicoDAL.GetServico(id);
        }

        public void Insert(Servico item)
        {
            ServicoDAL.InsertServico(item);
        }

        public Servico Login(Servico item)
        {
            throw new NotImplementedException();
        }

        public void Update(Servico item)
        {
            throw new NotImplementedException();
        }
    }
}
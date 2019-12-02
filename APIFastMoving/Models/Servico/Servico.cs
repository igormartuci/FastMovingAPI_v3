using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.Servico
{
    public class Servico
    {
        public int IDSERV { get; set; }
        public float VALORSERV { get; set; }
        public string OPVOLSERV { get; set; }
        public string OPTPCARGA { get; set; }
        public string OPSERVEXTRA { get; set; }
        public string OPTEMPSERV { get; set; }
        public string OPADICIONAL { get; set; }
        public string OPORIGEM { get; set; }
        public string OPDESTINO { get; set; }
    }
}
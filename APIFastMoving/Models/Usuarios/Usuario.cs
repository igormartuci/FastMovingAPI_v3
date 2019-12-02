using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models
{
    public class Usuario
    {
        public int IDUSU { get; set; }
        public string EMAILUSU { get; set; }
        public string SENHAUSU { get; set; }
        public string CPFUSU { get; set; }
        public string NOMEUSU { get; set; }
        public string SOBRENOMEUSU { get; set; }
        public string DATANASCUSU { get; set; }
        public string NRCARTAO { get; set; }
        public string NMCARTAO { get; set; }
        public int CVVCARTAO { get; set; }
        public string DTVALCARTAO { get; set; }
    }
}
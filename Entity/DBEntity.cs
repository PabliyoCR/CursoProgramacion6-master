using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DBEntity
    {
        // Guarda el codigo de error que la BBDD va a retornar
        public int CodeError { get; set; }

        // Mensaje de error
        public string MsgError { get; set; }
    }
}

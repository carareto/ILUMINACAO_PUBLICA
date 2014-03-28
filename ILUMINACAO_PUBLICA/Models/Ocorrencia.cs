using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ILUMINACAO_PUBLICA.Models
{
    public class Ocorrencia
    {
        public int OcorrenciaID { get; set; }
        public string Nome { get; set; }

        public int PrefeituraId { get; set; }
        public virtual Prefeitura Prefeitura { get; set; }
    }
}
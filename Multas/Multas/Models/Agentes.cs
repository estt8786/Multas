﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Multas.Models {
   public class Agentes {

        /// atributos:
        /// - nº agente
        /// - nome
        /// - esquadra
        /// - foto
        // Agentes

        public int ID { get; set; }

        public string Nome { get; set; }

        public string Esquadra { get; set; }

        public string Fotografia { get; set; }

        // lista das multas associadas ao Agente
        public ICollection<Multas> ListaDeMultas { get; set; }


    }
}






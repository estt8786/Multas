using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Multas.Models {
   public class Multas {
        public int ID { get; set; }

        public string Infracao { get; set; }

        public string LocalDaMulta { get; set; }

        public decimal ValorMulta { get; set; }

        public DateTime DataDaMulta { get; set; }

        //******************************************
        // criação das chaves forateiras(FKs)

        // criar o FK para a tabela dos Agentes
        [ForeignKey("Agente")] // tem que indicar na linha 26 tabela Agentes do atributo "Agente"
        public int AgenteFK { get; set; }
        public Agentes Agente { get; set; } // representa a pessoa que passou a multa da tabela Agentes

        // criar o FK para a tabela das Viaturas
        [ForeignKey("Viatura")] 
        public int ViaturaFK { get; set; }
        public Viaturas Viatura { get; set; } // representa a viatura que recebeu a multa da tabela Viaturas


        // criar o FK para a tabela dos Condutores
        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; }
        public Condutores Condutor { get; set; } // representa a pessoa que recebeu a multa da tabela Condutores



    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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

        // ******************** CONTROLO DO CAMPO NOME *********************
        [Required(ErrorMessage = "Por favor, escreva o Nome do Agente!")]
        [RegularExpression("([A-ZÁÉÍÓÚa-záéíóúàèìòùäëïöüãõâêîôûçñ]+( |-|')?)+", ErrorMessage = "Só pode escrever letras no nome. Deve começar por uma maiúscula!")]
        public string Nome { get; set; }

        // ********************* CONTROLO DO CAMPO ESQUADRA **************************
        [Required(ErrorMessage = "Não se esqueça de indicar a Esquadra onde o agente trabalha, por favor!")]
        //   [RegularExpression("(Tomar|Ourém|Torres Novas|Lisboa|Leiria)")]

        public string Esquadra { get; set; }

        public string Fotografia { get; set; }

        // lista das multas associadas ou passadas pelo Agente
        public ICollection<Multas> ListaDeMultas { get; set; }
    }
}






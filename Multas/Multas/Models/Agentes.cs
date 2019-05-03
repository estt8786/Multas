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

        // para forçar que é chave primaria PK
        [Key]
        public int ID { get; set; }

        // ******************** CONTROLO DO CAMPO NOME *********************
        // por defeito, se ficar assim aparecem as mensagens default do sistema!
        //[Required]
        [Required(ErrorMessage = "Por favor, escreva o Nome do Agente! É de preenchimento obrigatório!")]
        [StringLength(40)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùâêîôûçñ]+(( (e|(d(e|a|o)(s)?) )? |-|')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùâêîôûçñ]+){1,3}", 
            ErrorMessage = "Só pode escrever letras no nome. Deve começar por uma maiúscula!")]
        public string Nome { get; set; }

        // ********************* CONTROLO DO CAMPO ESQUADRA **************************
        [Required(ErrorMessage = "Não se esqueça de indicar a Esquadra onde o Agente trabalha, por favor! É de preenchimento obrigatório!")]
        [RegularExpression("(Tomar|Ourém|Torres Novas|Lisboa|Leiria)", 
            ErrorMessage = "Só aceita as esquadras Tomar, Ourém, Torres Novas, Lisboa ou Leiria")]
        [StringLength(30)]
        public string Esquadra { get; set; }

        // ********************* CONTROLO DO CAMPO FOTOGRAFIA **************************
        [StringLength(30)]
        public string Fotografia { get; set; }

        // lista das multas associadas ou passadas pelo Agente
        public ICollection<Multas> ListaDeMultas { get; set; }
    }
}






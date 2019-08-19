using System;
using System.ComponentModel;

namespace Model
{
    public class Applicant : People
    {
        [DisplayName("Grau de escolaridade")]
        public int Education { get; set; }
        [DisplayName("Idade")]
        public int Age { get; set; }
        [DisplayName("Tem casa própria")]
        public int Housing { get; set; }
        [DisplayName("Ja teve emprestimo consignado em seu nome?")]
        public int Loan { get; set; }
        [DisplayName("Qual nota você daria para os problemas que já teve com banco, sendo 0 nenhum e 10 muito ruins?")]
        public int Duration { get; set; }
        [DisplayName("Tempo de serviço em carteira")]
        public int EmpRateVar { get; set; }
        [DisplayName("Score Serasa")]
        public int ConsConfId { get; set; }
        public DateTime SearchData { get; set; }
        public bool DeservCredit { get; set; }
    }
}

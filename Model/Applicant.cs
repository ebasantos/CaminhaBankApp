using System;
using System.ComponentModel;

namespace Model
{
    public class Applicant : People
    {
        [DisplayName("Ensino")]
        public int Education { get; set; }
        [DisplayName("Idade")]
        public int Age { get; set; }
        [DisplayName("Casa própria")]
        public int Housing { get; set; }
        [DisplayName("Emprestimo Consignado")]
        public int Loan { get; set; }
        [DisplayName("Relacionamento com bancos")]
        public int Duration { get; set; }
        [DisplayName("Tempo de serviço em carteira")]
        public int EmpRateVar { get; set; }
        [DisplayName("Score")]
        public int ConsConfId { get; set; }
        public DateTime SearchData { get; set; }
        public bool DeservCredit { get; set; }
    }
}

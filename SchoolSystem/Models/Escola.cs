using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolSystem.Models
{
    public class Escola
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }

        private string _tipo;
        public string Tipo => _tipo;

        public DateTime? Data { get; set; }

        public string NomeResp { get; set; }
        public string TelResp { get; set; }
        public string TelefoneEsc { get; set; }
        public string EmailEsc { get; set; }



        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int NumeroRua { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string CidadeEsc { get; set; }
        public string Estado { get; set; }




        public void SetTipo(bool rdIsPublic)
        {
            this._tipo = rdIsPublic == true? "Publica" : "Privada";
        }
        public void SetTipo(string tipo) //sobrecarga para select do banco
        {
            this._tipo = tipo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SchoolSystem.Models;

namespace SchoolSystem.Formulários
{
    /// <summary>
    /// Lógica interna para CadsastrarEscola.xaml
    /// </summary>
    public partial class CadsastrarEscola : Window
    {
        private Escola _escola = new Escola();

        public CadsastrarEscola()
        {
            InitializeComponent();
            Loaded += CadsastrarEscola_Loaded;

        }



        public CadsastrarEscola(Escola escola)
        {

            InitializeComponent();
            _escola = escola;
            Loaded += CadsastrarEscola_Loaded;




        }

        private void CadsastrarEscola_Loaded(object sender, RoutedEventArgs e)
        {
            txtBairroEsc.Text = _escola.Bairro;
            txtNomeFantasia.Text = _escola.NomeFantasia;
            txtCNPJ.Text = _escola.Cnpj;
            txtCepesc.Text = _escola.Cep;

            txtnomeResponsavel.Text = _escola.NomeResp;


            txtRazaoSocial.Text = _escola.RazaoSocial;
            txtInscEstadual.Text = _escola.InscricaoEstadual;
            txtTelefoneEscola.Text = _escola.TelefoneEsc;
            txtEmalescola.Text = _escola.EmailEsc;

            txtTelefoneResponsavel.Text = _escola.TelResp;

            txtRuaEsc.Text = _escola.Rua ;
            txtNumRua.Text = _escola.NumeroRua.ToString();
            txtCidadeEsc.Text = _escola.CidadeEsc;
            txtComplementoEsc.Text = _escola.Complemento;
            cbEstado.Text =  _escola.Estado;

            if(_escola.Tipo == "Publica")
            {
                rdPublico.IsChecked = true;
            }
            else
            {
                rdPrivado.IsChecked = true;

            }

            dtpDataCriacao.SelectedDate = _escola.Data;




        }


        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            Escola escolaSelecionada = _escola;


            escolaSelecionada.NomeResp = txtnomeResponsavel.Text;
            escolaSelecionada.Cep = txtCepesc.Text;

            escolaSelecionada.NomeFantasia = txtNomeFantasia.Text;
            escolaSelecionada.RazaoSocial = txtRazaoSocial.Text;
            escolaSelecionada.Cnpj = txtCNPJ.Text;
            escolaSelecionada.InscricaoEstadual = txtInscEstadual.Text;
            escolaSelecionada.TelefoneEsc = txtTelefoneEscola.Text;
            escolaSelecionada.EmailEsc = txtEmalescola.Text;
            escolaSelecionada.Data = dtpDataCriacao.SelectedDate == null? DateTime.Today : dtpDataCriacao.SelectedDate;


            escolaSelecionada.TelResp = txtTelefoneResponsavel.Text.Trim();

            escolaSelecionada.Rua = txtRuaEsc.Text.Trim();
            escolaSelecionada.Bairro = txtBairroEsc.Text.Trim();
            escolaSelecionada.NumeroRua = Convert.ToInt32(txtNumRua.Text);
            escolaSelecionada.Cep = txtCepesc.Text;
            escolaSelecionada.CidadeEsc = txtCidadeEsc.Text;
            escolaSelecionada.Complemento = txtComplementoEsc.Text;
            escolaSelecionada.Estado = cbEstado.Text;

            bool rdtipo = rdPublico.IsChecked == true;

            escolaSelecionada.SetTipo(rdtipo);

            try
            {

                var dao = new EscolaDAO();

                if (escolaSelecionada.Id > 0)
                {
                    dao.Update(escolaSelecionada);
                    MessageBox.Show("Update feito", "Atualização do Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    
                    dao.Insert(escolaSelecionada);
                    MessageBox.Show("Insert feito", "Atualização do Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch 
            {
                MessageBox.Show("Houveram Erros na realização da tarefa", "Falha ao atualizar o Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Error);

            }







        }
    }
}

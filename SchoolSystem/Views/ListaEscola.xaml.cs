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
using SchoolSystem.Formulários;

namespace SchoolSystem.Views
{
    /// <summary>
    /// Lógica interna para ListaEscola.xaml
    /// </summary>
    public partial class ListaEscola : Window
    {
        

        public ListaEscola()
        {
            InitializeComponent();
            Loaded += ListaEscola_Loaded;

        }

        public void ListaEscola_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new EscolaDAO();
                List<Escola> listaDeEscolas = dao.List();

                dtgEscola.ItemsSource = listaDeEscolas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha na listagem", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelecionada = dtgEscola.SelectedItem as Escola;
            var form = new CadsastrarEscola(escolaSelecionada);
            form.ShowDialog();
        }

        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelecionada = dtgEscola.SelectedItem as Escola;

            var resultado = MessageBox.Show($"Deseja realmente excluir \"{escolaSelecionada.NomeFantasia}\" dos registros?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);


            try
            {
                if(resultado == MessageBoxResult.Yes)
                {
                    var dao = new EscolaDAO();
                    dao.Delete(escolaSelecionada);

                    MessageBox.Show("Registro Removido com Sucesso!", "Atualização do Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                CarregarListagem();


            } catch 
            {
                MessageBox.Show("Houveram Erros na remoção do elemento", "Falha ao atualizar o Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

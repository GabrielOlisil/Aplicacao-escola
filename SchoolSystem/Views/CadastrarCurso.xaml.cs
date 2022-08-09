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


namespace SchoolSystem.Views
{
    /// <summary>
    /// Lógica interna para CadastrarCurso.xaml
    /// </summary>
    public partial class CadastrarCurso : Window
    {
        private Curso _curso = new Curso();
        public CadastrarCurso()
        {
            InitializeComponent();
            Loaded += CadastrarCurso_Loaded;


        }
        public CadastrarCurso(Curso curso)
        {
            InitializeComponent();
            _curso = curso;
            Loaded += CadastrarCurso_Loaded;
            
        }
        private void CarregarListagemEscola()
        {
            try
            {
                var dao = new EscolaDAO();
                List<Escola> listaDeEscolas = dao.List();

                cbEscolas.ItemsSource = listaDeEscolas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha na listagem", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void CadastrarCurso_Loaded(object sender, RoutedEventArgs e)
        {
            cbTurno.Text = _curso.Turno;
            txtDescricao.Text = _curso.Descricao;
            txtCargaHoraria.Text = _curso.CargaHoraria;
            txtNome.Text = _curso.Nome;
            cbEscolas.SelectedItem = _curso.Escola.Id;
            CarregarListagemEscola();

        }

        private void Button_Salvar_Click(object sender, RoutedEventArgs e)
        {
            _curso.Turno = cbTurno.Text;
            _curso.Descricao = txtDescricao.Text;
            _curso.CargaHoraria= txtCargaHoraria.Text;
            _curso.Nome = txtNome.Text;

            if (cbEscolas.SelectedItem != null) _curso.Escola = cbEscolas.SelectedItem as Escola;
            

            

            try
            {
                var dao = new CursoDAO();

                if(_curso.Id > 0)
                {
                    dao.Update(_curso);
                    MessageBox.Show("Update Feito", "Atualização do Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    
                    dao.Insert(_curso);
                    MessageBox.Show("Insert Feito", "Atualização do Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            } catch (Exception ex)
            {
                MessageBox.Show("Houveram Erros na realização da tarefa", "Falha ao atualizar o Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}

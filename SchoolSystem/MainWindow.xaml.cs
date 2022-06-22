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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using SchoolSystem.Database;
using SchoolSystem.Models;
using SchoolSystem.Formulários;
using SchoolSystem.Views;

namespace SchoolSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCad_Click(object sender, RoutedEventArgs e)
        {
            CadsastrarEscola cadastro = new CadsastrarEscola();
            cadastro.ShowDialog();
        }

        private void btList_Click(object sender, RoutedEventArgs e)
        {
            ListaEscola listar = new ListaEscola();
            listar.ShowDialog();
        
        }

        private void btCad_Curso_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCurso cadCurso = new CadastrarCurso();
            cadCurso.ShowDialog();
        }

        private void btList_Curso_Click(object sender, RoutedEventArgs e)
        {
            ListaCurso lista = new ListaCurso();
            lista.ShowDialog();
        }
    }
}

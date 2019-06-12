using br.com.livrariashalom.BLL;
using br.com.livrariashalom.DAO;
using br.com.livrariashalom.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace br.com.livrariashalom.View
{
    /// <summary>
    /// Lógica interna para Entrada.xaml
    /// </summary>
    public partial class TelaEntrada : Window
    {
        private EntradaBLL entradaBLL = new EntradaBLL();
        private Conexao conexao = new Conexao();
        private MySqlCommand command = null;

        public TelaEntrada()
        {
            InitializeComponent();
            ListarEntrada();
            ListarLivro();
            lblData.Content = DateTime.Now;
        }

        public void Limpar()
        {
            txtCodEntrada.Clear();
            txtCodigoLivro.Clear();
            txtDescricao.Clear();
            txtQtdSaida.Clear();
        }

        public void RegistrarEntrada(Entrada entrada)
        {
            try
            {
                entrada.Data = Convert.ToDateTime(lblData.Content);
                entrada.QtdEntrada = Convert.ToInt32(txtQtdSaida.Text);
                entrada.Descricao = txtDescricao.Text;
                entrada.CodLivro.CodLivro = Convert.ToInt32(txtCodigoLivro.Text);

                entradaBLL.SalvarEntrada(entrada);
                ListarEntrada();
                Limpar();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ListarEntrada()
        {
            try
            {
                dgEntrada.ItemsSource = entradaBLL.ListarEntrada().DefaultView;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ListarLivro()
        {
            try
            {
                conexao.Conectar();

                command = new MySqlCommand("select titulo from livro", conexao.conexao);
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string titulo = dr["titulo"].ToString();
                    cmbLivro.Items.Add(titulo);
                }

                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void BuscarPorCodigo()
        {
            try
            {
                string titulo = (string)cmbLivro.SelectedValue;
                //coloca o cod na textbox
                command = new MySqlCommand("select codLivro from livro where titulo = @titulo", conexao.conexao);
                command.Parameters.AddWithValue("@titulo", titulo);


                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtCodigoLivro.Text = dr["codLivro"].ToString();
                }
                dr.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirEntrada(Entrada entrada)
        {
            try
            {
                entrada.Data = Convert.ToDateTime(lblData.Content);
                entrada.QtdEntrada = Convert.ToInt32(txtQtdSaida.Text);
                entrada.Descricao = txtDescricao.Text;
                entrada.CodLivro.CodLivro = Convert.ToInt32(txtCodigoLivro.Text);
                entrada.CodEntrada = Convert.ToInt64(txtCodEntrada.Text);

                entradaBLL.ExcluirEntrada(entrada);
                ListarEntrada();
                Limpar();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Entrada entrada = new Entrada();
            RegistrarEntrada(entrada);
        }

        private void CmbLivro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuscarPorCodigo();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Entrada entrada = new Entrada();
            ExcluirEntrada(entrada);
        }

        private void DgEntrada_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var rowView = dgEntrada.SelectedItems[0] as DataRowView;
                txtCodEntrada.Text = rowView["codEntrada"].ToString();
                txtCodigoLivro.Text = rowView["Livro_codLivro"].ToString();
                txtDescricao.Text = rowView["descricao"].ToString();
                txtQtdSaida.Text = rowView["qtdEntrada"].ToString();
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
    }
}

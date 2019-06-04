using br.com.livrariashalom.BLL;
using br.com.livrariashalom.DAO;
using br.com.livrariashalom.Model;
using br.com.livrariashalom.MODEL;
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
    /// Lógica interna para Saida.xaml
    /// </summary>
    public partial class TelaSaida : Window
    {
        private Conexao conexao = new Conexao();
        private MySqlCommand command = null;
        private SaidaBLL saidaBLL = new SaidaBLL();
        public TelaSaida()
        {
            InitializeComponent();
            lblData.Content = DateTime.Now;
            ListarSaida();
            ListarLivro();
        }

        public void RegistrarSaida(Saida saida)
        {
            try
            {
                saida.Data = Convert.ToDateTime(lblData.Content);
                saida.QtdSaida = Convert.ToInt32(txtQtdSaida.Text);
                saida.Descricao = txtDescricao.Text;
                saida.CodLivro.CodLivro = Convert.ToInt32(txtCodigoLivro.Text);

                saidaBLL.SalvarSaida(saida);
                ListarSaida();
            } catch(Exception erro)
            {
                throw erro;
            }
        }

        public void ListarSaida()
        {
            try
            {
                dgSaida.ItemsSource = saidaBLL.ListarSaida().DefaultView;
            }catch(Exception erro)
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
            catch(Exception erro)
            {
                throw erro;
            }
                
        }

        public void BuscarPorCodigo()
        {
            try
            {
                string titulo = (string) cmbLivro.SelectedValue;
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
            catch(Exception erro)
            {
                throw erro;
            }
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            Saida saida = new Saida();
            RegistrarSaida(saida);
            
        }

        private void CmbLivro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuscarPorCodigo();

        }

        private void CmbLivro_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                 
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}

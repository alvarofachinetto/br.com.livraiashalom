using br.com.livrariashalom.BLL;
using br.com.livrariashalom.Model;
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
    /// Lógica interna para TelaReceberConta.xaml
    /// </summary>
    public partial class TelaReceberConta : Window
    {
        private ReceberContaBLL receberContaBLL = new ReceberContaBLL();

        public TelaReceberConta()
        {
            InitializeComponent();
            ListarContaReceber();
            lblData.Content = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private bool SalvarReceberConta(ReceberConta receberConta)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtDescricao.Text == "" || txtValor.Text == "" )
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    receberConta.Data = Convert.ToDateTime(lblData.Content);
                    receberConta.Descricao = txtDescricao.Text;
                    receberConta.Valor = Convert.ToDouble(txtValor.Text);

                    receberContaBLL.SalvarReceberConta(receberConta);

                    MessageBox.Show("Cadastro feito com sucesso");
                    
                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        private bool EditarReceberConta(ReceberConta receberConta)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtDescricao.Text == "" || txtValor.Text == "" )
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    receberConta.CodReceberConta = Convert.ToInt64(txtCodigoReceberConta.Text);
                    receberConta.Data = Convert.ToDateTime(lblData.Content);
                    receberConta.Descricao = txtDescricao.Text;
                    receberConta.Valor = Convert.ToDouble(txtValor.Text);
                    

                    receberContaBLL.EditarReceberConta(receberConta);

                    MessageBox.Show("Edição feita com sucesso");

                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        private bool ExcluirReceberConta()
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtDescricao.Text == "" || txtValor.Text == "" )
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    long codReceberConta = Convert.ToInt64(txtCodigoReceberConta.Text);
                    receberContaBLL.ExcluirReceberConta(codReceberConta);

                    MessageBox.Show("Exclusão feita com sucesso");

                    
                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        //listar
        private void ListarContaReceber()
        {
            try
            {
                dgReceberConta.ItemsSource = receberContaBLL.ListarReceberConta().DefaultView;//obtém todos os dados
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }


        private void BtnSalvarContaPagar_Click(object sender, RoutedEventArgs e)
        {
            ReceberConta receberConta = new ReceberConta();
            SalvarReceberConta(receberConta);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ReceberConta receberConta = new ReceberConta();
            ExcluirReceberConta();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            ReceberConta receberConta = new ReceberConta();
            EditarReceberConta(receberConta);
        }

        private void txtDescricao_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DgReceberConta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                var rowView = dgReceberConta.SelectedItems[0] as DataRowView;
                txtCodigoReceberConta.Text = rowView["codReceberConta"].ToString();
                txtDescricao.Text = rowView["descricao"].ToString();
                txtValor.Text = rowView["valor"].ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }
    }
}

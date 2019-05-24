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
    /// Lógica interna para TelaPagarConta.xaml
    /// </summary>
    public partial class TelaPagarConta : Window
    {
        private PagarContaBLL pagarContaBLL = new PagarContaBLL();

        public TelaPagarConta()
        {
            InitializeComponent();
            ListarContaPagar();
        }

        //limpa os valores após uma ação
        private void Limpar()
        {
            txtCodigoPagarConta.Clear();
            txtDescricao.Clear();
            txtValor.Clear();
        }

        private bool SalvarPagarConta(PagarConta pagarConta)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtDescricao.Text == "" || txtValor.Text == "" || cmbStatus.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    pagarConta.Data = Convert.ToDateTime(txtData.Text);
                    pagarConta.Descricao = txtDescricao.Text;
                    pagarConta.Valor = Convert.ToDouble(txtValor.Text);
                    pagarConta.DataVencimento = Convert.ToDateTime(txtDataVencimento.Text);
                    pagarConta.Status = cmbStatus.Text;

                    pagarContaBLL.SalvarContaPagar(pagarConta);

                    MessageBox.Show("Cadastro feito com sucesso");
                    ListarContaPagar();
                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        private bool EditarPagarConta(PagarConta pagarConta)
        {

            try
            {
                //caso os campos estiverem vazios
                if ( txtDescricao.Text == "" || txtValor.Text == "" || cmbStatus.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    pagarConta.CodPagarConta = Convert.ToInt64(txtCodigoPagarConta.Text);
                    pagarConta.Data = Convert.ToDateTime(txtData.Text);
                    pagarConta.Descricao = txtDescricao.Text;
                    pagarConta.Valor = Convert.ToDouble(txtValor.Text);
                    pagarConta.DataVencimento = Convert.ToDateTime(txtDataVencimento.Text);
                    pagarConta.Status = cmbStatus.Text;


                    MessageBoxResult alteracao = MessageBox.Show("Deseja realmete salvar as alterações ?", "Editar", MessageBoxButton.YesNo);

                    //caso o usuário realmente queira fazer a alteração
                    if (alteracao == MessageBoxResult.Yes)
                    {

                        pagarContaBLL.EditarContaPagar(pagarConta);

                        MessageBox.Show("Edição feito com sucesso");
                        Limpar();
                        ListarContaPagar();
                        
                    }
                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        private bool ExcluirPagarConta()
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtDescricao.Text == "" || txtValor.Text == "" || cmbStatus.Text == "" )
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    long codPagarConta = Convert.ToInt64(txtCodigoPagarConta.Text);

                    MessageBoxResult exclusao = MessageBox.Show("Deseja realmete Excluir essa conta ?", "Excluir", MessageBoxButton.YesNo);

                    //caso o usuário realmente queira fazer a alteração
                    if (exclusao == MessageBoxResult.Yes)
                    {
                        pagarContaBLL.ExcluirContaPagar(codPagarConta);

                        MessageBox.Show("Exclusão feito com sucesso");
                        Limpar();
                        ListarContaPagar();

                    }
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
        private void ListarContaPagar()
        {
            try
            {
                dgPagarConta.ItemsSource = pagarContaBLL.ListarContaPagar().DefaultView;//obtém todos os dados
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }

        private void BtnSalvarContaPagar_Click(object sender, RoutedEventArgs e)
        {
            PagarConta pagarConta = new PagarConta();
            SalvarPagarConta(pagarConta);
        }

        private void dgPagarConta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                var rowView = dgPagarConta.SelectedItems[0] as DataRowView;
                txtCodigoPagarConta.Text = rowView["codPagarConta"].ToString();
                txtData.Text = rowView["data"].ToString();
                cmbStatus.Text = rowView["status"].ToString();
                txtDataVencimento.Text =rowView["dataVencimento"].ToString();
                txtDescricao.Text = rowView["descricao"].ToString();
                txtValor.Text = rowView["valor"].ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            PagarConta pagarConta = new PagarConta();
            EditarPagarConta(pagarConta);
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ExcluirPagarConta();
        }
    }
}

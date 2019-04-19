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
    /// Lógica interna para TelaFornecedor.xaml
    /// </summary>
    public partial class TelaFornecedor : Window
    {
        private FornecedorBLL fornecedorBLL = new FornecedorBLL();
        private Fornecedor fornecedor = new Fornecedor();


        public TelaFornecedor()
        {
            InitializeComponent();
            ListarFornecedor();

        }

        //limpa os valores após uma ação
        private void Limpar()
        {
            txtcodFornecedor.Clear();
            txtRazao.Clear();
            txtFantasia.Clear();
            txtCnpjCpf.Clear();
            cmbEmpresa.SelectedIndex = 0;
            txtIe.Clear();
            txtObservacoes.Clear();
        }

        //recebe os valores para salvar
        private bool SalvarFornecedor()
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtRazao.Text == "" || txtFantasia.Text == "" ||  txtCnpjCpf.Text == "" || cmbEmpresa.Text == "" || txtIe.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    fornecedor.NomeRazao = txtRazao.Text;
                    fornecedor.NomeFantasia = txtFantasia.Text;
                    fornecedor.CnpjCpf = txtCnpjCpf.Text;
                    fornecedor.Ie = txtIe.Text;
                    fornecedor.Empresa = cmbEmpresa.Text;
                    fornecedor.Observacoes = txtObservacoes.Text;

                    fornecedorBLL.SalvarFornecedor(fornecedor);

                    MessageBox.Show("Cadastro feito com sucesso");

                    TelaContato telacontato = new TelaContato();
                    telacontato.Show();
                    this.Hide();

                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        //ListarFornecedor lista todos os fornecedores
        private void ListarFornecedor()
        {
            try
            {
                dgFornecedor.ItemsSource = fornecedorBLL.ListarFornecedor().DefaultView;//obtém todos os dados
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }

        //EditarFornecedor recebe os valores para alteração
        private bool EditarFornecedor()
        {
            try
            {
                if (txtRazao.Text == "" || txtFantasia.Text == "" || txtCnpjCpf.Text == "" || cmbEmpresa.Text == "" || txtIe.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                    
                }
                else
                {
                    fornecedor.CodFornecedor = Convert.ToInt64(txtcodFornecedor.Text);
                    fornecedor.NomeRazao = txtRazao.Text;
                    fornecedor.NomeFantasia = txtFantasia.Text;
                    fornecedor.CnpjCpf = txtCnpjCpf.Text;
                    fornecedor.Ie = txtIe.Text;
                    fornecedor.Empresa = cmbEmpresa.Text;
                    fornecedor.Observacoes = txtObservacoes.Text;

                    MessageBoxResult alteracao = MessageBox.Show("Deseja realmete salvar as alterações ?", "Editar", MessageBoxButton.YesNo);

                    //caso o usuário realmente queira fazer a alteração
                    if (alteracao == MessageBoxResult.Yes)
                    {
                        fornecedorBLL.EditarFornecedor(fornecedor);
                        MessageBox.Show("Edição feita com sucesso");
                        ListarFornecedor(); //listará automaticamente toda edição
                        Limpar();

                        return true;
                    }

                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

            return false;
        }

        //deletar o fornecedor
        private bool DeletarFornecedor()
        {
            if (txtcodFornecedor.Text == "")
            {
                MessageBox.Show("Campo código precisa estar preenchido");
            }
            else
            {
                MessageBoxResult deletar = MessageBox.Show("Deseja excluir o fornecedor ?", "Deletar", MessageBoxButton.YesNo);

                if (deletar == MessageBoxResult.Yes)
                {
                    fornecedor.CodFornecedor = Convert.ToInt32(txtcodFornecedor.Text);
                    fornecedorBLL.DeletarFornecedor(fornecedor);
                    MessageBox.Show("Fornecedor removido com sucesso");
                    ListarFornecedor();
                    Limpar();

                    return true;
                }
                
            }
            return false;
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            SalvarFornecedor();
        }

        private void CmbEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String valor = cmbEmpresa.SelectedValue.ToString();
        }

        private void TxtCnpjCpf_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtCnpjCpf.MaxLength = 18;
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            ListarFornecedor();
        }
        
        private void DgFornecedor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                var rowView = dgFornecedor.SelectedItems[0] as DataRowView;
                txtcodFornecedor.Text = rowView["codFornecedor"].ToString();

                txtRazao.Text = rowView["nome_razao"].ToString();
                txtFantasia.Text = rowView["nome_fantasia"].ToString();
                txtCnpjCpf.Text = rowView["cnpjcpf"].ToString();
                txtIe.Text = rowView["ie"].ToString();
                cmbEmpresa.Text = rowView["empresa"].ToString();
                txtObservacoes.Text = rowView["observacoes"].ToString();
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarFornecedor();
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            DeletarFornecedor();
        }
    }
}
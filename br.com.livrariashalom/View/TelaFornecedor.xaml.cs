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
        private ContatoBLL contatoBLL = new ContatoBLL();
        private EnderecoBLL enderecoBLL = new EnderecoBLL();
        private MySqlCommand command = null;
        private Conexao Conexao = new Conexao();

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
            txtCodigoEndereco.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            cmbEstado.SelectedIndex = 0;
            txtCodigoEndereco.Clear();
            txtCodContato.Clear();
            txtEmailEmpresa.Clear();
            txtTelefoneEmpresa.Clear();
            txtEmailFuncionario.Clear();
            txtTelefoneFuncionario.Clear();
            txtFornecedorContato.Clear();
        }

        //recebe os valores para salvar
        private bool SalvarFornecedor(Fornecedor fornecedor)
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
                    
                    tabControlFornecedor.SelectedIndex = 1;
                    EnviarCodFornecedor();
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
        private bool EditarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                if (txtcodFornecedor.Text == "" || txtRazao.Text == "" || txtFantasia.Text == "" || txtCnpjCpf.Text == "" || cmbEmpresa.Text == "" || txtIe.Text == "")
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

        //colocará o codigo na text box do contato e endereco
        public void EnviarCodFornecedor()
        {
            try
            {
                Conexao.Conectar();
                command = new MySqlCommand("select max(codFornecedor) from fornecedor",Conexao.conexao);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtFornecedorEndereco.Text = reader["max(codFornecedor)"].ToString();
                    txtFornecedorContato.Text = reader["max(codFornecedor)"].ToString();
                }
                reader.Close();
            }
            catch(Exception erro)
            {
                throw erro;
            }
        }

        //deletar o fornecedor
        private bool DeletarFornecedor(Fornecedor fornecedor)
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

        //Salvar Endereço 
        private bool SalvarEndereco(Endereco endereco)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtLogradouro.Text == "" || txtNumero.Text == "" || txtBairro.Text == "" || txtCidade.Text == "" || cmbEstado.Text == "" || txtCep.Text == "" || txtFornecedorEndereco.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    endereco.Logradouro = txtLogradouro.Text;
                    endereco.Numero = Convert.ToInt16(txtNumero.Text);
                    endereco.Bairro = txtBairro.Text;
                    endereco.Cidade = txtCidade.Text;
                    endereco.Estado = cmbEstado.Text;
                    endereco.Cep = txtCep.Text;
                    endereco.Fornecedor.CodFornecedor = Convert.ToInt64(txtFornecedorEndereco.Text); //arrumar

                    enderecoBLL.SalvarEndereco(endereco);

                    MessageBox.Show("Fornecedor salvo com sucesso");
                    
                    tabControlFornecedor.SelectedIndex = 2; //irá para proxima tela

                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }


        //Salvar Contato
        public bool CadastrarContato(Contato contato)
        {
            try
            {
                if (txtEmailEmpresa.Text == "" || txtEmailFuncionario.Text == "" || txtTelefoneEmpresa.Text == "" || txtTelefoneFuncionario.Text == "" || txtFornecedorContato.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");

                }
                else
                {
                    contato.EmailPrimario = txtEmailEmpresa.Text;
                    contato.EmailSecundario = txtEmailFuncionario.Text;
                    contato.TelefonePrincipal = txtTelefoneEmpresa.Text;
                    contato.TelefoneReserva = txtTelefoneFuncionario.Text;
                    contato.Fornecedor.CodFornecedor = Convert.ToInt64(txtFornecedorContato.Text);

                    contatoBLL.SavarContato(contato);

                    MessageBox.Show("Contato salvo com sucesso");

                    tabControlFornecedor.SelectedIndex = 0;

                    return true;
                }


            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

            return false;
        }

        //EditarFornecedor recebe os valores para alteração
        private bool EditarContato(Contato contato)
        {
            try
            {
                if (txtEmailEmpresa.Text == "" || txtEmailFuncionario.Text == "" || txtTelefoneEmpresa.Text == "" || txtTelefoneFuncionario.Text == "" || txtFornecedorContato.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");

                }
                else
                {
                    
                    MessageBoxResult alteracao = MessageBox.Show("Deseja realmete salvar as alterações ?", "Editar", MessageBoxButton.YesNo);

                    contato.EmailPrimario = txtEmailEmpresa.Text;
                    contato.EmailSecundario = txtEmailFuncionario.Text;
                    contato.TelefonePrincipal = txtTelefoneEmpresa.Text;
                    contato.TelefoneReserva = txtTelefoneFuncionario.Text;
                    contato.Fornecedor.CodFornecedor = Convert.ToInt64(txtFornecedorContato.Text);

                    //caso o usuário realmente queira fazer a alteração
                    if (alteracao == MessageBoxResult.Yes)
                    {
                        contatoBLL.EditarContato(contato);
                        MessageBox.Show("Edição feita com sucesso");
                        Limpar();

                        return true;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

            return false;
        }

        //deletar o fornecedor
        private bool DeletarContato(Contato contato)
        {
            if (txtCodContato.Text == "")
            {
                MessageBox.Show("Campo código precisa estar preenchido");
            }
            else
            {
                MessageBoxResult deletar = MessageBox.Show("Deseja excluir o fornecedor ?", "Deletar", MessageBoxButton.YesNo);

                if (deletar == MessageBoxResult.Yes)
                {
                    contato.CodContato = Convert.ToInt32(txtCodContato.Text);
                    contatoBLL.ExcluirContato(contato);
                    MessageBox.Show("Fornecedor removido com sucesso");
                    Limpar();

                    return true;
                }

            }
            return false;
        }

        //botao cadastrar fornecedor
        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            SalvarFornecedor(fornecedor);
        }

        //aparece informação no combobox
        private void CmbEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String valor = cmbEmpresa.SelectedValue.ToString();
        }

        //ler cpf ou cnpj
        private void TxtCnpjCpf_TextChanged(object sender, TextChangedEventArgs e)
        {
  
        }

        //metodo para aparecer as informações nas labels
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

                txtCodigoEndereco.Text = rowView["codEndereco"].ToString();

                txtLogradouro.Text = rowView["logradouro"].ToString();
                txtNumero.Text = rowView["numero"].ToString();
                txtBairro.Text = rowView["bairro"].ToString();
                txtCidade.Text = rowView["cidade"].ToString();
                cmbEstado.Text = rowView["estado"].ToString();
                txtCep.Text = rowView["cep"].ToString();
                txtFornecedorEndereco.Text = rowView["Fornecedor_codFornecedor"].ToString();

                txtCodContato.Text = rowView["codContato"].ToString();
                txtEmailEmpresa.Text = rowView["email_primario"].ToString();
                txtEmailFuncionario.Text = rowView["email_secundario"].ToString();
                txtTelefoneEmpresa.Text = rowView["telefone_principal"].ToString();
                txtTelefoneFuncionario.Text = rowView["telefone_reserva"].ToString();
                txtFornecedorContato.Text = rowView["Fornecedor_codFornecedor"].ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }

        }
        //botao para editar fornecedor
        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            EditarFornecedor(fornecedor);
        }
        //botao para excluir fornecedor
        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            DeletarFornecedor(fornecedor);
        }

        private void TabControlFornecedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //botao para salvar contato
        private void BtnCadastroContato_Click(object sender, RoutedEventArgs e)
        {
            Contato contato = new Contato();
            CadastrarContato(contato);
        }
        //botao para cadastrar endereco
        private void BtnCadastrarEndereco_Click(object sender, RoutedEventArgs e)
        {
            Endereco endereco = new Endereco();
            SalvarEndereco(endereco);
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            ListarFornecedor();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmbCpfCnpj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int validar = cmbCpfCnpj.SelectedIndex;
            if (validar == 1)
            {
                txtCnpjCpf.IsReadOnly = false;
                lblCnpjCpf.Content = "CPF";
                txtCnpjCpf.Mask = "000.000.000-00";
            }
            else if (validar == 2)
            {
                
                txtCnpjCpf.IsReadOnly = false;
                lblCnpjCpf.Content = "CNPJ";
                txtCnpjCpf.Mask = "00.000.000/0000.00";
            }
            else
            {
                lblCnpjCpf.Content = "CPF/CNPJ";

            }
        }
    }
}
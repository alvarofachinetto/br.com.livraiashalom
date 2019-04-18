using br.com.livrariashalom.BLL;
using br.com.livrariashalom.Model;
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

namespace br.com.livrariashalom.View
{
    /// <summary>
    /// Lógica interna para TelaContato.xaml
    /// </summary>
    public partial class TelaContato : Window
    {
        private ContatoBLL contatoBLL = new ContatoBLL();
        private Contato contato = new Contato();

        public TelaContato()
        {
            InitializeComponent();
        }

        public bool CadastrarContato(Contato contato)
        {
            try
            {
                
                if (txtEmailEmpresa.Text == "" || txtEmailFuncionario.Text == "" || txtTelefoneEmpresa.Text == "" || txtTelefoneFuncionrio.Text == "" || txtFornecedor.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                    
                }
                else
                {
                    
                    contato.EmailPrimario = txtEmailEmpresa.Text;
                    contato.EmailSecundario = txtEmailFuncionario.Text;
                    contato.TelefonePrincipal = txtTelefoneEmpresa.Text;
                    contato.TelefoneReserva = txtTelefoneFuncionrio.Text;
                    contato.Fornecedor.CodFornecedor = Convert.ToInt64(txtFornecedor.Text); 

                    contatoBLL.SavarContato(contato);

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

        private void BtnCadastroContato_Click(object sender, RoutedEventArgs e)
        {
            
            CadastrarContato(contato);
        }

        private void txtFornecedor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

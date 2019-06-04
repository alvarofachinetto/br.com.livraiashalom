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
    /// Lógica interna para TelaPrincipal.xaml
    /// </summary>
    public partial class TelaPrincipal : Window
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        public TelaPrincipal(string usuario)
        {
            
        }

        private void MenuItemCadastros_Click(object sender, RoutedEventArgs e)
        {

        }

        
        //Mostrar Tela Fornecedor
        private void MenuItem_Click_Fornecedor(object sender, RoutedEventArgs e)
        {
            TelaFornecedor telaFornecedor = new TelaFornecedor();
            telaFornecedor.Show();
            this.Hide();
        }

        //Mostrar Tela Funcionario
        private void MenuItem_Click_Funcionario(object sender, RoutedEventArgs e)
        {
            TelaFuncionario usuario= new TelaFuncionario();
            usuario.Show();
            this.Hide();
        }

        //Mostrar Tela Livro
        private void MenuItemLivro_Click(object sender, RoutedEventArgs e)
        {
            TelaLivro telaLivro = new TelaLivro();
            telaLivro.Show();
            this.Hide();
        }

        //Mostrar Tela Categoria
        private void MenuItemCategoria_Click(object sender, RoutedEventArgs e)
        {
            TelaCategoria telaCategoria = new TelaCategoria();
            telaCategoria.Show();
            this.Hide();
        }

        //Mostrar Tela Prazo
        private void MenuItemPrazo_Click(object sender, RoutedEventArgs e)
        {
            TelaPrazo telaPrazo = new TelaPrazo();
            telaPrazo.Show();
            this.Hide();
        }

        //tela pagar contas
        private void MenuItem_Click_PagarContas(object sender, RoutedEventArgs e)
        {
            TelaPagarConta telaPagarConta = new TelaPagarConta();
            telaPagarConta.Show();
            this.Hide();
        }

        //tela fluxo de caixa
        private void MenuItemFluxo_Click(object sender, RoutedEventArgs e)
        {
            TelaFuxoCaixa telaFuxoCaixa = new TelaFuxoCaixa();
            telaFuxoCaixa.Show();
            this.Hide();
        }

        //tela estoque
        private void MenuItem_Click_EstoqueLivroProduto(object sender, RoutedEventArgs e)
        {
            //TelaEstoque telaEstoque = new TelaEstoque();
            //telaEstoque.Show();
            //this.Hide();
        }

        //receber contas
        private void MenuItem_Click_ReceberContas(object sender, RoutedEventArgs e)
        {
            TelaReceberConta telaReceberConta = new TelaReceberConta();
            telaReceberConta.Show();
            this.Hide();
        }

        private void MenuVenda_Click(object sender, RoutedEventArgs e)
        {
            TelaVendas telaVendas = new TelaVendas();
            telaVendas.Show();
            this.Hide();
        }
    }
}

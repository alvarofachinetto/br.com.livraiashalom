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

        //Mostrar Tela Produto
        private void MenuItemProduto_Click(object sender, RoutedEventArgs e)
        {
            TelaProduto telaProduto = new TelaProduto();
            telaProduto.Show();
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

        private void MenuItem_Click_PagarContas(object sender, RoutedEventArgs e)
        {
            TelaPagarConta telaPagarConta = new TelaPagarConta();
            telaPagarConta.Show();
            this.Hide();
        }

        private void MenuItem_Click_PagarReceber(object sender, RoutedEventArgs e)
        {
            TelaReceberConta telaReceberConta = new TelaReceberConta();
            telaReceberConta.Show();
            this.Hide();
        }
    }
}

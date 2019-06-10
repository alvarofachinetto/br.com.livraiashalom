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
            telaFornecedor.Topmost = true;
            telaFornecedor.ShowDialog();
            
        }

        //Mostrar Tela Funcionario
        private void MenuItem_Click_Funcionario(object sender, RoutedEventArgs e)
        {
            TelaFuncionario usuario= new TelaFuncionario();
            usuario.Topmost = true;
            usuario.ShowDialog();

        }

        //Mostrar Tela Livro
        private void MenuItemLivro_Click(object sender, RoutedEventArgs e)
        {
            TelaLivro telaLivro = new TelaLivro();
            telaLivro.Topmost = true;
            telaLivro.ShowDialog();

        }

        //Mostrar Tela Categoria
        private void MenuItemCategoria_Click(object sender, RoutedEventArgs e)
        {
            TelaCategoria telaCategoria = new TelaCategoria();
            telaCategoria.Topmost = true;
            telaCategoria.ShowDialog();

        }

        //Mostrar Tela Prazo
        private void MenuItemPrazo_Click(object sender, RoutedEventArgs e)
        {
            TelaPrazo telaPrazo = new TelaPrazo();
            telaPrazo.Topmost = true;
            telaPrazo.ShowDialog();

        }

        //tela pagar contas
        private void MenuItem_Click_PagarContas(object sender, RoutedEventArgs e)
        {
            TelaPagarConta telaPagarConta = new TelaPagarConta();
            telaPagarConta.Topmost = true;
            telaPagarConta.ShowDialog();

        }

        //tela fluxo de caixa
        private void MenuItemFluxo_Click(object sender, RoutedEventArgs e)
        {
            TelaFuxoCaixa telaFuxoCaixa = new TelaFuxoCaixa();
            telaFuxoCaixa.Topmost = true;
            telaFuxoCaixa.ShowDialog();

        }

        //receber contas
        private void MenuItem_Click_ReceberContas(object sender, RoutedEventArgs e)
        {
            TelaReceberConta telaReceberConta = new TelaReceberConta();
            telaReceberConta.Topmost = true;
            telaReceberConta.ShowDialog();

        }

        private void MenuVenda_Click(object sender, RoutedEventArgs e)
        {
            TelaVendas telaVendas = new TelaVendas();
            telaVendas.Topmost = true;
            telaVendas.ShowDialog();

        }

        private void MenuItemSaida_Click(object sender, RoutedEventArgs e)
        {
            TelaSaida telaSaida = new TelaSaida();
            telaSaida.Topmost = true;
            telaSaida.ShowDialog();

        }

        private void MenuItemEntrada_Click(object sender, RoutedEventArgs e)
        {
            TelaEntrada telaEntrada = new TelaEntrada();
            telaEntrada.Topmost = true;
            telaEntrada.ShowDialog();

        }

        private void MenuItemSair_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult sair = MessageBox.Show("Deseja realmete sair do sistema ?", "Sair", MessageBoxButton.YesNo);

            if (sair == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }

}

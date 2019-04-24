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
    /// Lógica interna para TelaProduto.xaml
    /// </summary>
    public partial class TelaProduto : Window
    {
        private ProdutoBLL produtoBLL = new ProdutoBLL();

        public TelaProduto()
        {
            InitializeComponent();
        }

        private bool SalvarProduto(Produto produto)
        {
            try
            {
                //caso os campos estiverem vazios
                if (txtProduro.Text == "" || txtValorUnit.Text == "" || txtQtd.Text == "" || txtCategoria.Text == "" || txtQtdAlerta.Text == "")
                {
                    MessageBox.Show("Campos com * são obrigatórios o preenchimento");
                }
                else
                {
                    produto.NomeProduto = txtProduro.Text;
                    produto.ValorUnit = Convert.ToDouble(txtValorUnit.Text);
                    produto.Categoria.CodCategoria = Convert.ToInt32(txtCategoria.Text);
                    produto.Qtd = Convert.ToInt32(txtQtd.Text);
                    produto.QtdAlerta = Convert.ToInt32(txtQtdAlerta.Text);
                    produto.Fornecedor.CodFornecedor = Convert.ToInt64(txtCodFornecedorProduto.Text);

                    produtoBLL.SalvarProduto(produto);

                    MessageBox.Show("Cadastro feito com sucesso");
                    MessageBox.Show("Código do produto: " + txtCodProduto.Text);

                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Produto produto = new Produto();
            SalvarProduto(produto);
        }
    }
}

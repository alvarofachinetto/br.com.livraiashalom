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
    /// Lógica interna para TelaPrazo.xaml
    /// </summary>
    public partial class TelaPrazo : Window
    {
        private PrazoBLL prazoBLL = new PrazoBLL();

        public TelaPrazo()
        {
            InitializeComponent();
        }

        private bool SalvarPrazo(Prazo prazo)
        {

            try
            {
                //caso os campos estiverem vazios
                if (txtCondPagamento.Text == "" || txtParcelamento.Text == "") 
                {
                    MessageBox.Show("É obrigatório preencher a condição pagamento");
                }
                else
                {
                    prazo.CondPagamento = txtCondPagamento.Text;
                    prazo.Parcelamento = Convert.ToInt16(txtParcelamento.Text);
                    prazoBLL.SalvaPrazo(prazo);

                    MessageBox.Show("Cadastro feito com sucesso");
                    MessageBox.Show("Código do prazo: " + prazo.CodCondPagamento);

                    return true;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Erro: " + error);
            }
            return false;

        }

        private void BtnPrazo_Click(object sender, RoutedEventArgs e)
        {
            Prazo prazo = new Prazo();
            SalvarPrazo(prazo);
        }
    }
}

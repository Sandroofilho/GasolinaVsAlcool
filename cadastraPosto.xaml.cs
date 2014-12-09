using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Gasolina_ou_Alcool.Classes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Gasolina_ou_Alcool.Resources;

namespace Gasolina_ou_Alcool
{
    public partial class cadastraPosto : PhoneApplicationPage
    {
        public clsCombustiveis Combustivel { get; set; }

        public cadastraPosto()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Combustivel != null)
            {
                txtResultado.Text = Combustivel.Resultado;
                txtPosto.Text = Combustivel.Posto;
            }
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Novo()
        {


        }

        private void Alterar()
        {
           


            Combustivel.Resultado = txtResultado.Text;
            Combustivel.Posto = txtPosto.Text;
            Combustivel.Alcool = txtalcool.Text;
            Combustivel.Gasolina = txtgasolina.Text;
            

        
            clsCombustiveisDB.Atualizar(Combustivel);

        }

        private void OnClickSalvar(object sender, EventArgs e)
        {
            //Atributo DataTime
            DateTime myValue = DateTime.Now;
            DateTime myBirthday = DateTime.Parse("12/07/1987");
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            txtRegistro.Text = myValue.AddDays(0).ToShortDateString();

            //           if (gasolina.Text == string.Empty)
            //         {
            //           MessageBox.Show("Faltando Item");
            //   }

            double gasol = double.Parse(txtgasolina.Text);
            double alco = double.Parse(txtalcool.Text);
            double soma = alco / gasol;
            if (soma <= 0.7)
            {
                txtResultado.Text = ("Abastecer com Álcool!");
            }
            else
            {
                txtResultado.Text = ("Abastecer com Gasolina!");
            }

            if (Combustivel != null) // alterar
            {
                //atualiza o objeto com os dados digitados pelo usuário
                Combustivel.Resultado = txtResultado.Text;
                Combustivel.Posto = txtPosto.Text;
                Combustivel.Alcool = txtalcool.Text;
                Combustivel.Gasolina = txtgasolina.Text;

                clsCombustiveisDB.Atualizar(Combustivel);
            }
            else
            {
                Combustivel = new clsCombustiveis
                {
                    Resultado = txtResultado.Text,
                    Posto = txtPosto.Text,
                    Registro = txtRegistro.Text,
                    Gasolina = txtgasolina.Text,
                    Alcool = txtalcool.Text

                };
                clsCombustiveisDB.Salvar(Combustivel);
            }


            NavigationService.GoBack();
        }

        private void gasolina_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void alcool_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPosto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


   

    }
}
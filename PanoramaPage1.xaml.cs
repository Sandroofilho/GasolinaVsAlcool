using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Gasolina_ou_Alcool.Classes;
using Microsoft.Phone.Controls;
using Gasolina_ou_Alcool.Resources;

namespace Gasolina_ou_Alcool
{
    public partial class PanoramaPage1 : PhoneApplicationPage
    {
        clsCombustiveis combustivel;
        public PanoramaPage1()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            AtualizarLista();
            AtualizarLista2();
        }





        //Método amarrado ao evento para cadastrar um novo Posto
        private void onClickNovo(object sender, EventArgs e)
        {
            CadastraPosto();
        }


        private void CadastraPosto()
        {
            NavigationService.Navigate(new Uri("/cadastraPosto.xaml", UriKind.Relative));
        }


        private void AtualizarLista2()
        {
            List<clsCombustiveis> lista = clsCombustiveisDB.GetComb("F1");
            lstCombustiveis2.ItemsSource = lista;
        }


        private void AtualizarLista()
        {
            List<clsCombustiveis> lista = clsCombustiveisDB.GetCombustiveis("F1");
            lstCombustiveis.ItemsSource = lista;
        }

        private void OnClickDeletar(object sender, EventArgs e)
        {


            if (MessageBox.Show("Deletar " + combustivel.Posto + "?", "Atenção",
                                MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                clsCombustiveisDB.Deletar(combustivel);
                AtualizarLista();
                AtualizarLista2();
            }


        }

        private void OnClickAtualizar(object sender, EventArgs e)
        {
            AtualizarLista();
            AtualizarLista2();

        }

        private void OnSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            //vai instanciar o objeto selecionado na listBox
            combustivel = (sender as ListBox).SelectedItem as clsCombustiveis;
        }

        private void OnClickEditar(object sender, EventArgs e)
        {
            CadastraPosto();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            cadastraPosto page = e.Content as cadastraPosto;
            if (page != null)
            {
                page.Combustivel = combustivel;
                page.tituloPage.Text = "Qual o ideal?";

            }
        }

        private void lstCombustiveis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<clsCombustiveis> lista = clsCombustiveisDB.GetCombustiveis("F1");
            lstCombustiveis.ItemsSource = lista;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<clsCombustiveis> lista = clsCombustiveisDB.GetComb("F1");
            lstCombustiveis.ItemsSource = lista;
        }

        private void Panorama_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //





       
    }
}
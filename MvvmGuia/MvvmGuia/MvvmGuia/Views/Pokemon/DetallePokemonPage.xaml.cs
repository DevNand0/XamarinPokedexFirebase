using MvvmGuia.ViewModel.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmGuia.Views.Pokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallePokemonPage : ContentPage
    {
        public DetallePokemonPage(MvvmGuia.Model.Pokemon model)
        {
            InitializeComponent();
            BindingContext = new DetallePokemonPageViewModel(Navigation,model);
        }
    }
}
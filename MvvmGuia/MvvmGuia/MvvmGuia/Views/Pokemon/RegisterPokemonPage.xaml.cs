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
    public partial class RegisterPokemonPage : ContentPage
    {
        public RegisterPokemonPage()
        {
            InitializeComponent();
            BindingContext = new RegisterPokemonPageViewModel(Navigation);
        }
    }
}
using MvvmGuia.Model;
using MvvmGuia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.ViewModel
{
    public class MainMenuPageViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;

        public List<MenuPrincipal> Lista { get; set; }
        #endregion

        #region CONSTRUCTOR
        public MainMenuPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPaginas();
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set
            {
                SetValue(ref _Texto, value);
            }
        }
        #endregion

        #region PROCESOS
        public async Task VolverAsync()
        {
            await Navigation.PopAsync();
        }

        public async Task Navegar(MenuPrincipal m)
        {
            string pagina;
            pagina = m.Pagina;
            if (pagina.Contains("Entry, datepicker")) 
            {
                await Navigation.PushAsync(new Page1());
            }

            if (pagina.Contains("CollectionView"))
            {
                await Navigation.PushAsync(new Page2());
            }

            if (pagina.Contains("CRUD"))
            {
                await Navigation.PushAsync(new CrudPokemonPage());
            }
        }

        public void MostrarPaginas()
        {
            Lista = new List<MenuPrincipal>
            {
                new MenuPrincipal
                {
                    Pagina = "Entry, datepicker, picker, label, navegacion",
                    Icono = "charlando.png"
                },
                new MenuPrincipal
                {
                    Pagina = "CollectionView Sin enlace a DB",
                    Icono = "guitarra.png"
                },
                new MenuPrincipal
                {
                    Pagina = "CRUD a DB Pokemon",
                    Icono = "pokebola.png"
                }
            };
        }
        #endregion

        #region COMANDOS
        public ICommand VolverAsyncCommand => new Command(async () => await VolverAsync());

        public ICommand NavegarCommand => new Command<MenuPrincipal>(async (m) => await Navegar(m));

        // public ICommand MostrarUsuariosCommand => new Command(MostrarUsuarios);
        #endregion
    }
}

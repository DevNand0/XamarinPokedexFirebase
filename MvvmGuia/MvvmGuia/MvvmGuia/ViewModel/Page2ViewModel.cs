using MvvmGuia.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.ViewModel
{
    public class Page2ViewModel:BaseViewModel
    {
        #region VARIABLES
        string _Texto;

        public List<Usuario> ListaUsuarios { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Page2ViewModel(INavigation navigation)
        {
            Navigation = navigation;
            MostrarUsuarios();
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

        public async Task Alert(Usuario User) 
        {
            await DisplayAlert("Usuario Seleccionado", User.Nombre, "OK");
        }

        public void MostrarUsuarios()
        {
            ListaUsuarios = new List<Usuario> 
            { 
                new Usuario
                {
                    Nombre = "Chano",
                    Imagen = "charlando.png"
                },
                new Usuario
                {
                    Nombre = "Nando",
                    Imagen = "guitarra.png"
                },
                new Usuario
                {
                    Nombre = "Lander",
                    Imagen = "pesa.png"
                }
            };
        }
        #endregion

        #region COMANDOS
        public ICommand VolverAsyncCommand => new Command(async () => await VolverAsync());

        public ICommand AlertaCommand => new Command<Usuario>(async (User) => await Alert(User));

        // public ICommand MostrarUsuariosCommand => new Command(MostrarUsuarios);
        #endregion
    }
}

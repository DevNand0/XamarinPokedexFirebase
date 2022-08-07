using MvvmGuia.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmGuia.Data;

namespace MvvmGuia.ViewModel.Pokemon
{
    public class RegisterPokemonPageViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        string _Txtcolorfondo;
        string _Txtcolorpoder;
        string _Txtnombre;
        string _Txtnro;
        string _Txticono;
        string _Txtpoder;

        #endregion

        #region CONSTRUCTOR
        public RegisterPokemonPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
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

        public string Txtcolorfondo
        {
            get { return _Txtcolorfondo; }
            set
            {
                SetValue(ref _Txtcolorfondo, value);
            }
        }

        public string Txtcolorpoder
        {
            get { return _Txtcolorpoder; }
            set
            {
                SetValue(ref _Txtcolorpoder, value);
            }
        }

        public string Txtnro
        {
            get { return _Txtnro; }
            set
            {
                SetValue(ref _Txtnro, value);
            }
        }

        public string Txtnombre
        {
            get { return _Txtnombre; }
            set
            {
                SetValue(ref _Txtnombre, value);
            }
        }

        public string Txticono
        {
            get { return _Txticono; }
            set
            {
                SetValue(ref _Txticono, value);
            }
        }

        public string Txtpoder
        {
            get { return _Txtpoder; }
            set
            {
                SetValue(ref _Txtpoder, value);
            }
        }
        #endregion

        #region PROCESOS
        public async Task Insertar() 
        {
            var funcion     = new DataPokemon();
            var model  = new MvvmGuia.Model.Pokemon();
            model.Colorfondo = Txtcolorfondo;
            model.ColorPoder = Txtcolorpoder;
            model.Icono      = Txticono;
            model.Nombre     = Txtnombre;
            model.Nroorden   = Txtnro;
            model.Poder      = Txtpoder;
            await funcion.Insert(model);
            await VolverListadoAsync();
        }
        public async Task VolverListadoAsync()
        {
            //IMPORTANTE
            //PopAsync ES PARA VOLVER A LA PAGINA ANTERIOR
            await Navigation.PopAsync();
            //PushAsync ES PARA IR A SIGUIENTE PAGINA 
        }


        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand InsertarCommand => new Command(async () => await Insertar());
        public ICommand VolverAsyncCommand => new Command(async () => await VolverListadoAsync());
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}

using MvvmGuia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.ViewModel
{
    class Page1ViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Mensaje;
        string _Numero1;
        string _Numero2;
        string _Resultado;

        string _TipoUsuario;

        DateTime _Fecha;
        string _ResultadoFecha;

        bool _Visible;

        #endregion

        #region CONSTRUCTOR
        public Page1ViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Fecha = DateTime.Now;
        }
        #endregion

        #region OBJETOS
        public string Mensaje
        {
            get { return _Mensaje; }
            set
            {
                SetValue(ref _Mensaje, value);
            }
        }

        //ANALIZAR ESTA SECCION
        public string TipoUsuario
        {
            get { return _TipoUsuario; }
            set { SetValue(ref _TipoUsuario, value); }
        }
        //PASA EL DATO SELECCIONADO AL STRING CREADO MAS ARRIBA
        public string TipoSeleccionado 
        {
            get { return _TipoUsuario; }
            set 
            {
                SetProperty(ref _TipoUsuario, value);
                TipoUsuario = _TipoUsuario;
            }
        }

        public string ResultadoFecha
        {
            get { return _ResultadoFecha; }
            set 
            {
                SetValue(ref _ResultadoFecha, value);
            }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set 
            {
                //_Fecha = value;
                //OnpropertyChanged(Fecha.ToString());
                SetValue(ref _Fecha, value);
                ResultadoFecha = _Fecha.ToString("dd/MM/yyyy");

            }
        }

        public string Numero1
        {
            get { return _Numero1; }
            set
            {
                SetValue(ref _Numero1, value);
            }
        }

        public string Numero2
        {
            get { return _Numero2; }
            set
            {
                SetValue(ref _Numero2, value);
            }
        }

        public string Resultado
        {
            get { return _Resultado; }
            set
            {
                SetValue(ref _Resultado, value);
            }
        }

        public bool Visible
        {
            get { return _Visible; }
            set
            {
                SetValue(ref _Visible, value);
            }
        }
        #endregion

        #region PROCESOS
        public async Task VolverAsync()
        {
            await Navigation.PopAsync();
        }
        public async Task NavegacionPagina()
        {
            await Navigation.PushAsync(new Page2());
        }
        public async Task AlertaAsyncrono()
        {
            await DisplayAlert("Titulo", Mensaje, "OK");
        }

        public void Sumar()
        {
            if (string.IsNullOrEmpty(Numero1) || string.IsNullOrEmpty(Numero2))
            {
                Visible = false;
                return;
            }
            Visible = true;
            int suma = Convert.ToInt32(Numero1) + Convert.ToInt32(Numero2);
            Resultado = suma.ToString();
            
        }
        #endregion

        #region COMANDOS
        public ICommand VolverAsyncCommand => new Command(async () => await VolverAsync());
        public ICommand NavegacionAsyncCommand => new Command(async () => await NavegacionPagina());
        public ICommand AlertAsyncCommand => new Command(async () => await AlertaAsyncrono());
        public ICommand SumarCommand => new Command(Sumar);
        #endregion
    }
}

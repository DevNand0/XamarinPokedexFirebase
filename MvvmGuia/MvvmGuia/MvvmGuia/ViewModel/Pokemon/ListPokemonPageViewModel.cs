using MvvmGuia.Data;
using MvvmGuia.ViewModel;
using MvvmGuia.Views.Pokemon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.ViewModel.Pokemon
{
    public class ListPokemonPageViewModel:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        ObservableCollection<MvvmGuia.Model.Pokemon> _list;
        #endregion

        #region CONSTRUCTOR
        public ListPokemonPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            MostrarCommandCommand.Execute(null);
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

        public ObservableCollection<MvvmGuia.Model.Pokemon> List
        {
            get { return _list; }
            set
            {
                SetValue(ref _list, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region PROCESOS
        public async Task IrRegistroAsync()
        {
            //IMPORTANTE
            //PushAsync ES PARA IR A SIGUIENTE PAGINA 
            await Navigation.PushAsync(new RegisterPokemonPage());
            //PopAsync ES PARA VOLVER A LA PAGINA ANTERIOR
        }

        public async Task IrDetalle(MvvmGuia.Model.Pokemon model) 
        {

            await Navigation.PushAsync(new DetallePokemonPage(model));
        }

        public async Task Mostrar() 
        {
            var funcion = new DataPokemon();
            List = await funcion.MostrarTodos();
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand IrRegistroAsyncCommand => new Command(async () => await IrRegistroAsync());
        public ICommand IrDetalleCommand => new Command<MvvmGuia.Model.Pokemon>(async (model) => await IrDetalle(model));
        public ICommand MostrarCommandCommand => new Command(async() => await Mostrar());
        #endregion
    }
}

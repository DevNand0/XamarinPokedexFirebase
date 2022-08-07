using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.ViewModel.Pokemon
{
    public class DetallePokemonPageViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;


        MvvmGuia.Model.Pokemon _ModelSelected;
        //public MvvmGuia.Model.Pokemon ModelSelected;
        #endregion

        #region CONSTRUCTOR
        public DetallePokemonPageViewModel(INavigation navigation, MvvmGuia.Model.Pokemon model)
        {
            Navigation    = navigation;
            ModelSelected = model;
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
        public MvvmGuia.Model.Pokemon ModelSelected
        {
            get { return _ModelSelected; }
            set
            {
                SetValue(ref _ModelSelected, value);
            }
        }

        #endregion

        #region PROCESOS
        public async Task VolverListadoAsync()
        {
            //IMPORTANTE
            //PopAsync ES PARA VOLVER A LA PAGINA ANTERIOR
            await Navigation.PopAsync();
            //PushAsync ES PARA IR A SIGUIENTE PAGINA 
        }
        public async Task ProcesoAsyncrono()
        {

        }

        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand VolverAsyncCommand => new Command(async () => await VolverListadoAsync());
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    
    }
}

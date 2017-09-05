using FlagData;
using Xamarin.Forms;

namespace FunFlacts
{
    public partial class AllFlags : ContentPage
    {
        public AllFlags()
        {
            BindingContext = DependencyService.Get<FunFlactsViewModel>();
            InitializeComponent();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            //DependencyService.Get<FunFlactsViewModel>().CurrentFlag = (Flag)e.Item;
            await this.Navigation.PushAsync(new FlagDetailsPage());
        }
    }
}
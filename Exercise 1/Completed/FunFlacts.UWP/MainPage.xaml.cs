using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace FunFlacts.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Load Xamarin.Forms
            LoadApplication(new FunFlacts.App());
        }
    }
}

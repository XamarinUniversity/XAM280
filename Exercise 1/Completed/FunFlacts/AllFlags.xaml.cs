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
    }
}
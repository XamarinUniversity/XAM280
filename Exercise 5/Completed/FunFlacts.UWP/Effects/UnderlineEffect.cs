using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("FunFlacts.Effects")]
[assembly: ExportEffect(typeof(FunFlacts.UWP.Effects.UnderlineEffect), nameof(FunFlacts.Effects.UnderlineEffect))]

namespace FunFlacts.UWP.Effects
{
    public class UnderlineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            SetUnderline(true);
        }

        protected override void OnDetached()
        {
            SetUnderline(false);
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == Label.TextProperty.PropertyName 
                || args.PropertyName == Label.FormattedTextProperty.PropertyName)
            {
                SetUnderline(true);
            }
        }

        private void SetUnderline(bool on)
        {
            var label = Control as TextBlock;
            if (label != null)
            {
                if (on)
                {
                    label.TextDecorations |= Windows.UI.Text.TextDecorations.Underline;
                }
                else
                {
                    label.TextDecorations &= ~Windows.UI.Text.TextDecorations.Underline;
                }
            }
        }
    }
}
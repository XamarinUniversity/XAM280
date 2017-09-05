using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("FunFlacts.Effects")]
[assembly: ExportEffect(typeof(FunFlacts.iOS.Effects.UnderlineEffect), nameof(FunFlacts.Effects.UnderlineEffect))]

namespace FunFlacts.iOS.Effects
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
            var label = Control as UILabel;
            if (label != null)
            {
                var text = label.AttributedText as NSMutableAttributedString;
                var range = new NSRange(0, text.Length);

                if (on)
                {
                    text?.AddAttribute(UIStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);
                }
                else
                {
                    text?.RemoveAttribute(UIStringAttributeKey.UnderlineStyle, range);
                }
            }
        }
    }
}
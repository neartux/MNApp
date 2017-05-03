using WisenetBackOfficeApp.Droid.Controls;
using WisenetBackOfficeApp.Helpers.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomControlThemeBlackEntry), typeof(AndroidThemeBlackEntry))]
namespace WisenetBackOfficeApp.Droid.Controls
{
    class AndroidThemeBlackEntry : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {

                Control.SetBackgroundResource(Resource.Drawable.ThemeBlackEntry);


            }

        }

    }
}
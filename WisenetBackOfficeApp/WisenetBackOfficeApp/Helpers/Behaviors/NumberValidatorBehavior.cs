using Xamarin.Forms;

namespace WisenetBackOfficeApp.Helpers.Behaviors
{
    class NumberValidatorBehavior : Behavior<Entry>
    {

        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(NumberValidatorBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            private set { SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            double result;
            IsValid = double.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;

        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
        }


    }
}

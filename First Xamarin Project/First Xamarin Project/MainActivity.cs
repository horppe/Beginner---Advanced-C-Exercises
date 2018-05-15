using Android.App;
using Android.Widget;
using Android.OS;

namespace First_Xamarin_Project
{
    [Activity(Label = "First_Xamarin_Project", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            LinearLayout layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;
            Button button = new Button(this);
            button.Text = "Hello World!";
            layout.AddView(
            button,
            ViewGroup.LayoutParams.MatchParent,
            ViewGroup.LayoutParams.WrapContent);
            SetContentView(layout);
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}


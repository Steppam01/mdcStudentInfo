using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace sc00_mdcInformation
{
    [Activity(Label = "sc00_mdcInformation", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button getInfo = (Button)FindViewById<Button>(Resource.Id.btnInfo);

            getInfo.Click += delegate
            {
                var infoDisplayActivity = new Intent(this, typeof(InfoDisplayActivity));
                EditText name = (EditText)FindViewById<EditText>(Resource.Id.txtName);
                EditText major = (EditText)FindViewById<EditText>(Resource.Id.txtMajor);
                Spinner campus = (Spinner)FindViewById<Spinner>(Resource.Id.campusSelect);

                //Setting input values
                infoDisplayActivity.PutExtra("name", name.Text);
                infoDisplayActivity.PutExtra("major", major.Text);
                infoDisplayActivity.PutExtra("campus", campus.SelectedItem.ToString());
                StartActivity(infoDisplayActivity);
            };
        }
    }
}


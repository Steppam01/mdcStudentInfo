using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace sc00_mdcInformation
{
    [Activity(Label = "InfoDisplayActivity")]
    public class InfoDisplayActivity : Activity
    {
        //Dictionary to hold campus numbers
        private Dictionary<string, string> campusPhoneNumbers = new Dictionary<string, string>()
        {
            {"Wolfson", "3052373131"},
            {"Inter-American", "3052376000"},
            {"Kendall", "3052372000"},
            {"Homestead", "3052375555"},
            {"West", "3052378000"},
            {"Hialeah", "3052378700"},
            {"North", "3052371000"}
        };

        //Dictionary to hold campus coordinates
        private Dictionary<string, string> campusLocations = new Dictionary<string, string>()
        {
            {"Wolfson", "25.7776179,-80.1907324"},
            {"Inter-American", "25.7656777,-80.2383785"},
            {"Kendall", "25.6750688,-80.3732776"},
            {"Homestead", "25.474449,-80.4741931"},
            {"West", "25.8087038,-80.3846542"},
            {"Hialeah", "25.8651748,-80.3189604"},
            {"North", "25.8771259,-80.2457318"}
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Info);

            //Retrieving values from intent
            string name = Intent.GetStringExtra("name");
            string major = Intent.GetStringExtra("major");
            string campus = Intent.GetStringExtra("campus");

            TextView nameDisplay = (TextView)FindViewById<TextView>(Resource.Id.txtNameDisplay);
            TextView majorDisplay = (TextView)FindViewById<TextView>(Resource.Id.txtMajorDisplay);
            TextView campusDisplay = (TextView)FindViewById<TextView>(Resource.Id.txtCampusDisplay);

            //Displaying values
            nameDisplay.Text = name;
            majorDisplay.Text = major;
            campusDisplay.Text = campus;

            //Constructing buttons
            Button callCampus = (Button)FindViewById<Button>(Resource.Id.btnCallCampus);
            callCampus.Text = "Call " + campus;
            Button getDirections = (Button)FindViewById<Button>(Resource.Id.btnGetDirections);
            getDirections.Text = "Directions to " + campus;

            callCampus.Click += delegate
            {
                //Dialing phone number from dictionary based on campus 
                var uri = Android.Net.Uri.Parse("tel:" + campusPhoneNumbers[campus]);
                Intent myIntent = new Intent(Intent.ActionDial, uri);
                StartActivity(myIntent);
            };

            getDirections.Click += delegate
            {
                //Opening location from dictionary based on campus
                var uri = Android.Net.Uri.Parse("geo:" + campusLocations[campus]);
                Intent myIntent = new Intent(Intent.ActionView, uri);
                StartActivity(myIntent);
            };
        }
    }
}
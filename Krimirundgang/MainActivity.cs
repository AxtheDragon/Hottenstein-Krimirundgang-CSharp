﻿using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Locations;


namespace Krimirundgang
{
    [Activity(Label = "Krimirundgang", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ILocationListener
    {
        //Setup location services
        LocationManager locMgr;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Initialising location services
            locMgr = GetSystemService(Context.LocationService) as LocationManager;

            //Get references for Layout elements
            Button firstButton = FindViewById<Button>(Resource.Id.button1);
            TextView text = FindViewById<TextView>(Resource.Id.textView1);
            Button secondPageButton = FindViewById<Button>(Resource.Id.next);

            //Simple Button click event
            firstButton.Click += (object sender, EventArgs e) =>
            {
                text.Visibility = ViewStates.Visible;
            };

            //Event for second Button
            //shows second page but does not yet load secondActivity.cs
            secondPageButton.Click += (object sender, EventArgs e) =>
            {
                Intent intent = new Intent(this, typeof(secondActivity));
                StartActivity(intent);
            };
        }

        protected override void OnResume()
        {
            base.OnResume();
            //Choose GPS as used location service
            string Provider = LocationManager.GpsProvider;

            //request location updates every 2000 ms AND if location changes by <1 m
            if (locMgr.IsProviderEnabled(Provider))
            {
                locMgr.RequestLocationUpdates(Provider, 2000, 1, this);
            }
            else
            {
                Log.Info(tag, Provider + " is not available. Does the device have location services enabled?");
            }
        }

        public void OnLocationChanged(Location location)
        {
            throw new NotImplementedException();
        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }
    }
}


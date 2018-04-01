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
using Android.Gms.Ads;
using Android.Util;

namespace AdMob
{
    [Activity(Label = "SecondPageActivity")]
    public class SecondPageActivity : Activity
    {
        private InterstitialAd mInterstitialAd;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.SecondPage);

            var showAdButton = FindViewById<Button>(Resource.Id.ShowAdButton);
            showAdButton.Click += ShowAdButton_Click;

            mInterstitialAd = new InterstitialAd(this);
            mInterstitialAd.AdUnitId = GetString(Resource.String.InterstitialAdUnitID);
        }

        void ShowAdButton_Click(object sender, EventArgs e)
        {
            mInterstitialAd.LoadAd(new AdRequest.Builder().Build());
            if (mInterstitialAd.IsLoaded)
            {
                mInterstitialAd.Show();
            }
            else
            {
                Log.Debug("Interstitial Ad", "The interstitial wasn't loaded yet.");
            }
        }

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
		}
	}
}

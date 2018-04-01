using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Ads;

namespace AdMob
{
    [Activity(Label = "AdMob", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        AdView adView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Button nextPageButton = FindViewById<Button>(Resource.Id.NextPageButton);
            nextPageButton.Click += delegate { StartActivity(typeof(SecondPageActivity)); };

            //To be uncommented when using actual AppID and AdUnitID instead of the test AdUnitID currently used
            //MobileAds.Initialize(this, GetString(Resource.String.AppID));
            MobileAds.Initialize(this, "ca-app-pub-3940256099942544~3347511713");

            adView = FindViewById<AdView>(Resource.Id.AdView);
            ShowAdsBanner();
        }

        void ShowAdsBanner()
        {
            var adRequest = new AdRequest.Builder().Build();
            adView.AdListener = new MyAdListener();
            adView.LoadAd(adRequest);
        }
    }
}


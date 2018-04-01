using System;
using Android.Gms.Ads;
using Android.Util;

namespace AdMob
{
    public class MyAdListener : AdListener
    {
        public MyAdListener()
        {
        }

		public override void OnAdFailedToLoad(int errorCode)
		{
            switch (errorCode)
            {
                case AdRequest.ErrorCodeInternalError:
                    Log.Error("Internal Error", "Something happened internally; for instance, an invalid response was received from the ad server.");
                    break;
                case AdRequest.ErrorCodeInvalidRequest:
                    Log.Error("Invalid Request", "The ad request was invalid; for instance, the ad unit ID was incorrect.");
                    break;
                case AdRequest.ErrorCodeNetworkError:
                    Log.Error("Network Error", "The ad request was unsuccessful due to network connectivity.");
                    break;
                case AdRequest.ErrorCodeNoFill:
                    Log.Error("No Fill", "The ad request was successful, but no ad was returned due to lack of ad inventory.");
                    break;
            }
            base.OnAdFailedToLoad(errorCode);
		}
	}
}

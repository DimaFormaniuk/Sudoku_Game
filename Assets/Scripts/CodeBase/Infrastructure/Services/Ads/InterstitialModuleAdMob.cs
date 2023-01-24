using System;
using GoogleMobileAds.Api;

namespace CodeBase.Infrastructure.Services.Ads
{
    public class InterstitialModuleAdMob : IAdsModule
    {
        private readonly string _interstitialAdId;
        private InterstitialAd _interstitialAd;

        private Action _onAdLoaded = null;
        private Action<AdsResultType> _onAdResult = null;

        public InterstitialModuleAdMob(string interstitialAdId)
        {
            _interstitialAdId = interstitialAdId;
        }

        public bool IsLoaded() => _interstitialAd.IsLoaded();

        public void Show(Action<AdsResultType> onAdResult)
        {
            _onAdResult = onAdResult;

            if (IsLoaded()) _interstitialAd.Show();
            else LoadAd(() => _interstitialAd.Show());
        }

        public void LoadAd(Action onAdLoaded = null)
        {
            _onAdLoaded = onAdLoaded;
            
            _interstitialAd = new InterstitialAd(_interstitialAdId);

            _interstitialAd.OnAdClosed += HandleInterstitialAdClosed;
            _interstitialAd.OnAdLoaded += InterstitialAd_OnAdLoaded;

            AdRequest request = new AdRequest.Builder().Build();
            _interstitialAd.LoadAd(request);
        }

        private void HandleInterstitialAdClosed(object sender, EventArgs e)
        {
            _onAdResult?.Invoke(AdsResultType.Completed);

            if (!IsLoaded())
                LoadAd();
        }

        private void InterstitialAd_OnAdLoaded(object sender, EventArgs e)
        {
            _onAdLoaded?.Invoke();
        }
    }
}
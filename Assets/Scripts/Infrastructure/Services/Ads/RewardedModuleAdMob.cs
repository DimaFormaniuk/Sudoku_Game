using System;
using GoogleMobileAds.Api;

namespace Infrastructure.Services.Ads
{
    public class RewardedModuleAdMob : IAdsModule
    {
        private readonly string _rewardedAdId;
        private RewardedAd _rewardedAd;

        private Action _onAdLoaded = null;
        private Action<AdsResultType> _onAdResult = null;

        public RewardedModuleAdMob(string rewardedAdId)
        {
            _rewardedAdId = rewardedAdId;
        }

        public bool IsLoaded() => _rewardedAd.IsLoaded();

        public void Show(Action<AdsResultType> onAdResult)
        {
            _onAdResult = onAdResult;

            if (IsLoaded()) _rewardedAd.Show();
            else LoadAd(() => _rewardedAd.Show());
        }

        public void LoadAd(Action onAdLoaded = null)
        {
            _onAdLoaded = onAdLoaded;

            _rewardedAd = new RewardedAd(_rewardedAdId);
            _rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
            _rewardedAd.OnAdClosed += HandleRewardedAdClosed;
            _rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            AdRequest request = new AdRequest.Builder().Build();
            _rewardedAd.LoadAd(request);
        }

        private void HandleUserEarnedReward(object sender, Reward e)
        {
            _onAdResult?.Invoke(AdsResultType.Completed);

            if (!IsLoaded())
                LoadAd();
        }

        private void HandleRewardedAdClosed(object sender, EventArgs e)
        {
            _onAdResult?.Invoke(AdsResultType.Canceled);

            if (!IsLoaded())
                LoadAd();
        }

        private void HandleRewardedAdLoaded(object sender, EventArgs e)
        {
            _onAdLoaded?.Invoke();
        }
    }
}
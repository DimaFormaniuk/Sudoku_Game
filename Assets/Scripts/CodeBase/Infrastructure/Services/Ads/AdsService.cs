using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.Services.Ads
{
    public class AdsService : IAdsService
    {
        private AdsModuleContainer _rewardedContainer;
        private AdsModuleContainer _interstitialContainer;

        public AdsService()
        {
            _rewardedContainer = new AdsModuleContainer();
            _interstitialContainer = new AdsModuleContainer();
        }

        public void Init()
        {
            _rewardedContainer.Init(new List<IAdsModule> { new RewardedModuleAdMob("ca-app-pub-9354246231789271/6720651555") });
            _interstitialContainer.Init(new List<IAdsModule> { new InterstitialModuleAdMob("ca-app-pub-9354246231789271/9729958279") });
        }

        public bool HasLoadedRewarded()
        {
            return _rewardedContainer.HasLoaded();
        }

        public void ShowRewarded(Action<AdsResultType> onAdResult = null)
        {
            _rewardedContainer.Show(onAdResult);
        }

        public void RewardedLoaded(Action loaded)
        {
            _rewardedContainer.LoadedAd(loaded);
        }

        public bool HasLoadedInterstitial()
        {
            return _interstitialContainer.HasLoaded();
        }

        public void ShowInterstitial(Action<AdsResultType> onAdResult = null)
        {
            _interstitialContainer.Show(onAdResult);
        }
        
        public void InterstitialLoaded(Action loaded)
        {
            _interstitialContainer.LoadedAd(loaded);
        }
    }
}
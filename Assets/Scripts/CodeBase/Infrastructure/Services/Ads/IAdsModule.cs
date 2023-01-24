using System;

namespace CodeBase.Infrastructure.Services.Ads
{
    public interface IAdsModule
    {
        bool IsLoaded();
        void LoadAd(Action onAdLoaded = null);
        void Show(Action<AdsResultType> onAdResult);
    }
}
using System;
using System.Collections.Generic;

namespace Infrastructure.Services.Ads
{
    public class AdsModuleContainer
    {
        protected List<IAdsModule> AdsModuleList = new List<IAdsModule>();

        public void Init(List<IAdsModule> adsModuleList)
        {
            AdsModuleList = adsModuleList;

            foreach (var adsModule in AdsModuleList)
                adsModule.LoadAd();
        }

        public bool HasLoaded()
        {
            return AdsModuleList.Exists(x => x.IsLoaded());
        }

        public void Show(Action<AdsResultType> onAdResult)
        {
            if (HasLoaded())
                AdsModuleList.Find(x => x.IsLoaded()).Show(onAdResult);
            else
                onAdResult?.Invoke(AdsResultType.Canceled);
        }

        public void LoadedAd(Action onAdLoaded)
        {
            if (AdsModuleList.FindAll(x => x.IsLoaded()).Count > 0)
                onAdLoaded?.Invoke();
            else
                AdsModuleList.ForEach(x => x.LoadAd(onAdLoaded));
        }
    }
}
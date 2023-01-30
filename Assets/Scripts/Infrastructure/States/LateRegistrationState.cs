using Infrastructure.Services;
using Infrastructure.Services.Ads;
using Infrastructure.Services.Factory;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.Theme;

namespace Infrastructure.States
{
    public class LateRegistrationState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly AllServices _services;

        public LateRegistrationState(GameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            LateRegistration();

            _stateMachine.Enter<LoadMainState>();
        }

        public void Exit()
        {
        }

        private void LateRegistration()
        {
            SubscribeToFactory();

            _services.Single<IAdsService>().Init();
        }

        private void SubscribeToFactory()
        {
            _services.Single<IUIFactoryService>().Registered(_services.Single<ISaveLoadService>());
            _services.Single<IUIFactoryService>().Registered(_services.Single<IThemeService>());
        }
    }
}